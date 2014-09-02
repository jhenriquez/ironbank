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
            return View(
                db.ConfiguredServices.Where((s) => s.User.UserName ==  User.Identity.Name) // I know... needs refactoring...
                );
        }

        [HttpGet]
        public ActionResult Configure()
        {
            return View(new ServiceConfiguration() { AvailableServices = db.AvailableServices.ToList() });
        }

        [HttpPost]
        public async Task<ActionResult> Configure(ServiceConfiguration model)
        {
            var newService = new ConfiguredService();

            UpdateModel<ConfiguredService>(newService);

            newService.User = db.Users.Where((u) => u.UserName == User.Identity.Name).FirstOrDefault();

            var isExistentConfiguration = db
                .ConfiguredServices.Where((s) =>
                    (s.ContractReference == newService.ContractReference && s.UserId == newService.User.Id) ||
                    (s.Service.Id == newService.ServiceId && s.ContractReference == newService.ContractReference && s.UserId == newService.User.Id)).Count() > 0;

            if (isExistentConfiguration)
            {
                ModelState.AddModelError("Configuration", "Service Contract Already In Place.");
                model.AvailableServices = db.AvailableServices.ToList();
                return View(model);
            }

            db.ConfiguredServices.Add(newService);
            db.SaveChanges();

            return View("Index");
        }
    }
}