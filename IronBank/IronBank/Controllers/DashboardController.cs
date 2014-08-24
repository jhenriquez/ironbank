using System.Web.Mvc;

namespace IronBank.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.User = User.Identity.Name;
            return View("Summary");
        }
    }
}