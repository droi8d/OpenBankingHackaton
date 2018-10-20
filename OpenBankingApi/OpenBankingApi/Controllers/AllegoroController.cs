using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenBankingApi.Controllers
{
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Api;
    using Api.Models;
    using Jose;
    using Newtonsoft.Json;
    using OpenBankingApi.Models;

    public class AllegoroController : BaseController
    {
        // GET: Allegro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Authorize()
        {
            var scope = new AISScope(true, true, true, true, true, true);
            var payload = new Dictionary<string, string>()
            {
                { "sub", "team6@bankmillennium.pl" },
                { "response_code", "Code" },
                { "redirect_uri", "http://localhost:55647/Allegoro/Logged" },
                //AIS Scope
                { "scope", scope.GetAISScope(new List<string>(), new List<string>())},

                //PIS scope
                //{ "scope", "[{\"resource\":{\"type\":\"account\",\"accountType\":{\"paymentAccount\":[],"+"\"creditCardAccount\":[]}},\"scopeTimeDuration\":600,\"throttlingPolicy\":\"psd2Regulatory\",\"privilegeList\":"+
                //"{\"pis:domestic\":{\"scopeUsageLimit\":1}},\"scopeGroupType\":\"paymentInformationService\"}]" },
                { "state", "22137C25EE4A3BB48AF76FA7938EB6C340C668DC6204CE5B27BA7BE8433C6F8C" }
            };

            this._signCertificate.Import(ReadFile(this.signCertPath), "millennium", X509KeyStorageFlags.DefaultKeySet);
            string tokenSigned = JWT.Encode(payload, this._signCertificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;
            var client = new HttpClient(/*httpClientHandler*/);

            var result = await client.PostAsync("https://bm-devportal-testwebapp03.azurewebsites.net/authorization", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("jwt", tokenSigned)
            }));

            return Redirect(result.RequestMessage.RequestUri.ToString() + "&redirect=true");
        }

        // GET: UserLogged
        public async Task<ActionResult> Logged(string code, string state, string error, string redirect)
        {
            if (redirect == null)
            {
                return new EmptyResult();
            }
            var client = new HttpClient();

            var payload = new Dictionary<string, string>()
            {
                { "sub", "team6@bankmillennium.pl" }
            };

            this._signCertificate.Import(ReadFile(this.signCertPath), "millennium", X509KeyStorageFlags.DefaultKeySet);
            string tokenSigned = JWT.Encode(payload, this._signCertificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);
            var link = string.Format(
                "https://bm-devportal-testwebapp03.azurewebsites.net/tokens?code={0}&redirect_uri={1}&client_id={2}&client_assertion={3}",
                code, "http://localhost:55647/UserLogged", "team6@bankmillennium.pl", tokenSigned);
            var result = await client.GetAsync(link);
            var token = await result.Content.ReadAsAsync<TokenModel>();
            this.Session["userTokenData"] = token;

            this._tlsCertificate.Import(ReadFile(this.tlsCertPath), "millennium", X509KeyStorageFlags.DefaultKeySet);

            this._signCertificate.Import(ReadFile(this.signCertPath), "millennium", X509KeyStorageFlags.DefaultKeySet);
            var httpHandler = new WebRequestHandler();
            httpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpHandler.ClientCertificates.Add(this._tlsCertificate);
            var api = new PolishAPI(httpHandler, new RequestSigningHandler(this._signCertificate));
            var request = new AccountsRequest(
                new RequestHeaderAIS(token.accessToken, Guid.NewGuid().ToString(), sendDate: DateTime.Now.ToString(), tppId: "team6@bankmillennium.pl", isDirectPsu: true),
                true,
                null,
                0);
            api.BaseUri = new Uri("https://bm-devportal-testwebapp02.azurewebsites.net");
            api.AcceptLanguage = "pl-PL";
            api.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.accessToken);

            api.XJWSSIGNATURE = JWT.Encode(JsonConvert.SerializeObject(request), this._signCertificate.GetRSAPrivateKey(),
                JwsAlgorithm.RS256);
            var result2 = await api.GetAccountsWithHttpMessagesAsync(request);

            var model = result2.Body as AccountsResponse;

            var account = model.Accounts.First();

            var request2 = new AccountInfoRequest
            {
                AccountNumber = account.AccountNumber,
                RequestHeader =
                    new RequestHeaderAIS(token.accessToken, Guid.NewGuid().ToString(),
                        sendDate: DateTime.Now.ToString(), tppId: "team6@bankmillennium.pl", isDirectPsu: true)
            };
            var result3 = await api.GetAccountWithHttpMessagesAsync(request2);

            var accountInfo = result3.Body as AccountResponse;
            return View(accountInfo.Account);
        }
    }
}