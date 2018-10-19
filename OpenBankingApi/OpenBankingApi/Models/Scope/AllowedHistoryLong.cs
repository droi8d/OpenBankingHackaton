using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    using Newtonsoft.Json;

    public class AllowedHistoryLong
    {
        public AllowedHistoryLong()
        {
            this.MaxAllowedHistoryLong = 365;
        }

        [JsonProperty("maxAllowedHistoryLong")]
        public int MaxAllowedHistoryLong { get; set; }
    }
}