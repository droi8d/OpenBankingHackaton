using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    using Newtonsoft.Json;

    public class Resource
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accountType")]
        public AccountType AccountType { get; set; }
    }
}