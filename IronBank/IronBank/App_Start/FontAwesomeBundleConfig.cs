using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(IronBank.App_Start.FontAwesomeBundleConfig), "RegisterBundles")]

namespace IronBank.App_Start
{
    public class FontAwesomeBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new StyleBundle("~/Content/font-awesome").Include("~/Content/font-awesome.css"));
        }
    }
}