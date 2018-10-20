using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenBankingApi.Models;

namespace OpenBankingApi.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using Jose;

    public class UserLoggedController : BaseController
    {
        // GET: UserLogged
        public async Task<ActionResult> Index(string code, string state, string error, string redirect)
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

            var model = new OpenBankingApi.Models.Redirect()
            {
                Code = code,
                State = state,
                Error = error
            };
            return View(model);
        }
    }
}