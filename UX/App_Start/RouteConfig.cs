using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "messages",
                url: "messages/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Messages"
                });

            routes.MapRoute(
                name: "tests",
                url: "tests/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "QaTest"
                });

            routes.MapRoute(
                name: "order",
                url: "order/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Order"
                });

            routes.MapRoute(
                name: "product",
                url: "product/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Product"
                });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
