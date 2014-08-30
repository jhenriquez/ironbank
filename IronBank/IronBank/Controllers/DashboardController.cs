using System.Web.Mvc;
using System.Linq;
using IronBank.Models;

namespace IronBank.Controllers
{
    [Authorize]
    public class DashboardController : IronController
    {
        public ActionResult Index()
        {
            var products = new ProductService(db).GetByCustomer(
                                                    db.Users.Where(u => u.UserName == User.Identity.Name)
                                                    .FirstOrDefault()
                                                    .Id);
            return View(products);
        }
    }
}