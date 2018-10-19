using System;

namespace OpenBankingApi.Models
{
    public  class AuthorizedSite
    {
        public string SiteName { get; set; }
        public DateTime authorizationDate { get; set; }
    }
}