using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.Formatting.Jsonp;
using log4net.Config;

namespace ApiAirkxCompany
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, new JsonDataTimeConverter());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
            });
            //GlobalConfiguration.Configuration.AddJsonpFormatter(GlobalConfiguration.Configuration.Formatters.JsonForma‌​tter, "callback");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //应用程序启动时，自动加载配置log4Net
            log4net.Config.XmlConfigurator.Configure();
            GlobalConfiguration.Configuration.Filters.Add(new ApiTrackerFilter());
        }
    }
}
