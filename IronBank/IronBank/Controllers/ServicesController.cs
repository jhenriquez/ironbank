using IronBank.Models;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IronBank.Controllers
{
    [Authorize]
    public class ServicesController : IronController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Configure()
        {
            return View(db.AvailableServices.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Configure(ServiceConfiguration model)
        {
            var newService = new ConfiguredService();

            UpdateModel<ConfiguredService>(newService);

            newService.User = await UserManager.FindByNameAsync(User.Identity.Name);

            var isExistentConfiguration = db
                .ConfiguredServices.Where((s) =>
                    (s.ContractReference == newService.ContractReference && s.UserId == newService.User.Id) ||
                    (s.Service.Id == newService.ServiceId && s.ContractReference == newService.ContractReference && s.UserId == newService.User.Id)).Count() > 0;

            if (isExistentConfiguration)
            {
                ModelState.AddModelError("Configuration", "Service Contract Already In Place.");
                return View();
            }

            db.ConfiguredServices.Add(newService);
            db.SaveChanges();

            return View("Index");
        }
    }
}