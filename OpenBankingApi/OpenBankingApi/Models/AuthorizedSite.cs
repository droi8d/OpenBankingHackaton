using System;

namespace OpenBankingApi.Models
{
    public  class AuthorizedSite
    {
        public string BankName { get; set; }
        public string accountId { get; set; }
        public DateTime authorizationDate { get; set; }
    }
}