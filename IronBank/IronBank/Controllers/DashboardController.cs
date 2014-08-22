using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Token = Request.Cookies["Token"].Value;
            return View("Summary");
        }
    }
}