using OpenBankingApi.Handlers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace OpenBankingApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<string> Token()
        {
            var header = new JwtHeader();
            header.Add("alg", "RS256");
            header.Add("typ", "JWT");

            var payload = new JwtPayload();
            payload.Add("sub", "aprazmowsk@gmail.com");
            payload.Add("response_code", "Code");
            payload.Add("redirect_uri", "http://localhost");
            payload.Add("scope", "[{\"resource\":{\"type\":\"account\",\"accountType\":{\"paymentAccount\":[],\"creditCardAccount\":[]}},\"scopeTimeDuration\":600,\"throttlingPolicy\":\"psd2Regulatory\",\"privilegeList\":{\"ais:accounts\":{\"maxAllowedHistoryLong\":365}},\"scopeGroupType\":\"accountInformationService\"}]");
            payload.Add("state", "22137C25EE4A3BB48AF76FA7938EB6C340C668DC6204CE5B27BA7BE8433C6F8C");

            var token = new JwtSecurityToken(header: header, payload: payload);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var aa = new AuthorizationHandler();
            var response = await aa.SendRequest(tokenString);
            return response.ToString();
        }

        private object ReadFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}