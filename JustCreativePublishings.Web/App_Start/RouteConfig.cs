using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JustCreativePublishings.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ReadingMode",
                url: "Read/{id}",
                defaults: new { controller = "Post", action = "ReadingMode", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TagSearch",
                url: "Search/Tag/{id}",
                defaults: new { controller = "Search", action = "SearchByTag", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Profile",
                url: "User/{username}",
                defaults: new { controller = "User", action = "Profile", username = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
