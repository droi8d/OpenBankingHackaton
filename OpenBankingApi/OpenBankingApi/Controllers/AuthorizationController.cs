using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenBankingApi.Models;


namespace OpenBankingApi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult Index()
        {
            var model = new AuthorizedSites();
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}