using OpenBankingApi.Models;
using OpenBankingApi.Models.AIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Api.Models.AIS;
using Api.Models.AIS.Models;

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
        [HttpGet]
        public async Task<ActionResult> GetAccounts()
        {
            var token = this.Session["userTokenData"] as TokenModel;
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
            ;
            var result = await api.GetAccountsWithHttpMessagesAsync(request);

            var model = result.Body as AccountsResponse;

            return View(model.Accounts);
        }
    }
}