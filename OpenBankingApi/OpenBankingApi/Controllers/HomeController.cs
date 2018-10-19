using OpenBankingApi.Handlers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
            var token = new JwtSecurityToken(claims: new[]
            {
                new Claim("sub", "TPP.NEWINT"),
                new Claim("response_code", "Code"),
                new Claim("redirect_uri", "http://localhost"),
                new Claim("scope", "[{\"privilegeList\":{\"pis:domestic\":{\"scopeUsageLimit\":1,\"recipientAccountNumber\":\"25116022020000000168811491\",\"recipientName\":\"iohoihoi\",\"recipientAddress\":[\"hiohoiho\"],\"amount\":10.0,\"transferTitle\":\"hiohiohio\",\"system\":\"Elixir\",\"deliveryMode\":\"ExpressD0\",\"currency\":\"PLN\"},\"pis:getPayment\":{\"scopeUsageLimit\":20}},\"scopeGroupType\":\"paymentInformationService\",\"resource\":{\"accountType\":{\"creditCardAccount\":[],\"paymentAccount\":[]},\"type\":\"account\"},\"scopeTimeDuration\":14400,\"throttlingPolicy\":\"psd2Regulatory\"}]"),
                new Claim("state", "71BDF70E61AC2BB1853E857DAD65B7D926ECDCB4FC80C58F7A747963E727E5A9"),
            });

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var aa = new AuthorizationHandler();
            await aa.SendRequest();

            return tokenString;
        }

    }
}