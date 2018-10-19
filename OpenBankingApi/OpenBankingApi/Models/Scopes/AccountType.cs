using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models.Scopes
{
    using Newtonsoft.Json;

    public class AccountType
    {
        [JsonProperty("paymentAccount")]
        public string[] PaymentAccount { get; set; }

        [JsonProperty("creditCardAccount")]
        public string[] CreditCardAccount { get; set; }
    }
}