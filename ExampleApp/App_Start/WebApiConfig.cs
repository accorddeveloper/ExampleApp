using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ExampleApp.Infrastructure;

namespace ExampleApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // configure Dependency Injection
            config.DependencyResolver = new NinjectResolver();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
