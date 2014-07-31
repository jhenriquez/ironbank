using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IronBank.App_Start.AngularBundleConfig), "RegisterBundles")]

namespace IronBank.App_Start
{
    public class AngularBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/angular-route").Include("~/Scripts/angular-route.js"));
        }
    }
}
