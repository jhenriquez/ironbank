using System.Linq;
using System.Web.Mvc;
using IronBank.Models;

namespace IronBank.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult World()
        {
            var db = new IronBank.Models.IronBankEntities();
            var products = (from p in db.Products select p).ToList();
            var productService = new ProductService();
            productService.Save(new Product() { Type = ProductType.CreditCard, Balance = 500, Currency = ProductCurrency.Dollars });
            return View(products);
        }
    }
}