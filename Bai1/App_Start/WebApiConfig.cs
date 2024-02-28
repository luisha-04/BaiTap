using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bai1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "OptimizeApi",
            //    routeTemplate: "api/{custom}/{id}",
            //    defaults: new { Controller = "OptimizeTwo", id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "OptimizeApi",
                routeTemplate: "api/{Controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
