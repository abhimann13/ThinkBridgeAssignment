using ShopBridge.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShopBridge.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Get", id = RouteParameter.Optional }
            );

            config.Filters.Add(new GlobalExceptionHandlerAttribute());
        }
    }
}
