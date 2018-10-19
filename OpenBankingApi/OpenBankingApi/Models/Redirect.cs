using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    public class Redirect
    {
        public string Code{ get; set; }
        public string State { get; set; }
        public string Error { get; set; }
    }
}