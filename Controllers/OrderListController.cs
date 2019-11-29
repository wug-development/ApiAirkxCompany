﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Collections;

namespace ApiAirkxCompany.Controllers
{
    public class OrderListController : ApiController
    {
        #region 获取今日订单
        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetNowOrder(int page, int pagenum)
        {
            string sdate = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            string edate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            string sql = " * from T_Order a where dtAddTime > '" + sdate + "' and dtAddTime < '" + edate + "' or dnStatus=0 ";
            string orderby = " order by a.dtAddTime desc ";
            sql = Utils.createPageSql(sql, orderby, page, pagenum);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            object count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcOrderID) from T_Order where dtAddTime > '" + sdate + "' and dtAddTime < '" + edate + "' or dnStatus=0 ";
                count = DbHelperSQL.GetSingle(sqlcount);
            }

            var obj = new
            {
                pagecount = count,
                data = dt
            };
            return Utils.pubResult(1, "获取成功", obj);
        }
        #endregion

        #region 删除订单
        [HttpGet]
        public HttpResponseMessage delOrders(string oids)
        {
            string o = PageValidate.SQL_KILL(oids);
            string[] arr = o.Split(',');
            string ids = "'1'";
            for (int i = 0; i < arr.Length; i++)
            {
                ids += ",'" + arr[i] + "'";
            }
            try
            {
                ArrayList sqls = new ArrayList();
                sqls.Add("delete from T_Order where dcOrderID in (" + ids + ") and dnStatus=0 ");
                sqls.Add("delete from T_OrderFlightInfo where dcOrderID in (" + ids + ")");
                sqls.Add("delete from T_OrderPerson where dcOrderID in (" + ids + ")");

                DbHelperSQL.ExecuteSqlTran(sqls);
                return Utils.pubResult(1, "删除成功", 1);
            }
            catch
            {
                return Utils.pubResult(0, "删除失败", "");
            }
        }

        #endregion

        #region 获取订单列表
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

        #endregion

        #region 获取订单列表
        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="page"></param>
        /// <param name="pagenum"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOrderList(string cid, int type, string sdate, string edate, string fname, string ftno, int page, int pagenum)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = " and a.dcCompanyID = '" + n + "' and a.dcCompanyID = b.dcCompanyID ";
            if (type == 0 || type == 1)
            {
                sqlwhere += "  and a.dnOrderType=" + type + " ";
            }
            if (!string.IsNullOrWhiteSpace(sdate))
            {
                sqlwhere += " and a.dtAddTime > '" + PageValidate.SQL_KILL(sdate) + "' ";
            }
            if (!string.IsNullOrWhiteSpace(edate))
            {
                sqlwhere += " and a.dtAddTime < '" + PageValidate.SQL_KILL(edate) + "' ";
            }
            if (!string.IsNullOrWhiteSpace(fname))
            {
                sqlwhere += " and a.dcLinkName = '" + PageValidate.SQL_KILL(fname) + "' ";
            }
            if (!string.IsNullOrWhiteSpace(ftno))
            {
                sqlwhere += " and a.dcTicketNO = '" + PageValidate.SQL_KILL(ftno) + "' ";
            }
            string sqlfeild = " dcOrderID as orderid,a.dnOrderType as ordertype,a.dcCompanyID as cid,dcUserName as cname,dcOrderCode as ordercode,a.dcLinkName as pername,dcStartCity as scity,dcBackCity as ecity,dcStartDate as sdate,dnTotalPrice as totalprice,a.dtAddTime as addtime,dnStatus as status,a.dnOrderStatus as orderstatus,a.dcAdminName as adminname ";
            string sql = "select top " + (page * pagenum) + sqlfeild + " from T_Order a,T_Company b where 1=1 " + sqlwhere + " and a.dcOrderID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcOrderID from T_Order a,T_Company b where 1=1 " + sqlwhere + " order by dtAddTime desc) order by dtAddTime desc";
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
                pagecount = count
            };
            return Utils.pubResult(1, "获取成功", res);
        }

        #endregion

        #region 获取订单详情
        [HttpGet]
        public HttpResponseMessage GetGJOrderDetail(string id, string cid)
        {
            string _id = PageValidate.SQL_KILL(id);
            string _cid = PageValidate.SQL_KILL(cid);
            string sql = " select * from T_Order where dcOrderID = '" + _id + "' and dcCompanyID = '" + _cid + "'; ";
            sql += " select * from T_OrderFlightInfo where dcOrderID = '" + _id + "'; ";
            sql += " select * from T_OrderPerson where dcOrderID = '" + _id + "'; ";
            DataSet ds = DbHelperSQL.Query(sql);

            var obj = new
            {
                info = ds.Tables[0],
                flight = ds.Tables[1],
                person = ds.Tables[2]
            };
            return Utils.pubResult(1, "获取成功", obj);
        }

        #endregion
    }
}