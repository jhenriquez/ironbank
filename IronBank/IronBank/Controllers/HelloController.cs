using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult World()
        {
            return View();
        }
    }
}