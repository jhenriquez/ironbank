using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IronBank.App_Start.JQueryBundleConfig), "RegisterBundles")]

namespace IronBank.App_Start
{
    public class JQueryBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery-1.9.1").Include("~/Scripts/jquery-1.9.1.js"));
        }
    }
}
