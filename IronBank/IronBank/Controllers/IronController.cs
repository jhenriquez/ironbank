using IronBank.Models;
using IronBank.Services;
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
            Authentication = new AuthenticationService();
        }

        public IronController(IronBankEntities context)
        {
            if (context == null) 
                throw new ArgumentNullException("IronController: context can not be null.");
            db = context;
            Authentication = new AuthenticationService(db);
        }

        protected IronBankEntities db { get; set; }
        protected AuthenticationService Authentication { get; set; }
    }
}












