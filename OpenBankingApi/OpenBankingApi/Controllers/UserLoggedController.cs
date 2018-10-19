using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenBankingApi.Controllers
{
    public class UserLoggedController : Controller
    {
        // GET: UserLogged
        public ActionResult Index(string code, string state, string error)
        {
            var model = new OpenBankingApi.Models.Redirect() {
                Code = code,
                State = state,
                Error= error
            };
            return View(model);
        }
    }
}