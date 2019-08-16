using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiAirkxCompany
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("http://www.dakehu.com:9999", "*", "*");
            config.EnableCors(cors);

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
