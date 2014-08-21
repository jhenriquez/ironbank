using System.Linq;
using System.Web.Mvc;
using IronBank.Models;

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