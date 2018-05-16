using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class AccountMyController : Controller
    {
        // GET: AccountView
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Registr()
        {
            return View();
        }
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}