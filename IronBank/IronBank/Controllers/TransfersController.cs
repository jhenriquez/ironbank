using IronBank.Models;
using System.Linq;
using IronBank.ViewModels;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace IronBank.Controllers
{
    public class TransfersController : IronController
    {
        private ProductService productManager;
        private TransferManager transferManager;
        
        public TransfersController()
        {
            productManager = new ProductService(db);
            transferManager = new TransferManager(db);
        }

        public ActionResult Index()
        {
            return View(
                new AmountTransferViewModel() { AvailableProducts = GetCurrentUserProducts() }
                );
        }

        public ActionResult Execute(AmountTransferViewModel transference) {
            try
            {
                transferManager.SetSource(transference.Source);
                transferManager.SetTarget(transference.Target);
                transferManager.Amount = transference.Amount;
                transferManager.ExecuteTransference();
                ViewBag.Flash = "Transference Completed!";
                return RedirectToAction("Index", "Dashboard");
            }
            catch (InvalidOperationException invalid)
            {
                ModelState.AddModelError("Errors", invalid.Message);
                transference.AvailableProducts = GetCurrentUserProducts();
                return View("Index", transference);
            }
            catch
            {
                return View("error");
            }
        }

        private IList<ProductViewModel> GetCurrentUserProducts()
        {
            return productManager
                    .GetByCustomer(Authentication.CurrentUser.Id)
                    .Select((p) => new ProductViewModel() { Number = p.AccountNumber, Balance = p.Balance })
                    .ToList();
        }
    }
}