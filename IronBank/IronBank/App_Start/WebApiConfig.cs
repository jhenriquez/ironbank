using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IronBank.App_Start.WebApiConfig), "Register")]

namespace IronBank.App_Start
{
    public class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}