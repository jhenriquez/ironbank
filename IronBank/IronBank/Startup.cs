using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace IronBank
{
    public class Startup
    {
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