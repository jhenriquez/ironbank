using IronBank.ServicesModel;
using IronBank.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    [Authorize]
    public class ServicesController : IronController
    {
        private readonly ServiceManager payableServicesManager;

        public ServicesController() 
        {
            payableServicesManager =
                new ServiceManager(db)
                    .SetContextUser(Authentication.CurrentUser);
        }

        public ActionResult Index()
        {
            return View(payableServicesManager
                            .GetConfiguredServices()
                            .Select((cfg) => new ServiceDetailsViewModel()
                            {
                                Contract = cfg.ContractReference,
                                ServiceId = cfg.Id,
                                Provider = cfg.Service.Name,
                                PaymentAmount = cfg.Billing.Balance
                            }).ToList()
                            );
        }

        [HttpGet]
        public ActionResult Configure()
        {
            return View(new ServiceConfiguration() { AvailableServices = payableServicesManager.GetAvailableServices() });
        }

        [HttpPost]
        public ActionResult Configure(ServiceConfiguration model)
        {
            try 
            {
                payableServicesManager.Configure(model.ServiceId, model.ContractReference);
                return RedirectToAction("Index");
            } 
            catch (InvalidOperationException error) 
            {
                ModelState.AddModelError("Configuration", error.Message);
                model.AvailableServices = db.AvailableServices.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Pay(Int32 Id)
        {
            var service = payableServicesManager.GetConfiguredServices().Where(s => s.Id == Id).FirstOrDefault();

            if (service == null)
                return View("error");

            return View(new ServiceDetailsViewModel() {
                ServiceId = service.Id,
                Contract = service.ContractReference,
                PaymentAmount = service.Billing.Amount,
                Provider = service.Service.Name
            });
        }

        [HttpPost]
        public ActionResult Pay(ServiceDetailsViewModel model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            var service = payableServicesManager.GetConfiguredServices().Where(s => s.Id == Id).FirstOrDefault();

            if (service == null)
                return View("error");

            return View(new ServiceDetailsViewModel()
            {
                ServiceId = service.Id,
                Contract = service.ContractReference,
                PaymentAmount = service.Billing.Amount,
                Provider = service.Service.Name
            });
        }
    }
}