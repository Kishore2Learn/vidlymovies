using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyMovies
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //To enable attribute routing in Controllers
            routes.MapMvcAttributeRoutes();

            ////Conventional routing
            //routes.MapRoute(
            //    name:"MoviesByReleaseDate",
            //    url:"movies/released/{year}/{month}",
            //    defaults:new {Controller="Movies",action="Released" },
            //    constraints: new { year = @"^(201[1-6])",month=@"^([1-9]|[0][1-9]|[0-1][0-2])"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
