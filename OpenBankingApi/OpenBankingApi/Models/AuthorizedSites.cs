using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenBankingApi.Models
{
    public  class AuthorizedSites
    {
        public List<AuthorizedSite> authorizedSites { get; set; }

        public AuthorizedSites()
        {

           authorizedSites = new List<AuthorizedSite>() {
               new AuthorizedSite() {
                   BankName = "Bank Millennium",
                   accountId = "0008765576",
                   authorizationDate = new DateTime(2018,10,19),
           },

               new AuthorizedSite() {
                   BankName = "PKO",
                   accountId = "009875642548",
                   authorizationDate = new DateTime(2018,10,20),
           },
               //new AuthorizedSite() {
               //SiteName = "MojaApteka.pl",
               //authorizationDate = new DateTime(2018,10,10)
               //}
           };
        }
    }
}