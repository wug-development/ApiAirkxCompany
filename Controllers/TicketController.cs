using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class TicketController : ApiController
    {
        /// <summary>
        /// 提交国际出票单
        /// </summary>
        /// <param name="ticket">出票单对象</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public HttpResponseMessage SubmitTicket([FromBody] Model.T_TicketSheet ticket)
        {
            if (ticket != null)
            {
                BLL.T_TicketSheet b_ticketsheet = new BLL.T_TicketSheet();
                Model.T_TicketSheet m_ticketsheet = new Model.T_TicketSheet();
                string[] xingcheng = ticket.dcStartCity.Split('-');
                //if (!string.IsNullOrWhiteSpace(ticket.dcTSID))
                //{
                //    m_ticketsheet = b_ticketsheet.GetModel(ticket.dcTSID);
                //}

                m_ticketsheet = ticket;
                m_ticketsheet.dcStartCity = xingcheng[0];
                m_ticketsheet.dcBackCity = xingcheng[1];

                if (!string.IsNullOrWhiteSpace(ticket.dcTSID))
                {
                    b_ticketsheet.Update(m_ticketsheet);
                }
                else
                {
                    BLL.T_Order b_order = new BLL.T_Order();
                    Model.T_Order m_order = b_order.GetModel(ticket.dcOrderID);

                    m_ticketsheet.dnStatus = 1;
                    m_ticketsheet.dcOrderID = ticket.dcOrderID;
                    m_ticketsheet.dcTSID = "ts" + ticket.dcOrderID;
                    m_ticketsheet.dtAddTime = DateTime.Now;
                    m_ticketsheet.dcCompanyID = m_order.dcCompanyID;
                    m_ticketsheet.dcCompanyName = m_order.dcCompanyName;
                    b_ticketsheet.Add(m_ticketsheet);

                    m_order.dnIsTicket = 1;
                    m_order.dcTicketNO = m_ticketsheet.dcTSID;
                    b_order.Update(m_order);

                    string sql = " update T_CompanyAccount set dcLastOrderDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where dcCompanyID='" + m_order.dcCompanyID + "' ";
                    DbHelperSQL.ExecuteSql(sql);
                }

                return Utils.pubResult(1, "提交成功", "");
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }

        /// <summary>
        /// 获取票信息
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTicketInfo(string tid)
        {
            string sql = "select * from T_TicketSheet where dcTSID = '" + tid + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }

        /// <summary>
        /// 获取票列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagenum"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTicketList(string cid, int page, int pagenum, string filterdate)
        {
            string sqlwhere = " and dcCompanyID = '" + cid + "' ";
            if (!string.IsNullOrWhiteSpace(filterdate)) 
            {
                string[] arr = filterdate.Split(',');
                sqlwhere += " and dtAddTime > '" + arr[0] + "' ";
                sqlwhere += " and dtAddTime < '" + arr[1] + "' ";
            }
            string sql = "select top " + (page * pagenum) + " * from T_TicketSheet where 1=1 " + sqlwhere + " and dcTSID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcTSID from T_TicketSheet where 1=1 " + sqlwhere + " order by dtAddTime desc) order by dtAddTime desc ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcTSID) from dbo.T_TicketSheet where 1=1 " + sqlwhere;
                count = Convert.ToDecimal(DbHelperSQL.GetSingle(sqlcount));
            }
            var res = new
            {
                data = dt,
                pagecount = count
            };

            return Utils.pubResult(1, "获取成功", res);
        }

        /// <summary>
        /// 获取国际出票点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetGJOutTicket()
        {
            string sql = " select JCID as id,JCName as name from BaseInfo where JCType='出票点' ";
            SqlHelperTool dbsql = new SqlHelperTool("gjcw"); 
            DataTable dt = dbsql.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }

        /// <summary>
        /// 获取人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetGJPeople()
        {
            string sql = " select HKYWID as id,LXR as name from HKYWInfo where 1=1 ";
            SqlHelperTool dbsql = new SqlHelperTool("gjcw"); 
            DataTable dt = dbsql.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }


        [HttpGet]
        public HttpResponseMessage ExportTicket(string cid, string filterdate)
        {
            string sqlwhere = " and dcCompanyID = '" + cid + "' ";
            if (!string.IsNullOrWhiteSpace(filterdate))
            {
                string[] arr = filterdate.Split(',');
                sqlwhere += " and dtAddTime > '" + arr[0] + "' ";
                sqlwhere += " and dtAddTime < '" + arr[1] + "' ";
            }
            string sql = "select  * from T_TicketSheet where 1=1 " + sqlwhere + " ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            return Utils.pubResult(1, "获取成功", dt);
        }

    }
}