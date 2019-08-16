using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ApiAirkxCompany.Controllers
{
    public class OrderListController : ApiController
    {
        // GET api/<controller>/5
        public HttpResponseMessage GetNowOrder(int page, int pagenum)
        {
            string sdate = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            string edate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            string sql = " select top " + (page * pagenum) + " a.*,b.JCPY,c.PName,d.StartCity,d.EndCity,d.PNR,d.StartDate from Airkx_Order a,Airkx_UserInfo b,Airkx_GNPeople c,Airkx_GNDetail d  where a.OrderID not in (";
            sql += " select top " + ((page-1) * pagenum) + " OrderID from dbo.Airkx_Order  where OrderTime > '" + sdate + "' and OrderTime < '" + edate + "' order by OrderTime desc)";
            sql += " and OrderTime > '" + sdate + "' and OrderTime < '" + edate + "' and a.UserName=b.UserName and a.OrderID=c.OrderID and a.OrderID=d.OrderID order by a.OrderTime desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            object count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (OrderID) from dbo.Airkx_Order  where OrderTime > '" + sdate + "' and OrderTime < '" + edate + "'";
                count = DbHelperSQL.GetSingle(sqlcount);
            }

            var obj = new {
                pagecount = count,
                data = dt
            };
            return Utils.pubResult(1, "获取成功", obj);
        }

        public HttpResponseMessage delOrders(string oids)
        {
            string o = PageValidate.SQL_KILL(oids);
            string sql = "delete from Airkx_Order where OrderID in (" + o + ")";
            int count = DbHelperSQL.ExecuteSql(sql);
            return Utils.pubResult(1, "删除成功", count);
        }

    }
}