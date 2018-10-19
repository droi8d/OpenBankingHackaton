using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models.Scopes
{
    using Newtonsoft.Json;

    public class AllowedHistoryLong
    {
        [JsonProperty("maxAllowedHistoryLong")]
        public int MaxAllowedHistoryLong { get; set; }
    }
}