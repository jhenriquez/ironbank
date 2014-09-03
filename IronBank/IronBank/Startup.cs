using IronBank.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace IronBank
{
    public class Startup
    {
        public static Func<UserManager<User>> UserManagerFactory { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions {
                    AuthenticationType = "Authorization",
                    LoginPath = new PathString("/auth/login"),
                    ExpireTimeSpan = new System.TimeSpan(0,10,0)
                });
        }
    }
}