using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TradeWorkstation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();//mvc5
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            #region 用户查询求购二级搜索路由配置
            routes.MapRoute(
                name: "BuySearch",
                url: "Buy/search/Order/{order}/Type/{type}/Page/{page}",
                defaults: new { controller ="Buy",action="Index"},
                 constraints: new { order = @"\d", page = @"[1-9][0-9]*" }
                );
            #endregion
        }
    }
}
