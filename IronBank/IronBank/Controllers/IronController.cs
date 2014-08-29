using IronBank.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IronBank.Controllers
{
    public abstract class IronController : Controller
    {
        public IronController()
        {
            db = new IronBankEntities();
            UserManager = Startup.UserManagerFactory.Invoke();
        }

        public IronController(IronBankEntities context)
        {
            if (context == null) 
                throw new ArgumentNullException("IronController: context can not be null.");
        }

        protected IronBankEntities db { get; set; }
        protected UserManager<User> UserManager { get; set; }
    }
}