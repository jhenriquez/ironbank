using IronBank.Models;
using IronBank.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class UserController : IronController
    {
        [HttpGet]
        public new ActionResult Profile()
        {
            return View(Authentication.CurrentUser);
        }

        [HttpPost]
        public new ActionResult Profile(EditableUser editedUser)
        {
            var user = Authentication.CurrentUser;

            UpdateModel<User>(user);

            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return View(user);
            }
            catch (DbEntityValidationException validations)
            {
                foreach (var errors in validations.EntityValidationErrors)
                    foreach (var err in errors.ValidationErrors)
                        ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(Authentication.CurrentUser);
        }
    }
}