using System.Web.Mvc;
using System.Web.Routing;

namespace NopCommerce.Api.SampleApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Submit",
               url: "submit",
               defaults: new { controller = "Authorization", action = "Submit" },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
               name: "GetAccessToken",
               url: "token",
               defaults: new { controller = "Authorization", action = "GetAccessToken" },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
               name: "RefreshAccessToken",
               url: "refresh_token",
               defaults: new { controller = "Authorization", action = "RefreshAccessToken" },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
               name: "GetCustomers",
               url: "customers",
               defaults: new { controller = "Customers", action = "GetCustomers" },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
               name: "UpdateCustomer",
               url: "updatecustomer/{customerId}",
               defaults: new { controller = "Customers", action = "UpdateCustomer", customerId = UrlParameter.Optional },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
               name: "TryApi",
               url: "try-api",
               defaults: new { controller = "Api", action = "TryApi", id = UrlParameter.Optional },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );

            routes.MapRoute(
              name: "ApiGet",
              url: "api/{endpoint}/{param1}/{param2}/{param3}",
              defaults: new
              {
                  controller = "Api",
                  action = "Get",
                  endpoint = "",
                  param1 = UrlParameter.Optional,
                  param2 = UrlParameter.Optional,
                  param3 = UrlParameter.Optional
              },
              namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" },
              constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "ApiPost",
                url: "api/{endpoint}/{param1}/{param2}/{param3}",
                defaults: new
                {
                    controller = "Api",
                    action = "Post",
                    endpoint = "",
                    param1 = UrlParameter.Optional,
                    param2 = UrlParameter.Optional,
                    param3 = UrlParameter.Optional
                },
                namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            routes.MapRoute(
               name: "ApiPut",
               url: "api/{endpoint}/{param1}/{param2}/{param3}",
               defaults: new
               {
                   controller = "Api",
                   action = "Put",
                   endpoint = "",
                   param1 = UrlParameter.Optional,
                   param2 = UrlParameter.Optional,
                   param3 = UrlParameter.Optional
               },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" },
               constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
            );

            routes.MapRoute(
               name: "ApiDelete",
               url: "api/{endpoint}/{param1}/{param2}/{param3}",
               defaults: new
               {
                   controller = "Api",
                   action = "Delete",
                   endpoint = "",
                   param1 = UrlParameter.Optional,
                   param2 = UrlParameter.Optional,
                   param3 = UrlParameter.Optional
               },
               namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" },
               constraints: new { httpMethod = new HttpMethodConstraint("DELETE") }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authorization", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NopCommerce.Api.SampleApplication.Controllers" }
            );
        }
    }
}
