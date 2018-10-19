using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models.AIS
{
    using System.Web.Helpers;
    using Newtonsoft.Json;
    using OpenBankingApi.Models.Scopes;

    public class AISBase
    {
        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        [JsonProperty("scopeTimeDuration")]
        public int ScopeTimeDuration { get; set; }

        [JsonProperty("throttlingPolicy")]
        public string ThrottlingPolicy { get; set; }

        [JsonProperty("privilegeList")]
        public PrivilegeList PrivilegeList { get; set; }

        [JsonProperty("scopeGroupType")]
        public string ScopeGroupType { get; set; }

        public string GetListOfAccounts(List<string> paymentAccount, List<string> creditCardAccount)
        {
            var ais = new AISBase
            {
                Resource = new Resource
                {
                    Type = "account",
                    AccountType = new AccountType
                    {
                        PaymentAccount = paymentAccount.ToArray(),
                        CreditCardAccount = creditCardAccount.ToArray()
                    }
                },
                ScopeTimeDuration = 600,
                ThrottlingPolicy = "psd2Regulatory",
                PrivilegeList = new PrivilegeList
                {
                    Accounts = new AllowedHistoryLong()
                    {
                        MaxAllowedHistoryLong = 365
                    }
                },
                ScopeGroupType = "accountInformationService"
            };

            return JsonConvert.SerializeObject(ais);
        }
    }
}