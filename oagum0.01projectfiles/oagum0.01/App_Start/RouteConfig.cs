using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using oagum0._01.JsonMigration;

namespace oagum0._01
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            JsonMigration.JsonMigrator test; 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
