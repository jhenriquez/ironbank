using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using IronBank.ViewModels;

namespace IronBank.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            return Redirect("/Dashboard/Index");
        }
    }
}