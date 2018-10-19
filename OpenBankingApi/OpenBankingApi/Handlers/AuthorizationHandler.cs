using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace OpenBankingApi.Handlers
{
    public class AuthorizationHandler : RequestSigningHandler
    {
        public async Task<HttpResponseMessage> SendRequest()
        {
            object a = new
            {
                sub = "TPP.NEWINT",
                response_code = "Code",
                redirect_uri = "http://localhost",
                scope =
                "[{\"privilegeList\":{\"pis:domestic\":{\"scopeUsageLimit\":1,\"recipientAccountNumber\":\"25116022020000000168811491\",\"recipientName\":\"iohoihoi\",\"recipientAddress\":[\"hiohoiho\"],\"amount\":10.0,\"transferTitle\":\"hiohiohio\",\"system\":\"Elixir\",\"deliveryMode\":\"ExpressD0\",\"currency\":\"PLN\"},\"pis:getPayment\":{\"scopeUsageLimit\":20}},\"scopeGroupType\":\"paymentInformationService\",\"resource\":{\"accountType\":{\"creditCardAccount\":[],\"paymentAccount\":[]},\"type\":\"account\"},\"scopeTimeDuration\":14400,\"throttlingPolicy\":\"psd2Regulatory\"}]",
                state = "71BDF70E61AC2BB1853E857DAD65B7D926ECDCB4FC80C58F7A747963E727E5A9"
            };

            var json = JsonConvert.SerializeObject(a);
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://bm-devportal-testwebapp03.azurewebsites.net/authorization"),
                Content = content
            };

            var response = await base.SendAsync(request, CancellationToken.None);
            return response;
        }
    }
}