using IronBank.Models;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IronBank.Controllers
{   
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginInformation user)
        {
            var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, "Pablo"),
                        new Claim(ClaimTypes.Email, "p@batida.com"),
                        new Claim(ClaimTypes.Country, "Santo Domingo")
                    },
                    "Authorization");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (string.IsNullOrEmpty(user.ReturnUrl)) 
                return Redirect(Url.Action("Index", "Dashboard"));

            return Redirect(user.ReturnUrl);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("Authorization");
            return Redirect("/");
        }
    }
}