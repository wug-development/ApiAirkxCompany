using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            lock (this)
            {
                if (ticket != null)
                {
                    BLL.T_TicketSheet b_ticketsheet = new BLL.T_TicketSheet();
                    Model.T_TicketSheet m_ticketsheet = new Model.T_TicketSheet();

                    m_ticketsheet = ticket;

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
                        m_ticketsheet.dnFlightClass = m_order.dnOrderType;

                        if (m_ticketsheet.dnFlightClass == 0)
                        {
                            string[] xingcheng = ticket.dcStartCity.Split('-');
                            m_ticketsheet.dcStartCity = xingcheng[0];
                            m_ticketsheet.dcBackCity = xingcheng[1];
                        }

                        b_ticketsheet.Add(m_ticketsheet);

                        m_order.dnIsTicket = 1;
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
                        m_caccount.dnTotalTicketPrice += m_ticketsheet.dnJieSuanPrice;


                        b_caccount.Update(m_caccount);

                        if (m_ticketsheet.dnFlightClass == 0)
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
            m_fin.XSPrice = ticket.dnSellPrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            m_fin.AddUser = ticket.dcAddUser; // 测试
            m_fin.SKState = "1";
            m_fin.CPY = "";
            m_fin.XC = ticket.dcStartCity+"-"+ticket.dcBackCity;
            m_fin.RS = ticket.dnPersonNumber.ToString();
            m_fin.PH = ticket.dcTicketNO;
            m_fin.FPTT = ticket.dcPersonName;
            m_fin.FPJE = ticket.dcStartDate;
            m_fin.Customer = ticket.dcCompanyName;// ticket.dcCompanyName; "S散客"
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
            if (string.IsNullOrWhiteSpace(ticket.dcPaymentMethod1))
            {
                m_fin.FKFS = "欠款";
            }
            else
            {
                m_fin.FKFS = ticket.dcPaymentMethod1;
            }
            m_fin.SubFKFS = "";
            m_fin.YSJE1 = ticket.dnPaymentPrice2;
            if (string.IsNullOrWhiteSpace(ticket.dcPaymentMethod2))
            {
                m_fin.FKFS1 = "欠款";
            }
            else
            {
                m_fin.FKFS1 = ticket.dcPaymentMethod2;
            }
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
            //m_fin.SKData = null;
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
            m_fin.DPrice = ticket.dnDiJia;
            m_fin.SJPrice = ticket.dnTax;
            m_fin.SHPrice = ticket.dnJieSuanPrice;
            m_fin.SSPrice = ticket.dnShiShouPrice;
            m_fin.LRPrice = ticket.dnLiRun;
            m_fin.XSPrice = ticket.dnSellPrice;
            m_fin.HXPrice = ticket.dnHangXiePrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            m_fin.AddUser = "测试";
            m_fin.SKState = "1";
            m_fin.CPY = "";
            m_fin.XC = ticket.dcStartCity;//  + "-" + ticket.dcBackCity
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
            else
            {
                m_fin.StartDate = Convert.ToDateTime("1900-01-01 00:00:00.000");
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
            // m_fin.SKData = Convert.ToDateTime("1900-01-01 00:00:00.000");

            b_fin.Add(m_fin);
        }

        #endregion

        #endregion

        #region 处理订单并提交出票单
        [HttpPost]
        public HttpResponseMessage submitOrderTicket([FromBody] OrderTicket ot)
        {
            lock (this)
            {
                NoSortHashtable hash = new NoSortHashtable();

                Model.T_Order order = ot.orderinfo;
                BLL.T_Order b_order = new BLL.T_Order();
                Model.T_Order m_order = b_order.GetModel(order.dcOrderID);
                if (m_order != null)
                {
                    if (m_order.dnStatus == 0)
                    {
                        //**** 处理订单 start ***************************************//
                        m_order.dnStatus = order.dnStatus;
                        m_order.dcStartDate = order.dcStartDate;
                        m_order.dcOrderCode = order.dcOrderCode;
                        m_order.dcLinkName = order.dcLinkName;
                        m_order.dcTicketNO = order.dcTicketNO;
                        m_order.dnTotalPrice = order.dnTotalPrice;
                        m_order.dnPrice = order.dnPrice;
                        m_order.dnTax = order.dnTax;
                        m_order.dnServicePrice = order.dnServicePrice;
                        m_order.dnSafePrice = order.dnSafePrice;
                        m_order.dcContent = order.dcContent;
                        m_order.dnOrderStatus = order.dnOrderStatus;
                        m_order.dtEditTime = DateTime.Now;
                        m_order.dcPhone = order.dcPhone;
                        m_order.dnDiscount = order.dnDiscount;
                        m_order.dcAdminID = order.dcAdminID;
                        m_order.dcAdminName = order.dcAdminName;

                        if (order.dnOrderStatus == 2)
                        {
                            m_order.dnChangePrice = order.dnChangePrice;
                        }
                        if (order.dnOrderStatus == 3)
                        {
                            m_order.dnChangePrice = order.dnChangePrice;
                            m_order.dnChangeDatePrice = order.dnChangeDatePrice;
                            m_order.dnChaPrice = order.dnChaPrice;
                        }
                        m_order.dnIsTicket = 1;
                        hash = OrderTicketSql.getOrderSql(m_order, hash);
                        //**** 处理订单 end *****************************************//


                        //****  如果是改期订单则修改行程 start **********************//
                        if (order.dcLiantuoOrderNo != "")
                        {
                            BLL.T_OrderFlightInfo b_oflight = new BLL.T_OrderFlightInfo();
                            Model.T_OrderFlightInfo m_oflight = b_oflight.GetModel(ot.flightinfo.dcOrderFlightID);
                            if (m_oflight != null)
                            {
                                m_oflight.dcAirCode = ot.flightinfo.dcAirCode;
                                m_oflight.dcSJetquay = ot.flightinfo.dcSJetquay;
                                m_oflight.dcSTime = ot.flightinfo.dcSTime;
                                m_oflight.dcETime = ot.flightinfo.dcETime;
                                m_oflight.dcSeatMsg = ot.flightinfo.dcSeatMsg;
                                hash = OrderTicketSql.getOrderFlightSql(m_oflight, hash);
                            }
                        }
                        //**** 如果是改期订单则修改行程 end *************************//


                        //**** 添加出票 start ***************************************//
                        BLL.T_TicketSheet b_ticketsheet = new BLL.T_TicketSheet();
                        Model.T_TicketSheet m_ticketsheet = new Model.T_TicketSheet();

                        m_ticketsheet = ot.ticketinfo;

                        m_ticketsheet.dnStatus = 1;
                        m_ticketsheet.dcTSID = "ts" + m_ticketsheet.dcOrderID;
                        m_ticketsheet.dtAddTime = DateTime.Now;
                        m_ticketsheet.dcCompanyID = m_order.dcCompanyID;
                        m_ticketsheet.dcCompanyName = m_order.dcCompanyName;
                        m_ticketsheet.dnFlightClass = m_order.dnOrderType;

                        if (m_ticketsheet.dnFlightClass == 0)
                        {
                            string[] xingcheng = m_ticketsheet.dcStartCity.Split('-');
                            m_ticketsheet.dcStartCity = xingcheng[0];
                            m_ticketsheet.dcBackCity = xingcheng[1];
                        }

                        hash = OrderTicketSql.getTicketSql(m_ticketsheet, hash);
                        //**** 添加出票 end ***************************************//

                        //**** 修改企业账户信息 start *****************************//
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
                        m_caccount.dnTotalTicketPrice += m_ticketsheet.dnJieSuanPrice;

                        hash = OrderTicketSql.getAccountSql(m_caccount, hash);
                        //**** 修改企业账户信息 end ******************************//

                        if (m_ticketsheet.dnFlightClass == 0)
                        {
                            // 添加国内 CNFinanceDB 出票单
                            hash = postFinance(m_ticketsheet, hash);
                        }
                        else
                        {
                            // 添加国际 CNFinanceDB 出票单
                            hash = postFinanceGJ(m_ticketsheet, hash);
                        }
                        try
                        {
                            DbHelperSQL.ExecuteSqlTran(hash);
                            return Utils.pubResult(1);
                        }
                        catch(Exception e)
                        {
                            throw e;
                            return Utils.pubResult(0);
                        }
                    }
                    else
                    {
                        return Utils.pubResult(-1, "保存失败，该订单已处理", "");
                    }
                }
                else
                {
                    return Utils.pubResult(0);
                }
            }
        }


        #region 提交国内出票系统
        //提交国内出票系统
        private NoSortHashtable postFinance(Model.T_TicketSheet ticket, NoSortHashtable hash)
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
            m_fin.XSPrice = ticket.dnSellPrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            m_fin.AddUser = ticket.dcAddUser; // 测试
            m_fin.SKState = "1";
            m_fin.CPY = "";
            m_fin.XC = ticket.dcStartCity + "-" + ticket.dcBackCity;
            m_fin.RS = ticket.dnPersonNumber.ToString();
            m_fin.PH = ticket.dcTicketNO;
            m_fin.FPTT = ticket.dcPersonName;
            m_fin.FPJE = ticket.dcStartDate;
            m_fin.Customer = ticket.dcCompanyName;// ticket.dcCompanyName; "S散客"
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
            if (string.IsNullOrWhiteSpace(ticket.dcPaymentMethod1))
            {
                m_fin.FKFS = "欠款";
            }
            else
            {
                m_fin.FKFS = ticket.dcPaymentMethod1;
            }
            m_fin.SubFKFS = "";
            m_fin.YSJE1 = ticket.dnPaymentPrice2;
            if (string.IsNullOrWhiteSpace(ticket.dcPaymentMethod2))
            {
                m_fin.FKFS1 = "欠款";
            }
            else
            {
                m_fin.FKFS1 = ticket.dcPaymentMethod2;
            }
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
            //m_fin.SKData = null;
            m_fin.CPDXX = ticket.dcCPDXX;
            m_fin.BXXX = "支付宝";
            m_fin.FKState = "0";

            hash = GNFinanceAdd(m_fin, hash);
            return hash;
        }

        public NoSortHashtable GNFinanceAdd(Model.FinanceInfo model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [CNFinanceDB].[dbo].[FinanceInfo] (");
            strSql.Append("Company,JLCode,DPrice,SJPrice,SHPrice,SSPrice,LRPrice,XSPrice,FDPrice,CPD,AddTime,AddUser,SKState,CPY,XC,RS,PH,FPTT,FPJE,FKFS,Customer,BZ,SPY,SPFS,ZK,SubFKFS,YSJE,YSJE1,FKFS1,SubFKFS1,SubSKState,GRYH,GRYH1,FDPrice1,YSPrice,FXPrice,SJDZ,JPQJ,CW,OrderCode,Jiangjin,JJRY,GPR,HBH,DPRQ,NewFXPrice,CPDXX,BXXX,FKState");
            strSql.Append(") values (");
            strSql.Append("@Company,@JLCode,@DPrice,@SJPrice,@SHPrice,@SSPrice,@LRPrice,@XSPrice,@FDPrice,@CPD,@AddTime,@AddUser,@SKState,@CPY,@XC,@RS,@PH,@FPTT,@FPJE,@FKFS,@Customer,@BZ,@SPY,@SPFS,@ZK,@SubFKFS,@YSJE,@YSJE1,@FKFS1,@SubFKFS1,@SubSKState,@GRYH,@GRYH1,@FDPrice1,@YSPrice,@FXPrice,@SJDZ,@JPQJ,@CW,@OrderCode,@Jiangjin,@JJRY,@GPR,@HBH,@DPRQ,@NewFXPrice,@CPDXX,@BXXX,@FKState");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Company", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@JLCode", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@DPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SJPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SHPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SSPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@LRPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@XSPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@FPJE", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@BZ", SqlDbType.NText) ,
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@ZK", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFKFS", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFKFS1", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GRYH", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GRYH1", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FDPrice1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@YSPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@FXPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,
                        new SqlParameter("@JPQJ", SqlDbType.Float,8) ,
                        new SqlParameter("@CW", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@OrderCode", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Jiangjin", SqlDbType.Float,8) ,
                        new SqlParameter("@JJRY", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GPR", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@HBH", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@DPRQ", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@NewFXPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@CPDXX", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@BXXX", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FKState", SqlDbType.NVarChar,50)

            };

            parameters[0].Value = model.Company;
            parameters[1].Value = model.JLCode;
            parameters[2].Value = model.DPrice;
            parameters[3].Value = model.SJPrice;
            parameters[4].Value = model.SHPrice;
            parameters[5].Value = model.SSPrice;
            parameters[6].Value = model.LRPrice;
            parameters[7].Value = model.XSPrice;
            parameters[8].Value = model.FDPrice;
            parameters[9].Value = model.CPD;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.AddUser;
            parameters[12].Value = model.SKState;
            parameters[13].Value = model.CPY;
            parameters[14].Value = model.XC;
            parameters[15].Value = model.RS;
            parameters[16].Value = model.PH;
            parameters[17].Value = model.FPTT;
            parameters[18].Value = model.FPJE;
            parameters[19].Value = model.FKFS;
            parameters[20].Value = model.Customer;
            parameters[21].Value = model.BZ;
            parameters[22].Value = model.SPY;
            parameters[23].Value = model.SPFS;
            parameters[24].Value = model.ZK;
            parameters[25].Value = model.SubFKFS;
            parameters[26].Value = model.YSJE;
            parameters[27].Value = model.YSJE1;
            parameters[28].Value = model.FKFS1;
            parameters[29].Value = model.SubFKFS1;
            parameters[30].Value = model.SubSKState;
            parameters[31].Value = model.GRYH;
            parameters[32].Value = model.GRYH1;
            parameters[33].Value = model.FDPrice1;
            parameters[34].Value = model.YSPrice;
            parameters[35].Value = model.FXPrice;
            parameters[36].Value = model.SJDZ;
            parameters[37].Value = model.JPQJ;
            parameters[38].Value = model.CW;
            parameters[39].Value = model.OrderCode;
            parameters[40].Value = model.Jiangjin;
            parameters[41].Value = model.JJRY;
            parameters[42].Value = model.GPR;
            parameters[43].Value = model.HBH;
            parameters[44].Value = model.DPRQ;
            parameters[45].Value = model.NewFXPrice;
            parameters[46].Value = model.CPDXX;
            parameters[47].Value = model.BXXX;
            parameters[48].Value = model.FKState;

            hash.Add(strSql, parameters);
            return hash;
        }

        #endregion

        #region 提交国际出票系统
        //提交国际出票系统
        private NoSortHashtable postFinanceGJ(Model.T_TicketSheet ticket, NoSortHashtable hash)
        {
            BLL.FinanceInfoGJ b_fin = new BLL.FinanceInfoGJ();
            Model.FinanceInfoGJ m_fin = new Model.FinanceInfoGJ();
            m_fin.Company = ticket.dcAirCompanyName;
            m_fin.JLCode = ticket.dcOrderCode;
            m_fin.DPrice = ticket.dnDiJia;
            m_fin.SJPrice = ticket.dnTax;
            m_fin.SHPrice = ticket.dnJieSuanPrice;
            m_fin.SSPrice = ticket.dnShiShouPrice;
            m_fin.LRPrice = ticket.dnLiRun;
            m_fin.XSPrice = ticket.dnSellPrice;
            m_fin.HXPrice = ticket.dnHangXiePrice;
            m_fin.FDPrice = ticket.dnReturnPoint1.ToString();
            m_fin.CPD = ticket.dcOutTicketName;
            m_fin.AddTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            m_fin.AddUser = "测试";
            m_fin.SKState = "1";
            m_fin.CPY = "";
            m_fin.XC = ticket.dcStartCity;//  + "-" + ticket.dcBackCity
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
            else
            {
                m_fin.StartDate = Convert.ToDateTime("1900-01-01 00:00:00.000");
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
            // m_fin.SKData = Convert.ToDateTime("1900-01-01 00:00:00.000");
            hash = GJFinanceAdd(m_fin, hash);
            return hash;
        }

        public NoSortHashtable GJFinanceAdd(ApiAirkxCompany.Model.FinanceInfoGJ model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [FinanceDB].[dbo].[FinanceInfo] (");
            strSql.Append("Company,JLCode,DPrice,SJPrice,SHPrice,SSPrice,LRPrice,XSPrice,HXPrice,FDPrice,DPriceStr,SJPriceStr,SHPriceStr,SSPriceStr,LRPriceStr,XSPriceStr,CPD,AddTime,AddUser,SKState,CPY,XC,RS,PH,FPTT,FPJE,FKFS,Customer,BZ,SPY,SPFS,FDJE,FKSM,CPDSM,SubSKState,SJDZ,DLZH,FDOne,FDTwo,SubFK,GRYH,SYJJ,FXJE,YWF,YSJE,FKFS1,FKFS2,FKFS3,SubFK1,SubFK2,SubFK3,GRYH1,GRYH2,GRYH3,YSJE1,YSJE2,YSJE3,YWR,FKState,KPState,GNTPH,GNTPH1,GNTPH2,GNTPH3,StartDate,EndDate,YQ,PNRText,CJR,HBH,QLSJ,CWDJ,ZK,FWF");
            strSql.Append(") values (");
            strSql.Append("@Company,@JLCode,@DPrice,@SJPrice,@SHPrice,@SSPrice,@LRPrice,@XSPrice,@HXPrice,@FDPrice,@DPriceStr,@SJPriceStr,@SHPriceStr,@SSPriceStr,@LRPriceStr,@XSPriceStr,@CPD,@AddTime,@AddUser,@SKState,@CPY,@XC,@RS,@PH,@FPTT,@FPJE,@FKFS,@Customer,@BZ,@SPY,@SPFS,@FDJE,@FKSM,@CPDSM,@SubSKState,@SJDZ,@DLZH,@FDOne,@FDTwo,@SubFK,@GRYH,@SYJJ,@FXJE,@YWF,@YSJE,@FKFS1,@FKFS2,@FKFS3,@SubFK1,@SubFK2,@SubFK3,@GRYH1,@GRYH2,@GRYH3,@YSJE1,@YSJE2,@YSJE3,@YWR,@FKState,@KPState,@GNTPH,@GNTPH1,@GNTPH2,@GNTPH3,@StartDate,@EndDate,@YQ,@PNRText,@CJR,@HBH,@QLSJ,@CWDJ,@ZK,@FWF");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Company", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@JLCode", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@DPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SJPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SHPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@SSPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@LRPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@XSPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@HXPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@DPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SJPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SHPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SSPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@LRPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@XSPriceStr", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,1000) ,
                        new SqlParameter("@FPJE", SqlDbType.Float,8) ,
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@BZ", SqlDbType.NVarChar,4000) ,
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FDJE", SqlDbType.Float,8) ,
                        new SqlParameter("@FKSM", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@CPDSM", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,
                        new SqlParameter("@DLZH", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FDOne", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FDTwo", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFK", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@GRYH", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SYJJ", SqlDbType.Float,8) ,
                        new SqlParameter("@FXJE", SqlDbType.Float,8) ,
                        new SqlParameter("@YWF", SqlDbType.Float,8) ,
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FKFS2", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FKFS3", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFK1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFK2", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@SubFK3", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GRYH1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GRYH2", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GRYH3", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,
                        new SqlParameter("@YSJE2", SqlDbType.Float,8) ,
                        new SqlParameter("@YSJE3", SqlDbType.Float,8) ,
                        new SqlParameter("@YWR", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@FKState", SqlDbType.VarChar,50) ,
                        new SqlParameter("@KPState", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GNTPH", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GNTPH1", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GNTPH2", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@GNTPH3", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@StartDate", SqlDbType.DateTime) ,
                        new SqlParameter("@EndDate", SqlDbType.DateTime) ,
                        new SqlParameter("@YQ", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@PNRText", SqlDbType.Text) ,
                        new SqlParameter("@CJR", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@HBH", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@QLSJ", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@CWDJ", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@ZK", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@FWF", SqlDbType.NVarChar,-1)

            };

            parameters[0].Value = model.Company;
            parameters[1].Value = model.JLCode;
            parameters[2].Value = model.DPrice;
            parameters[3].Value = model.SJPrice;
            parameters[4].Value = model.SHPrice;
            parameters[5].Value = model.SSPrice;
            parameters[6].Value = model.LRPrice;
            parameters[7].Value = model.XSPrice;
            parameters[8].Value = model.HXPrice;
            parameters[9].Value = model.FDPrice;
            parameters[10].Value = model.DPriceStr;
            parameters[11].Value = model.SJPriceStr;
            parameters[12].Value = model.SHPriceStr;
            parameters[13].Value = model.SSPriceStr;
            parameters[14].Value = model.LRPriceStr;
            parameters[15].Value = model.XSPriceStr;
            parameters[16].Value = model.CPD;
            parameters[17].Value = model.AddTime;
            parameters[18].Value = model.AddUser;
            parameters[19].Value = model.SKState;
            parameters[20].Value = model.CPY;
            parameters[21].Value = model.XC;
            parameters[22].Value = model.RS;
            parameters[23].Value = model.PH;
            parameters[24].Value = model.FPTT;
            parameters[25].Value = model.FPJE;
            parameters[26].Value = model.FKFS;
            parameters[27].Value = model.Customer;
            parameters[28].Value = model.BZ;
            parameters[29].Value = model.SPY;
            parameters[30].Value = model.SPFS;
            parameters[31].Value = model.FDJE;
            parameters[32].Value = model.FKSM;
            parameters[33].Value = model.CPDSM;
            parameters[34].Value = model.SubSKState;
            parameters[35].Value = model.SJDZ;
            parameters[36].Value = model.DLZH;
            parameters[37].Value = model.FDOne;
            parameters[38].Value = model.FDTwo;
            parameters[39].Value = model.SubFK;
            parameters[40].Value = model.GRYH;
            parameters[41].Value = model.SYJJ;
            parameters[42].Value = model.FXJE;
            parameters[43].Value = model.YWF;
            parameters[44].Value = model.YSJE;
            parameters[45].Value = model.FKFS1;
            parameters[46].Value = model.FKFS2;
            parameters[47].Value = model.FKFS3;
            parameters[48].Value = model.SubFK1;
            parameters[49].Value = model.SubFK2;
            parameters[50].Value = model.SubFK3;
            parameters[51].Value = model.GRYH1;
            parameters[52].Value = model.GRYH2;
            parameters[53].Value = model.GRYH3;
            parameters[54].Value = model.YSJE1;
            parameters[55].Value = model.YSJE2;
            parameters[56].Value = model.YSJE3;
            parameters[57].Value = model.YWR;
            parameters[58].Value = model.FKState;
            parameters[59].Value = model.KPState;
            parameters[60].Value = model.GNTPH;
            parameters[61].Value = model.GNTPH1;
            parameters[62].Value = model.GNTPH2;
            parameters[63].Value = model.GNTPH3;
            parameters[64].Value = model.StartDate;
            parameters[65].Value = model.EndDate;
            parameters[66].Value = model.YQ;
            parameters[67].Value = model.PNRText;
            parameters[68].Value = model.CJR;
            parameters[69].Value = model.HBH;
            parameters[70].Value = model.QLSJ;
            parameters[71].Value = model.CWDJ;
            parameters[72].Value = model.ZK;
            parameters[73].Value = model.FWF;

            hash.Add(strSql, parameters);
            return hash;
        }

        #endregion


        #endregion

        #region 获取票信息
        /// <summary>
        /// 获取票信息
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTicketInfo(string tid)
        {
            string v = PageValidate.SQL_KILL(tid);
            string n = v.Substring(0, 2);
            if (n != "ts")
            {
                v = "ts" + v;
            }
            string sql = "select * from T_TicketSheet where dcTSID = '" + v + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }

        #endregion

        #region 获取票列表
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

        #endregion

        #region 获取国际出票点
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

        #endregion

        #region 获取人
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

        #endregion

        #region 导出票数据
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

        #endregion
    }

    public class OrderTicket
    {
        public Model.T_Order orderinfo { get; set; }
        public Model.T_OrderFlightInfo flightinfo { get; set; }
        public Model.T_TicketSheet ticketinfo { get; set; }
    }
}