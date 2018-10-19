using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models.Scopes
{
    using Newtonsoft.Json;

    public class PrivilegeList
    {
        [JsonProperty("ais:accounts")]
        public AllowedHistoryLong Accounts { get; set; }
    }
}