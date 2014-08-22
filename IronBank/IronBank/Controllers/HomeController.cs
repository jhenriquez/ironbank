using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Ironbank: Login";
            return View("Login");
        }
    }
}