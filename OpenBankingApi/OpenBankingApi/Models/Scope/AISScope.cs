namespace OpenBankingApi.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class AISScope
    {
        private AISScope()
        {
        }

        public AISScope(bool useAccounts, bool useTransactionsPending, bool useTransactionsRejected, bool useHolds,
            bool useTransationDetail, bool useTransactionsDone)
        {
            this.UseAccounts = useAccounts;
            this.UseTransactionsPending = useTransactionsPending;
            this.UseTransactionsRejected = useTransactionsRejected;
            this.UseHolds = useHolds;
            this.UseTransationDetail = useTransationDetail;
            this.UseTransactionsDone = useTransactionsDone;
        }

        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        [JsonProperty("scopeTimeDuration")]
        public int ScopeTimeDuration { get; set; }

        [JsonProperty("throttlingPolicy")]
        public string ThrottlingPolicy { get; set; }

        [JsonProperty("privilegeList")]
        public Dictionary<string, AllowedHistoryLong> PrivilegeList { get; set; }

        [JsonProperty("scopeGroupType")]
        public string ScopeGroupType { get; set; }

        public bool UseAccounts { get; set; }
        public bool UseTransactionsPending { get; set; }
        public bool UseTransactionsRejected { get; set; }
        public bool UseHolds { get; set; }
        public bool UseTransationDetail { get; set; }
        public bool UseTransactionsDone { get; set; }

        public string GetAISScope(List<string> paymentAccount, List<string> creditCardAccount)
        {
            var ais = new AISScope
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
                PrivilegeList = this.GetPrivilegeList(),
                ScopeGroupType = "accountInformationService"
            };

            return JsonConvert.SerializeObject(ais);
        }

        private Dictionary<string, AllowedHistoryLong> GetPrivilegeList()
        {
            var dict = new Dictionary<string, AllowedHistoryLong>();

            if (this.UseAccounts)
            {
                dict.Add("ais:accounts", new AllowedHistoryLong());
            }

            if (this.UseTransactionsPending)
            {
                dict.Add("ais:transactionsPending", new AllowedHistoryLong());
            }

            if (this.UseTransactionsRejected)
            {
                dict.Add("ais:transactionsRejected", new AllowedHistoryLong());
            }

            if (this.UseHolds)
            {
                dict.Add("ais:holds", new AllowedHistoryLong());
            }

            if (this.UseTransationDetail)
            {
                dict.Add("ais:transationDetail", new AllowedHistoryLong());
            }

            if (this.UseTransactionsDone)
            {
                dict.Add("ais:transactionsDone", new AllowedHistoryLong());
            }

            return dict;
        }
    }
}