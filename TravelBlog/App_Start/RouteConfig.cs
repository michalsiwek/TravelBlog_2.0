﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Entry",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Entries", action = "Entry", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Filter",
                url: "{controller}/{action}/{categoryName}/{page}",
                defaults: new { controller = "Entries", action = "Filter", categoryName = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Entries",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Entries", action = "Index", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Gallery",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Galleries", action = "Gallery", id = UrlParameter.Optional }
            );
        }
    }
}
