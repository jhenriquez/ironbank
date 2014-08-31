using IronBank.Models;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    [Authorize]
    public class TransactionsController : IronController
    {
        public ActionResult Index(string id)
        {
            var tnx = new TransactionService(db).GetByProductAccount(id);
            return View(tnx
                );
        }
    }
}