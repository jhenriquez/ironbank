using IronBank.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> UserManager = Startup.UserManagerFactory.Invoke();
        private IronBankEntities db = new IronBankEntities();

        [HttpGet]
        public new ActionResult Profile()
        {
            return View(UserManager.FindByName(User.Identity.Name));
        }

        [HttpPost]
        public new ActionResult Profile(EditableUser editedUser)
        {
            var user = UserManager.FindById(editedUser.Id);
            
            UpdateModel<User>(user);

            try
            {
                UserManager.Update(user);
                return View(user);
            }
            catch (DbEntityValidationException validations)
            {    
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(UserManager.FindByName(User.Identity.Name));
        }
    }
}