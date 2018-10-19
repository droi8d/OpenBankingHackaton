using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenBankingApi.Models;

namespace OpenBankingApi.Controllers
{
    public class UserLoggedController : Controller
    {
        // GET: UserLogged
        public async Task<ActionResult> Index(string code, string state, string error, string redirect)
        {
            if(redirect == null)
            {
                return new EmptyResult();
            }
            //var client = new HttpClient();
            //var result = await client.GetAsync(string.Format("https://bm-devportal-testwebapp03.azurewebsites.net/tokens?code={0}&refresh_token={1}&redirect_uri={2}&client_id={3}&client_assertion={4}", code, string.Empty, "http://localhost", Guid.NewGuid(), Guid.NewGuid()));
            //var token = await result.Content.ReadAsAsync<TokenModel>();
            //Session["userTokenData"] = token;
            
            var model = new OpenBankingApi.Models.Redirect() {
                Code = code,
                State = state,
                Error= error
            };
            return View(model);
        }
    }
}