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
            return View(payableServicesManager.GetConfiguredServices());
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
    }
}