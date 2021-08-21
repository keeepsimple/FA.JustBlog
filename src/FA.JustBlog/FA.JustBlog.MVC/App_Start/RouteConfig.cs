using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Posts",
                "Posts/{year}/{month}/{urlSlug}",
                new { controller = "Posts", action = "Details" },
                new { year = @"\d{4}", month = @"\d{2}" }
                );

            routes.MapRoute(
                "Categories",
                "Categories/{urlSlug}",
                new { controller = "Categories", action = "Details" }
                );

            routes.MapRoute(
                "Tags",
                "Tags/{urlSlug}",
                new { controller = "Tags", action = "Details" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
