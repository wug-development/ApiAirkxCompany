using System.Web;
using System.Web.Mvc;

namespace ApiAirkxCompany
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //API日志
            filters.Add(new ApiTrackerFilter());
            //监控日志
            filters.Add(new TrackerFilter());

            filters.Add(new HandleErrorAttribute());
        }
    }
}
