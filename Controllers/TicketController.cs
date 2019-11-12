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
        #region 提交出票单
        /// <summary>
        /// 提交出票单
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

                    BLL.T_Company b_com = new BLL.T_Company();
                    Model.T_Company m_com = new Model.T_Company();
                    m_com = b_com.GetModel(m_order.dcCompanyID);

                    BLL.T_CompanyAccount b_caccount = new BLL.T_CompanyAccount();
                    Model.T_CompanyAccount m_caccount = b_caccount.GetCModel(m_order.dcCompanyID);
                    m_caccount.dcLastOrderDate = DateTime.Now.ToString("yyyy-MM-dd");
                    m_caccount.dnDebt = m_caccount.dnDebt + m_ticketsheet.dnJieSuanPrice;      // 欠款
                    decimal cl = m_com.dnCreditLine - m_caccount.dnDebt;
                    if (cl > 0)
                    {
                        m_caccount.dnCreditLine = cl;// 可用信用额度
                    }
                    else
                    {
                        m_caccount.dnCreditLine = 0;
                        m_caccount.dnUrgentMoney = cl;// 急需结算金额
                    }
                    // m_caccount.dnPayCount = 0;  // 付款总额
                    m_caccount.dnTotalTicketPrice += m_ticketsheet.dnJieSuanPrice;


                    b_caccount.Update(m_caccount);

                    if (ticket.dnFlightClass == 0)
                    {
                        postFinance(ticket);
                    }
                    else
                    {
                        postFinanceGJ(ticket);
                    }
                }

                return Utils.pubResult(1, "提交成功", "");
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }

        #region 提交国内出票系统
        //提交国内出票系统
        private void postFinance(Model.T_TicketSheet ticket)
        {
            BLL.FinanceInfo b_fin = new BLL.FinanceInfo();
            Model.FinanceInfo m_fin = new Model.FinanceInfo();
            m_fin.Company = ticket.dcAirCompanyName;
            m_fin.JLCode = ticket.dcOrderCode;
            m_fin.DPrice = ticket.dnSafePrice;
            m_fin.SJPrice = 0;
            m_fin.SHPrice = ticket.dnJieSuanPrice;
            m_fin.SSPrice = ticket.dnCountPrice;
            m_fin.LRPrice = ticket.dnLiRun;
            m_fin.XSPrice = ticket.dnTotalPrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = DateTime.Now;
            m_fin.AddUser = "测试";
            m_fin.SKState = "3";
            m_fin.CPY = "";
            m_fin.XC = ticket.dcStartCity;
            m_fin.RS = ticket.dnPersonNumber.ToString();
            m_fin.PH = ticket.dcTicketNO;
            m_fin.FPTT = ticket.dcPersonName;
            m_fin.FPJE = ticket.dcStartDate;
            m_fin.Customer = ticket.dcCompanyName;
            m_fin.BZ = ticket.dcOther;
            m_fin.SPY = ticket.dcSendTicketerName;
            m_fin.SPFS = ticket.dcSendTicketType;
            if (ticket.dnDiscount == 1)
            {
                m_fin.ZK = "全价";
            }
            else
            {
                m_fin.ZK = ticket.dnDiscount + "折";
            }
            m_fin.YSJE = ticket.dnPaymentPrice1;
            m_fin.FKFS = ticket.dcPaymentMethod1;
            m_fin.SubFKFS = "";
            m_fin.YSJE1 = ticket.dnPaymentPrice2;
            m_fin.FKFS1 = ticket.dcPaymentMethod2;
            m_fin.SubFKFS1 = "";
            m_fin.SubSKState = "0";
            m_fin.GRYH = "";
            m_fin.GRYH1 = "";
            m_fin.FDPrice1 = ticket.dnReturnPoint2.ToString();
            m_fin.YSPrice = ticket.dnYingShouPrice;
            m_fin.FXPrice = ticket.dnServicePrice;
            m_fin.SJDZ = ticket.dnShiJiDaoZhang;
            m_fin.JPQJ = ticket.dnTicketPrice;
            m_fin.CW = ticket.dcRakedClass;
            m_fin.OrderCode = ticket.dcOrderID;
            m_fin.Jiangjin = ticket.dnBonus;
            m_fin.JJRY = ticket.dnTax.ToString();
            m_fin.GPR = ticket.dcFlightTime;
            m_fin.HBH = ticket.dcFlightNumber;
            m_fin.DPRQ = "";
            m_fin.NewFXPrice = ticket.dnFandianPrice;
            // m_fin.SKData = null;
            m_fin.CPDXX = ticket.dcCPDXX;
            m_fin.BXXX = "支付宝";
            m_fin.FKState = "0";

            b_fin.Add(m_fin);
        }

        #endregion

        #region 提交国际出票系统
        //提交国际出票系统
        private void postFinanceGJ(Model.T_TicketSheet ticket)
        {
            BLL.FinanceInfoGJ b_fin = new BLL.FinanceInfoGJ();
            Model.FinanceInfoGJ m_fin = new Model.FinanceInfoGJ();
            m_fin.Company = ticket.dcAirCompanyName;
            m_fin.JLCode = ticket.dcOrderCode;
            m_fin.DPrice = ticket.dnSafePrice;
            m_fin.SJPrice = ticket.dnTax;
            m_fin.SHPrice = ticket.dnJieSuanPrice;
            m_fin.SSPrice = ticket.dnShiShouPrice;
            m_fin.LRPrice = ticket.dnLiRun;
            m_fin.XSPrice = ticket.dnSellPrice;
            m_fin.HXPrice = ticket.dnHangXiePrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = DateTime.Now;
            m_fin.AddUser = "测试";
            m_fin.SKState = "3";
            m_fin.CPY = "赵明阳";
            m_fin.XC = ticket.dcStartCity;
            m_fin.RS = ticket.dnPersonNumber.ToString();
            m_fin.PH = ticket.dcTicketNO;
            m_fin.FPTT = ticket.dcPersonName;
            m_fin.FPJE = ticket.dnFlightPrice;
            m_fin.Customer = ticket.dcCompanyName;
            m_fin.BZ = ticket.dcOther;
            m_fin.SPY = ticket.dcSendTicketerName;
            m_fin.SPFS = ticket.dcSendTicketType;
            m_fin.FDJE = ticket.dnFandianPrice;
            m_fin.FKSM = ticket.dcRakedClass;
            m_fin.CPDSM = "";
            m_fin.SubSKState = "0";
            m_fin.SJDZ = ticket.dnShiJiDaoZhang;
            m_fin.DLZH = ticket.dcOrderID;
            m_fin.FDOne = ticket.dnReturnPoint2.ToString();
            m_fin.FDTwo = ticket.dnReturnPoint3.ToString();
            m_fin.SYJJ = ticket.dnBonus;
            m_fin.FXJE = ticket.dnReturnPrice;
            m_fin.YWF = ticket.dnYaoWeiPrice;
            m_fin.YSJE = ticket.dnPaymentPrice1;
            m_fin.FKFS = ticket.dcPaymentMethod1;
            m_fin.YSJE1 = ticket.dnPaymentPrice2;
            m_fin.FKFS1 = ticket.dcPaymentMethod2;
            m_fin.YSJE2 = ticket.dnPaymentPrice3;
            m_fin.FKFS2 = ticket.dcPaymentMethod3;
            m_fin.YSJE3 = ticket.dnPaymentPrice4;
            m_fin.FKFS3 = ticket.dcPaymentMethod4;
            m_fin.SubFK = "";
            m_fin.SubFK1 = "";
            m_fin.SubFK2 = "";
            m_fin.SubFK3 = "";
            m_fin.GRYH = "";
            m_fin.GRYH1 = "";
            m_fin.GRYH2 = "";
            m_fin.GRYH3 = "";
            m_fin.YWR = ticket.dcLXR;
            m_fin.KPState = "0";
            if (!string.IsNullOrWhiteSpace(ticket.dcStartDate))
            {
                m_fin.StartDate = Convert.ToDateTime(ticket.dcStartDate);
            }
            m_fin.EndDate = Convert.ToDateTime("1900-01-01 00:00:00.000");
            m_fin.YQ = "0";
            m_fin.PNRText = "";
            m_fin.CJR = ticket.dcPersonName;
            m_fin.HBH = ticket.dcFlightNumber;
            m_fin.QLSJ = ticket.dcFlightTime;
            m_fin.CWDJ = ticket.dcRakedClass;
            m_fin.ZK = ticket.dnTicketPrice.ToString();
            m_fin.FWF = ticket.dnServicePrice.ToString();
            m_fin.FKState = "0";

            b_fin.Add(m_fin);
        }

        #endregion

        #endregion


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

        /// <summary>
        /// 导出票数据
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <param name="filterdate">开始-结束时间</param>
        /// <returns></returns>
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