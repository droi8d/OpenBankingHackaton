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
                   SiteName = "hazard.com",
                   authorizationDate = new DateTime(2018,10,10)
           },
               new AuthorizedSite() {
               SiteName = "MojaApteka.pl",
               authorizationDate = new DateTime(2018,10,10)
               }
           };
        }
    }
}