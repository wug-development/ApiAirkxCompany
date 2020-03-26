using Newtonsoft.Json.Converters;
using System.Web.Http;
using System.Web.Mvc;
using WebApiContrib.Formatting.Jsonp;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Text;

namespace ApiAirkxCompany
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            var config = GlobalConfiguration.Configuration;
            GlobalConfiguration.Configuration.AddJsonpFormatter(config.Formatters.JsonForma‌​tter, "callback");
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
            });

            //应用程序启动时，自动加载配置log4Net
            log4net.Config.XmlConfigurator.Configure();
            GlobalConfiguration.Configuration.Filters.Add(new ApiTrackerFilter());
            GlobalConfiguration.Configuration.Filters.Add(new JsonCallbackAttribute());
        }
    }

    public class JsonCallbackAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private const string CallbackQueryParameter = "callback";

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var callback = string.Empty;
            if (IsJsonp(out callback))
            {
                var jsonBuilder = new StringBuilder(callback);
                jsonBuilder.AppendFormat("({0})", context.Response.Content.ReadAsStringAsync().Result);
                context.Response.Content = new StringContent(jsonBuilder.ToString());
            }
            base.OnActionExecuted(context);
        }

        private bool IsJsonp(out string callback)
        {
            callback = System.Web.HttpContext.Current.Request.QueryString[CallbackQueryParameter];
            return !string.IsNullOrEmpty(callback);
        }
    }

}
