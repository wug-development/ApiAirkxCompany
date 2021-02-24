using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiAirkxCompany
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var cors = new EnableCorsAttribute("http://www.airkx.cn,http://m.airkx.cn,http://vip.airkx.cn,http://cp.airkx.cn", "*", "*");
            config.EnableCors(cors);


            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 格式化时间
            ReturnDateFormatInJsonSerializersSettings();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter() {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            });
        }

        private static void ReturnDateFormatInJsonSerializersSettings()
        {
            var jsonSerializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            jsonSerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
