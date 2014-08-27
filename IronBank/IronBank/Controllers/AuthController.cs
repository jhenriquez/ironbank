using IronBank.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace IronBank.Controllers
{   
    public class AuthController : Controller
    {
        private UserManager<User> UserManager;

        public AuthController()
        {
            UserManager = Startup.UserManagerFactory.Invoke();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInformation login)
        {
            if (!ModelState.IsValid) return View();

            var user = await UserManager.FindByEmailAsync(login.Username);                
            
            if(user == null)
            {
                ModelState.AddModelError("LoginError", "Invalid Username or Password");
                return View();
            }

            var identity = await UserManager.CreateIdentityAsync(user, "Authorization");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (string.IsNullOrEmpty(login.ReturnUrl)) 
                return Redirect(Url.Action("Index", "Dashboard"));

            return Redirect(login.ReturnUrl);
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