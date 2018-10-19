using System.Collections.Generic;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using Jose;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenBankingApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly X509Certificate2 _certificate = new X509Certificate2();
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
            var payload = new Dictionary<string, string>()
            {
                { "sub", "team6@bankmillennium.pl" },
                { "response_code", "Code" },
                { "redirect_uri", "http://localhost" },
                { "scope", "[{\"resource\":{\"type\":\"account\",\"accountType\":{\"paymentAccount\":[],\"creditCardAccount\":[]}},\"scopeTimeDuration\":600,\"throttlingPolicy\":\"psd2Regulatory\",\"privilegeList\":{\"ais:accounts\":{\"maxAllowedHistoryLong\":365}},\"scopeGroupType\":\"accountInformationService\"}]" },
                { "state", "22137C25EE4A3BB48AF76FA7938EB6C340C668DC6204CE5B27BA7BE8433C6F8C" }
            };

            var path = "D:/cert/bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
            var cert = RequestSigningHandler.ReadFile(path);
            _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);
            string tokenSigned = JWT.Encode(payload, _certificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);

            var client = new HttpClient();
            var result = await client.PostAsync("https://bm-devportal-testwebapp03.azurewebsites.net/authorization", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("jwt", tokenSigned)
            }));

            return await result.Content.ReadAsStringAsync();
        }
    }
}