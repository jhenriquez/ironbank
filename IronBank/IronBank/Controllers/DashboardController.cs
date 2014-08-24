using System.Web.Mvc;

namespace IronBank.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View("Summary");
        }
    }
}