using IronBank.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IronBank.Services
{
    public class AuthenticationService
    {
        private UserManager<User> UserManager;
        private User _currentUser = null;

        public AuthenticationService(IdentityDbContext<User> context)
        {
            if (context == null)
                throw new ArgumentNullException("AuthenticationService: context can not be null.");
            UserManager = new UserManager<User>(new UserStore<User>(context));
        }

        public AuthenticationService() : this(new IronBankEntities()) { }

        public void LogIn(String login, String password) 
        {
            var user = UserManager.Find(login, password);

            if (user == null)
                throw new ArgumentException("Invalid username or password.");

            var identity = UserManager.CreateIdentity(user, "Authorization");

            HttpContext.Current.Request.GetOwinContext().Authentication.SignIn(identity);
        }
         
        public void LogOut()
        {
            HttpContext.Current.Request.GetOwinContext().Authentication.SignOut("Authorization");
        }

        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = UserManager.FindByName(HttpContext.Current.Request.GetOwinContext().Authentication.User.Identity.Name);
                return _currentUser;
            }
        }
    }
}