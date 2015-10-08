﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarrierProj
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
                "UserRatingCreate",
                "UserRating/{action}/{carrierID}",
                new { controller = "UserRating", action = "Create", carrierID = 0}
            );

            routes.MapRoute(
                "UserRatingEdit",
                "UserRating/{action}/{id}/{carrierID}",
                new { controller = "UserRating", action = "Edit", id = UrlParameter.Optional, carrierID = 0 }
            );
        }
    }
}
