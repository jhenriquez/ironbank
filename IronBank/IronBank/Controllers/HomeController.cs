using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }
    }
}