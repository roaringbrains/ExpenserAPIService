﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ExpenserAPIService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Formatters()
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);



            //Below code is useful but not working as expected.
            //var setJsonType = config.Formatters.JsonFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/json");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Add(setJsonType);

        }
    }
}
