using OpenBankingApi.Models;
using OpenBankingApi.Models.AIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenBankingApi.Controllers
{
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using Api;
    using Api.Models;
    using Jose;
    using Newtonsoft.Json;

    public class AISController : BaseController
    {
        //[HttpGet]
        //public async Task<ActionResult> AllUsersAccountsInformation()
        //{
        //    var token = this.Session["userTokenData"] as TokenModel;
        //    var allaccountsinformationrequest = new AISRequestHeader(token.accessToken, "100", string.Empty,
        //        System.Net.IPAddress.Parse("127.0.0.1").ToString(), DateTime.Now.ToShortTimeString(),
        //        "team6@bankmillennium.pl");
        //    var allaccountsinformationrequestserialized = JsonConvert.SerializeObject(allaccountsinformationrequest);
        //    var client = new HttpClient();

        //    var path = @"C:\Certificates\bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
        //    var cert = ReadFile(path);
        //    _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);

        //    var contentJws = JWT.Encode(allaccountsinformationrequestserialized, _certificate.GetRSAPrivateKey(),
        //        JwsAlgorithm.RS256);
        //    var startIndex = contentJws.IndexOf('.') + 1;
        //    var jwsSignature = contentJws.Remove(startIndex, contentJws.IndexOf('.', startIndex) - startIndex);

        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "pl-PL");
        //    client.DefaultRequestHeaders.Remove("X-JWS-SIGNATURE");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("X-JWS-SIGNATURE", "SIGNATURENOVERIFY");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.accessToken);
        //    var param = new FormUrlEncodedContent(new[]
        //    {
        //        new KeyValuePair<string, string>("requestHeader", allaccountsinformationrequestserialized),
        //        new KeyValuePair<string, string>("isDirectPsu", bool.TrueString.ToLower()),
        //        new KeyValuePair<string, string>("pageId", Guid.NewGuid().ToString()),
        //        new KeyValuePair<string, string>("perPage", "0"),
        //    });
        //    var result = await client.PostAsync(
        //        "https://bm-devportal-testwebapp02.azurewebsites.net/v1.0/accounts/v1.0/getAccounts", param);

        //    AISHttpError oa;
        //    if (result.TryGetContentValue(out oa))
        //    {
        //        return View(oa);
        //    }

        //    return View();
        //}

        [HttpGet]
        public async Task<ActionResult> AllUsersAccountsInformation()
        {
            var token = this.Session["userTokenData"] as TokenModel;
            var path = @"C:\Certificates\bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
            var cert = ReadFile(path);
            _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);
            var httpHandler = new WebRequestHandler();
            httpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpHandler.ClientCertificates.Add(this._certificate);
            var api = new PolishAPI(httpHandler, new RequestSigningHandler(_certificate));

            var request = new AccountsRequest(new RequestHeaderAIS(token.accessToken));
            api.BaseUri = new Uri("https://bm-devportal-testwebapp02.azurewebsites.net");
            api.AcceptLanguage = "en-GB";

            var contentJws = JWT.Encode(JsonConvert.SerializeObject(request), _certificate.GetRSAPrivateKey(),
                        JwsAlgorithm.RS256);
            var startIndex = contentJws.IndexOf('.') + 1;
            var jwsSignature = contentJws.Remove(startIndex, contentJws.IndexOf('.', startIndex) - startIndex);
            api.XJWSSIGNATURE = jwsSignature;
            var result = await api.GetAccountsWithHttpMessagesAsync(request);

            return View();
        }
    }
}