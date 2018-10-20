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
        [HttpGet]
        public async Task<ActionResult> GetAccounts()
        {
            var token = this.Session["userTokenData"] as TokenModel;
            var path = @"C:\Certificates\bank.millennium.psd2.sandbox.tls.hackathon.team.06.pfx";
            var cert = ReadFile(path);
            _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);
            var httpHandler = new WebRequestHandler();
            httpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpHandler.ClientCertificates.Add(this._certificate);
            var api = new PolishAPI(httpHandler, new RequestSigningHandler(_certificate));

            var request = new AccountsRequest(
                new RequestHeaderAIS(token.accessToken, Guid.NewGuid().ToString(), sendDate: DateTime.Now.ToString(), tppId: "team6@bankmillennium.pl", isDirectPsu: true),
                true,
                null,
                0);
            api.BaseUri = new Uri("https://bm-devportal-testwebapp02.azurewebsites.net");
            api.AcceptLanguage = "pl-PL";
            api.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.accessToken);
            var contentJws = JWT.Encode(JsonConvert.SerializeObject(request), _certificate.GetRSAPrivateKey(),
                        JwsAlgorithm.RS256);
            var startIndex = contentJws.IndexOf('.') + 1;
            var jwsSignature = contentJws.Remove(startIndex, contentJws.IndexOf('.', startIndex) - startIndex);
            api.XJWSSIGNATURE = jwsSignature;
            var result = await api.GetAccountsWithHttpMessagesAsync(request);

            var model = result.Body as AccountsResponse;

            return View(model.Accounts);
        }
    }
}