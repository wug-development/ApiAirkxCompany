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

        //getgjorder
        [HttpGet]
        public HttpResponseMessage GetGJOrder(string cid, int page, int pagenum, string other)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = " and a.dcCompanyID = '" + n + "' and a.dcCompanyID = b.dcCompanyID ";
            if (!string.IsNullOrWhiteSpace(other))
            {
                sqlwhere += " and dcContent like '% " + PageValidate.SQL_KILL(other) + " %' ";
            }
            string sqlfeild = " dcOrderID as orderid,a.dcCompanyID as cid,dcUserName as cname,dcOrderCode as ordercode,(select top 1 dcPerName from T_OrderPerson p where p.dcOrderID=a.dcOrderID) as pername,dcStartCity as scity,dcBackCity as ecity,dcStartDate as sdate,dnTotalPrice as totalprice,a.dtAddTime as addtime,dnStatus as status,a.dcAdminName as adminname ";
            string sql = "select top " + (page * pagenum) + sqlfeild + " from T_Order a,T_Company b where 1=1 " + sqlwhere + " and a.dcOrderID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcOrderID from T_Order a,T_Company b where 1=1 " + sqlwhere + ")";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcOrderID) from T_Order a,T_Company b where 1=1 " + sqlwhere;
                count = Convert.ToDecimal(DbHelperSQL.GetSingle(sqlcount));
            }

            var res = new
            {
                data = dt,
                pagecount = Math.Ceiling(count / pagenum)
            };
            return Utils.pubResult(1, "获取成功", res);
        }


        [HttpGet]
        public HttpResponseMessage GetGJOrderDetail(string id, string cid)
        {
            string _id = PageValidate.SQL_KILL(id);
            string _cid = PageValidate.SQL_KILL(cid);
            string sql = " select * from T_Order where dcOrderID = '"+ _id + "' and dcCompanyID = '"+ _cid + "'; ";
            sql += " select * from T_OrderFlightInfo where dcOrderID = '" + _id + "'; ";
            sql += " select * from T_OrderPerson where dcOrderID = '" + _id + "'; ";
            DataSet ds = DbHelperSQL.Query(sql);
            
            var obj = new
            {
                info = ds.Tables[0],
                flight = ds.Tables[1],
                person = ds.Tables[2]
            };
            return Utils.pubResult(1, "登录成功", obj);
        }

    }
}