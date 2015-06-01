using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TradeWorkstation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //shared
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Resources/Bootstrap/css/bootstrap.min.css",
                "~/Resources/Bootstrap/css/bootstrap-datetimepicker.min.css",
                "~/Resources/Trunk/trunk.css",
                "~/Resources/Site/css/common.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Resources/JQuery/jquery-1.11.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Resources/Bootstrap/js/bootstrap.js",
                "~/Resources/JQuery/jquery.scrollLoading.js",
                "~/Resources/Trunk/trunk.js",
                "~/Resources/Bootstrap/js/bootstrap-datetimepicker.min.js",
                "~/Resources/Bootstrap/js/datetimepicker.config.js",
                "~/Resources/Site/js/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie8").Include(
                "~/Resources/Bootstrap/js/modernizr-2.6.2.js",
                "~/Resources/Bootstrap/js/respond.js"));
            //index
            bundles.Add(new ScriptBundle("~/bundles/index_scripts").Include(
                "~/Resources/Site/js/bzbanner.min.js",
                "~/Resources/Site/js/index.js"));
            bundles.Add(new StyleBundle("~/bundles/index_styles").Include(
                "~/Resources/Site/css/index.css"));
            //publish
            bundles.Add(new StyleBundle("~/bundles/publish_styles").Include(
                "~/Resources/Site/css/publish.css"));
            //add
            bundles.Add(new StyleBundle("~/bundles/add_styles").Include(
                "~/Resources/Site/css/form.css"));
            //show
            bundles.Add(new StyleBundle("~/bundles/show_styles").Include(
                "~/Resources/Site/css/show.css"));
            //detail
            bundles.Add(new ScriptBundle("~/bundles/detail_scripts").Include(
                "~/Resources/Site/js/detail.js"));
        }
    }
}