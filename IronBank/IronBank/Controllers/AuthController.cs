using IronBank.Models;
using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace IronBank.Controllers
{
    public class User : IPrincipal, IIdentity
    {
        public Int32 CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Customer Customer { get; set; }

        public IIdentity Identity
        {
            get { return this; }
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public string AuthenticationType
        {
            get { return "batida"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return "Pablo"; }
        }
    }

    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login(User user)
        {
            Response.Cookies["Token"].Value = "343243243243243432432432";
            Response.Cookies["Token"].Expires = DateTime.Now.AddHours(1);
            return Redirect("/Dashboard/Index");
        }
    }
}