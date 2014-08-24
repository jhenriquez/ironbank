using IronBank.Models;
using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace IronBank.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login()
        {
            return Redirect("/Dashboard/Index");
        }
    }
}