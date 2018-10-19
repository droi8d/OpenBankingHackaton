using System.Collections.Generic;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using Jose;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

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

        private static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }


        [HttpGet]
        public async Task<ActionResult> Token()
        {
            var payload = new Dictionary<string, string>()
            {
                { "sub", "team6@bankmillennium.pl" },
                { "response_code", "Code" },
                { "redirect_uri", "http://localhost:55647/UserLogged" },
                { "scope", "[{\"resource\":{\"type\":\"account\",\"accountType\":{\"paymentAccount\":[],\"creditCardAccount\":[]}},\"scopeTimeDuration\":600,\"throttlingPolicy\":\"psd2Regulatory\",\"privilegeList\":{\"ais:accounts\":{\"maxAllowedHistoryLong\":365}},\"scopeGroupType\":\"accountInformationService\"}]" },
                { "state", "22137C25EE4A3BB48AF76FA7938EB6C340C668DC6204CE5B27BA7BE8433C6F8C" }
            };

            var path = @"C:\Certyficates\bank.millennium.psd2.sandbox.signing.hackathon.team.06.pfx";
            var cert = ReadFile(path);
            _certificate.Import(cert, "millennium", X509KeyStorageFlags.DefaultKeySet);
            string tokenSigned = JWT.Encode(payload, _certificate.GetRSAPrivateKey(), JwsAlgorithm.RS256);

            var client = new HttpClient();
            var result = await client.PostAsync("https://bm-devportal-testwebapp03.azurewebsites.net/authorization", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("jwt", tokenSigned)
            }));

            return Redirect(result.RequestMessage.RequestUri.ToString());
        }
    }
}