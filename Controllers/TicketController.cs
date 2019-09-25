using System;
using System.Collections.Generic;
using System.Data;
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
                if (!string.IsNullOrWhiteSpace(ticket.dcTSID))
                {
                    m_ticketsheet = b_ticketsheet.GetModel(ticket.dcTSID);
                }

                m_ticketsheet = ticket;
                m_ticketsheet.dcStartCity = xingcheng[0];
                m_ticketsheet.dcBackCity = xingcheng[1];

                if (!string.IsNullOrWhiteSpace(ticket.dcTSID))
                {
                    b_ticketsheet.Update(m_ticketsheet);
                }
                else
                {
                    m_ticketsheet.dnStatus = 1;
                    m_ticketsheet.dcOrderID = ticket.dcOrderID;
                    m_ticketsheet.dcTSID = "ts" + ticket.dcOrderID;
                    m_ticketsheet.dtAddTime = DateTime.Now;
                    b_ticketsheet.Add(m_ticketsheet);

                    BLL.T_Order b_order = new BLL.T_Order();
                    Model.T_Order m_order = b_order.GetModel(ticket.dcOrderID);
                    m_order.dnIsTicket = 1;
                    m_order.dcTicketNO = m_ticketsheet.dcTSID;
                    b_order.Update(m_order);
                }

                return Utils.pubResult(1, "提交成功", "");
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetTicketInfo(string tid)
        {
            string sql = "select * from T_TicketSheet where dcTSID = '" + tid + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "提交成功", dt);
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
            return Utils.pubResult(1, "提交成功", dt);
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
            return Utils.pubResult(1, "提交成功", dt);
        }
    }
}