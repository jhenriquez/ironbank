using System.Linq;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult World()
        {
            var db = new IronBank.Models.IronBankEntities();
            var products = (from p in db.Products select p).ToList();
            return View(products);
        }
    }
}