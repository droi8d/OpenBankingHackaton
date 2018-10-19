using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    public class TokenModel
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public long expirationDate { get; set; }
        public string scope { get; set; }
    }
}