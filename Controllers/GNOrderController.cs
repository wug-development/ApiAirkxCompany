using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using log4net;
using ApiAirkxCompany.createOrderByPassengerService;

namespace ApiAirkxCompany.Controllers
{
    public class GNOrderController : ApiController
    {

        #region 提交国内订单
        /// <summary>
        /// 提交国内订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public HttpResponseMessage SubmitOrderCN([FromBody] OrderBody order)
        {
            if (order != null)
            {
                Random rd = new Random();
                string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000, 9999).ToString();

                NoSortHashtable hash = new NoSortHashtable();

                if (order.personlist.Count > 0)
                {
                    // 添加常用乘机人
                    hash = addPerson(order.personlist, order.cid, hash);
                    // 添加订单乘机人
                    hash = addOrderPersonList(order.personlist, orderid, hash);
                }

                // 添加去程
                if (order.airbody != null && order.airseat != null)
                {
                    hash = addOrderFlight(order, orderid, hash);
                }

                // 添加订单主体

                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = b_company.GetModel(order.cid);

                if (m_company != null)
                {
                    Model.T_Admin m_admin = new Model.T_Admin();
                    BLL.T_Admin b_admin = new BLL.T_Admin();
                    m_admin = b_admin.GetModel(m_company.dcAdminID);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Order(");
                    strSql.Append("dcOrderID,dcOrderCode,dcTicketNO,dnOrderType,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcCompanyName,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dnDiscount,dnChangePrice,dnChangeDatePrice,dnChaPrice,dcContent,dcAdminID,dcAdminName,dnTicketID,dnDetailID,dcCTCT,dnStatus,dnOrderStatus,dnIsTicket,dtAddTime,dtEditTime)");
                    strSql.Append(" values (");
                    strSql.Append("@dcOrderID,@dcOrderCode,@dcTicketNO,@dnOrderType,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcCompanyName,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnServicePrice,@dnSafePrice,@dnTotalPrice,@dnDiscount,@dnChangePrice,@dnChangeDatePrice,@dnChaPrice,@dcContent,@dcAdminID,@dcAdminName,@dnTicketID,@dnDetailID,@dcCTCT,@dnStatus,@dnOrderStatus,@dnIsTicket,@dtAddTime,@dtEditTime");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcTicketNO", SqlDbType.VarChar, 40),
                        new SqlParameter("@dnOrderType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcBackDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcCompanyName", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnDiscount", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChangePrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChangeDatePrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChaPrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dcContent", SqlDbType.Text) ,
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4),
                        new SqlParameter("@dcCTCT", SqlDbType.VarChar, 20),
                        new SqlParameter("@dnStatus", SqlDbType.Int, 4),
                        new SqlParameter("@dnOrderStatus", SqlDbType.Int, 4),
                        new SqlParameter("@dnIsTicket", SqlDbType.Int, 4),
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime),
                        new SqlParameter("@dtEditTime", SqlDbType.SmallDateTime)
                    };

                    int tax = 0;
                    double price = order.airseat.parPrice + order.airbody.airportTax + order.airbody.fuelTax;
                    double total = 0;
                    int safeprice = 0;
                    for (int i = 0; i < order.personlist.Count; i++)
                    {
                        int _s = getSafe(order.personlist[i].safenum);
                        safeprice += _s;
                        total += price + Convert.ToDouble(m_company.dnServicePirce) + _s;
                    }

                    parameters[0].Value = orderid;
                    parameters[1].Value = "";// 订单编码
                    parameters[2].Value = "";// 票号
                    parameters[3].Value = 0;// 订单类型（0国内航班订单1国际航班订单）
                    parameters[4].Value = 0;
                    parameters[5].Value = order.sdate;
                    parameters[6].Value = "";
                    parameters[7].Value = order.scity.name;
                    parameters[8].Value = order.ecity.name;
                    parameters[9].Value = order.cid;
                    parameters[10].Value = order.cname;
                    parameters[11].Value = order.personlist[0].name;// 联系人
                    parameters[12].Value = order.personlist[0].phone;// 联系电话
                    parameters[13].Value = price;
                    parameters[14].Value = tax;
                    parameters[15].Value = m_company.dnServicePirce;
                    parameters[16].Value = safeprice;
                    parameters[17].Value = total;
                    parameters[18].Value = order.airseat.discount;
                    parameters[19].Value = 0;
                    parameters[20].Value = 0;
                    parameters[21].Value = 0;
                    if (!string.IsNullOrWhiteSpace(order.content))
                    {
                        parameters[22].Value = order.content;// 备注
                    }
                    else
                    {
                        parameters[22].Value = "";
                    }
                    parameters[23].Value = m_admin.dcAdminID;
                    parameters[24].Value = m_admin.dcAdminName;
                    parameters[25].Value = 0;
                    parameters[26].Value = 0;
                    parameters[27].Value = m_admin.dcPhone;
                    parameters[28].Value = 0;
                    parameters[29].Value = 1;
                    parameters[30].Value = 0;
                    parameters[31].Value = DateTime.Now;
                    parameters[32].Value = DateTime.Now;

                    hash.Add(strSql, parameters);

                    try
                    {
                        DbHelperSQL.ExecuteSqlTran(hash);
                        LoggerHelper.Info("------开始调用第三方下单接口------");
                        GDSBookingServiceImp.gdsBookingReply res = CreateGNOrder.createOrder(order, orderid, m_admin.dcRealName, m_admin.dcPhone);
                        if (res.returnCode == "S")
                        {
                            BLL.T_Order b_o = new BLL.T_Order();
                            Model.T_Order m_o = b_o.GetModel(orderid);
                            m_o.dcOrderCode = res.pnrNo;
                            // m_o.dcLiantuoOrderNo = res.order.liantuoOrderNo;
                            b_o.Update(m_o);

                            return Utils.pubResult(1, "提交成功", res);
                        }
                        else
                        {
                            ArrayList sqls = new ArrayList();
                            sqls.Add("delete from T_Order where dcOrderID in (" + orderid + ") and dnStatus=0 ");
                            sqls.Add("delete from T_OrderFlightInfo where dcOrderID in (" + orderid + ")");
                            sqls.Add("delete from T_OrderPerson where dcOrderID in (" + orderid + ")");
                            DbHelperSQL.ExecuteSqlTran(sqls);

                            return Utils.pubResult(0, "提交失败", "");
                        }
                    }
                    catch (Exception e)
                    {
                        LoggerHelper.Error("国内下单SubmitOrderCN：" + e.Message);
                        return Utils.pubResult(0, "提交失败", "");
                    }
                }
                else
                {
                    return Utils.pubResult(0, "提交失败", "");
                }
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }


        /// <summary>
        /// 添加常用乘机人
        /// </summary>
        /// <param name="p">乘机人列表</param>
        /// <param name="cid">用户ID</param>
        public NoSortHashtable addPerson(List<PersonList> p, string cid, NoSortHashtable hash)
        {
            int i = 0;
            foreach (PersonList person in p)
            {
                if (String.IsNullOrEmpty(person.id))
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Passenger(");
                    strSql.Append("dcPerID,dcCompanyID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType");
                    strSql.Append(") values (");
                    strSql.Append("@dcPerID,@dcCompanyID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcPerID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,
                        new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,
                        new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcType", SqlDbType.Int,4)
                    };

                    parameters[0].Value = Utils.getDataID("per") + i++;
                    parameters[1].Value = cid;
                    parameters[2].Value = person.name;
                    parameters[3].Value = person.csrq;
                    parameters[5].Value = person.hzyxq;
                    parameters[6].Value = person.sex;
                    if (!string.IsNullOrWhiteSpace(person.cardtype))
                    {
                        if (person.cardtype == "身份证")
                        {
                            parameters[7].Value = person.idcard;
                            parameters[4].Value = "";
                        }
                        else if (person.cardtype == "护照")
                        {
                            parameters[7].Value = "";
                            parameters[4].Value = person.idcard;
                        }
                        else
                        {
                            parameters[4].Value = person.hzh;
                            parameters[7].Value = person.idcard;
                        }
                    }
                    else
                    {
                        parameters[4].Value = person.hzh;
                        parameters[7].Value = person.idcard;
                    }
                    parameters[8].Value = person.phone;
                    parameters[9].Value = person.jjphone;
                    parameters[10].Value = person.type == "成人" ? 1 : (person.type == "儿童" ? 2 : 3);
                    hash.Add(strSql, parameters);
                }
            }
            return hash;
        }


        /// <summary>
        /// 添加订单乘机人
        /// </summary>
        /// <param name="p">乘机人列表</param>
        /// <param name="oid">订单ID</param>
        public NoSortHashtable addOrderPersonList(List<PersonList> p, string oid, NoSortHashtable hash)
        {
            int i = 0;
            foreach (PersonList person in p)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_OrderPerson(");
                strSql.Append("dcOPID,dcOrderID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType,dnCardType");
                strSql.Append(") values (");
                strSql.Append("@dcOPID,@dcOrderID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType,@dnCardType");
                strSql.Append(") ");

                SqlParameter[] parameters = {
                    new SqlParameter("@dcOPID", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,
                    new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,
                    new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,
                    new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,
                    new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,
                    new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,
                    new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,
                    new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,
                    new SqlParameter("@dcType", SqlDbType.Int,4),
                    new SqlParameter("@dnCardType", SqlDbType.Int,4)
                };

                parameters[0].Value = Utils.getDataID("op") + i++;
                parameters[1].Value = oid;
                parameters[2].Value = person.name;
                parameters[3].Value = person.csrq;
                parameters[5].Value = person.hzyxq;
                parameters[6].Value = person.sex;
                parameters[7].Value = person.idcard;
                parameters[8].Value = person.phone;
                parameters[9].Value = person.jjphone;
                parameters[11].Value = person.cardtype;
                if (!string.IsNullOrWhiteSpace(person.cardtype))
                {
                    if (person.cardtype == "1")
                    {
                        parameters[7].Value = person.idcard;
                        parameters[4].Value = "";
                    }
                    else if (person.cardtype == "2" && person.hzh != "")
                    {
                        parameters[7].Value = person.idcard;
                        parameters[4].Value = person.hzh;
                    }
                    else
                    {
                        parameters[4].Value = "";
                        parameters[7].Value = person.idcard;
                    }
                }
                else
                {
                    parameters[4].Value = "";
                }
                if (person.type.Length == 1)
                {
                    parameters[10].Value = person.type;
                }
                else
                {
                    parameters[10].Value = person.type == "成人" ? 1 : (person.type == "儿童" ? 2 : 3);
                }
                hash.Add(strSql, parameters);
            }
            return hash;
        }


        /// <summary>
        /// 添加航线SQL
        /// </summary>
        /// <param name="order"></param>
        /// <param name="oid"></param>
        public NoSortHashtable addOrderFlight(OrderBody order, string oid, NoSortHashtable hash)
        {
            if (order != null)
            {
                BLL.T_AirCompany b_aircompany = new BLL.T_AirCompany();
                Model.T_AirCompany m_aircompany = b_aircompany.GetModel(order.airbody.flightNo.Substring(0, 2));

                if (m_aircompany != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_OrderFlightInfo(");
                    strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent)");
                    strSql.Append(" values (");
                    strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSJetquay,@dcEJetquay,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcSeatMsg,@dcContent");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnFlightType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnAirID", SqlDbType.Int,4) ,
                        new SqlParameter("@dcAirCode", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@dcSJetquay", SqlDbType.VarChar, 10),
                        new SqlParameter("@dcEJetquay", SqlDbType.VarChar, 10),
                        new SqlParameter("@dcSCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcECode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcSTime", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcETime", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcJixing", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4) ,
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@dcCompanyLogo", SqlDbType.Text) ,
                        new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcSeatMsg", SqlDbType.NVarChar, 20),
                        new SqlParameter("@dcContent", SqlDbType.NVarChar,200)
                    };

                    parameters[0].Value = Utils.getDataID("of");
                    parameters[1].Value = oid;
                    parameters[2].Value = 0;
                    parameters[3].Value = 0;
                    parameters[4].Value = 0;
                    parameters[5].Value = order.airbody.flightNo;
                    parameters[6].Value = order.scity.airportname;
                    parameters[7].Value = order.ecity.airportname;
                    parameters[8].Value = order.airbody.orgJetquay;
                    parameters[9].Value = order.airbody.dstJetquay;
                    parameters[10].Value = order.scity.code;
                    parameters[11].Value = order.ecity.code;
                    parameters[12].Value = order.airbody.depTime.Substring(0, 2) + ":" + order.airbody.depTime.Substring(2, 2);
                    parameters[13].Value = order.airbody.arriTime.Substring(0, 2) + ":" + order.airbody.arriTime.Substring(2, 2);
                    parameters[14].Value = order.airbody.planeType;
                    parameters[15].Value = m_aircompany.dcAirCompanyID;
                    parameters[16].Value = m_aircompany.dcCompanyName;
                    parameters[17].Value = m_aircompany.dcEnCompanyName;
                    parameters[18].Value = m_aircompany.dcCompanyLogo;
                    parameters[19].Value = m_aircompany.dcCompanyCode;
                    parameters[20].Value = order.airseat.seatMsg;
                    parameters[21].Value = "";
                    hash.Add(strSql, parameters);
                }
            }
            return hash;
        }

        // 获取保险
        private int getSafe(string s)
        {
            int safenum = 0;
            switch (s)
            {
                case "1": safenum = 20; break;
                case "true": safenum = 20; break;
                default: safenum = 0; break;
            }
            return safenum;
        }
        #endregion

        #region 国内订单出票成功后通知
        /// <summary>
        /// 国内订单出票成功后通知
        /// </summary>
        /// <param name="type">1</param>
        /// <param name="sequenceNo">订单号</param>
        /// <param name="passengerNames">乘客名（多个乘客之间用逗号“,”分割）</param>
        /// <param name="ticketNos">票号</param>
        /// <param name="ticketPrice">票面价</param>
        /// <param name="fuelTax">燃油</param>
        /// <param name="airportTax">机建</param>
        /// <param name="settlePrice">结算价</param>
        /// <param name="pnrNo">当前编码</param>
        /// <param name="oldPnrNo">旧编码</param>
        /// 如果订单采用的是用换编码出票政策
        /// pnrNo为换过的编码，oldPnrNo为老编码
        /// 如果不是用换编码出票政策 oldPnrNo为空
        /// <returns>S</returns>
        [HttpGet]
        public string notifiedorder(int type, string sequenceNo, string passengerNames, string ticketNos, string ticketPrice, string fuelTax, string airportTax, string settlePrice, string pnrNo, string oldPnrNo)
        {
            LoggerHelper.Info("国内订单出票成功后通知：type=" + type + "--sequenceNo=" + sequenceNo + "--passengerNames=" + passengerNames + "--ticketNos=" + ticketNos + "--ticketPrice=" + ticketPrice + "--fuelTax=" + fuelTax + "--airportTax=" + airportTax + "--pnrNo=" + pnrNo + "--settlePrice=" + settlePrice + "--oldPnrNo=" + oldPnrNo);
            Model.T_Order m_order = new Model.T_Order();
            BLL.T_Order b_order = new BLL.T_Order();
            if (!string.IsNullOrWhiteSpace(sequenceNo))
            {
                m_order = b_order.GetModel(sequenceNo);
                if (m_order != null)
                {
                    m_order.dnTotalPrice = Convert.ToDecimal(settlePrice);
                    m_order.dcOrderCode = pnrNo;
                    m_order.dtEditTime = DateTime.Now;
                    b_order.Update(m_order);
                }
            }
            return "S";
        }
        #endregion

        #region 订单支付成功
        /// <summary>
        /// 订单支付成功
        /// </summary>
        /// <param name="sequenceNo">订单号</param>
        /// <param name="buyerPaymentAccount">支付帐号</param>
        /// <param name="preCharge">支付金额</param>
        /// <param name="orderStatus">订单状态</param>
        /// <returns>S</returns>
        [HttpGet]
        public string notifiedpay(string sequenceNo, string buyerPaymentAccount, string preCharge, string orderStatus)
        {
            LoggerHelper.Info("订单支付成功：sequenceNo=" + sequenceNo + "--buyerPaymentAccount=" + buyerPaymentAccount + "--preCharge=" + preCharge + "--orderStatus=" + orderStatus);
            string sql = " update T_Order set dnIsPay=1 where dcOrderID='" + PageValidate.SQL_KILL(sequenceNo) + "' ";
            DbHelperSQL.ExecuteSql(sql);
            return "S";
        }
        #endregion

        #region 修改订单
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage editOrder([FromBody] Model.T_Order order)
        {
            BLL.T_Order b_order = new BLL.T_Order();
            Model.T_Order m_order = b_order.GetModel(order.dcOrderID);
            if (m_order != null)
            {
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

                if (b_order.Update(m_order))
                {
                    return Utils.pubResult(1);
                }
                else
                {
                    return Utils.pubResult(0);
                }
            }
            else
            {
                return Utils.pubResult(0);
            }
        }
        #endregion

        #region 获取送票员
        [HttpGet]
        public HttpResponseMessage GetSendTicketer()
        {
            string sql = "select JCName as name from BaseInfo where JCType='送票员'";
            SqlHelperTool dbhelper = new SqlHelperTool("gjcw");
            DataTable dt = dbhelper.Query(sql).Tables[0];
            return Utils.pubResult(1, "", dt);
        }
        #endregion

        #region PNR国内订单提交
        public HttpResponseMessage SubmitPNROrder([FromBody] PNRBody order)
        {
            if (order != null)
            {
                Random rd = new Random();
                string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000, 9999).ToString();

                NoSortHashtable hash = new NoSortHashtable();

                if (order.flightInfo.Persons.Count > 0)
                {
                    // 添加订单乘机人
                    hash = addOrderPersonList(order.flightInfo.Persons, orderid, hash);
                }

                // 添加去程
                hash = addOrderFlight(order.flightInfo, orderid, hash);

                // 添加订单主体

                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = b_company.GetModel(order.cid);

                if (m_company != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Order(");
                    strSql.Append("dcOrderID,dcOrderCode,dcTicketNO,dnOrderType,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcCompanyName,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dnDiscount,dnChangePrice,dnChangeDatePrice,dnChaPrice,dcContent,dcAdminID,dcAdminName,dnTicketID,dnDetailID,dcCTCT,dnStatus,dnOrderStatus,dnIsTicket,dtAddTime,dtEditTime)");
                    strSql.Append(" values (");
                    strSql.Append("@dcOrderID,@dcOrderCode,@dcTicketNO,@dnOrderType,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcCompanyName,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnServicePrice,@dnSafePrice,@dnTotalPrice,@dnDiscount,@dnChangePrice,@dnChangeDatePrice,@dnChaPrice,@dcContent,@dcAdminID,@dcAdminName,@dnTicketID,@dnDetailID,@dcCTCT,@dnStatus,@dnOrderStatus,@dnIsTicket,@dtAddTime,@dtEditTime");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcTicketNO", SqlDbType.VarChar, 100),
                        new SqlParameter("@dnOrderType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcBackDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcCompanyName", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnDiscount", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChangePrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChangeDatePrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dnChaPrice", SqlDbType.Decimal, 9),
                        new SqlParameter("@dcContent", SqlDbType.Text) ,
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4),
                        new SqlParameter("@dcCTCT", SqlDbType.VarChar, 20),
                        new SqlParameter("@dnStatus", SqlDbType.Int, 4),
                        new SqlParameter("@dnOrderStatus", SqlDbType.Int, 4),
                        new SqlParameter("@dnIsTicket", SqlDbType.Int, 4),
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime),
                        new SqlParameter("@dtEditTime", SqlDbType.SmallDateTime)
                    };

                    int tax = 0;
                    double price = 0;
                    decimal total = order.flightInfo.totalPrice;

                    parameters[0].Value = orderid;
                    parameters[1].Value = "";// 订单编码
                    parameters[2].Value = order.flightInfo.ticketNo;// 票号
                    parameters[3].Value = 0;// 订单类型（0国内航班订单1国际航班订单）
                    parameters[4].Value = 0;// 0直行  1往返
                    parameters[5].Value = order.flightInfo.sdate;
                    parameters[6].Value = "";
                    parameters[7].Value = order.flightInfo.scity;
                    parameters[8].Value = order.flightInfo.ecity;
                    parameters[9].Value = order.cid;
                    parameters[10].Value = order.cname;
                    parameters[11].Value = order.flightInfo.Persons[0].name;// 联系人
                    parameters[12].Value = order.flightInfo.Persons[0].phone;// 联系电话
                    parameters[13].Value = price;
                    parameters[14].Value = tax;
                    parameters[15].Value = m_company.dnServicePirce;
                    parameters[16].Value = 0;
                    parameters[17].Value = total;
                    parameters[18].Value = order.flightInfo.zhekou;
                    parameters[19].Value = 0;
                    parameters[20].Value = 0;
                    parameters[21].Value = 0;
                    parameters[22].Value = order.flightInfo.content;// 备注
                    parameters[23].Value = m_company.dcAdminID;
                    parameters[24].Value = m_company.dcAdminName;
                    parameters[25].Value = 0;
                    parameters[26].Value = 0;
                    parameters[27].Value = order.flightInfo.CTCT;
                    parameters[28].Value = 0;
                    parameters[29].Value = 1;
                    parameters[30].Value = 0;
                    parameters[31].Value = DateTime.Now;
                    parameters[32].Value = DateTime.Now;

                    hash.Add(strSql, parameters);

                }

                DbHelperSQL.ExecuteSqlTran(hash);

                return Utils.pubResult(1, "提交成功", "");
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }


        /// <summary>
        /// 添加航线SQL
        /// </summary>
        /// <param name="order"></param>
        /// <param name="oid"></param>
        public NoSortHashtable addOrderFlight(AirFlightInfo order, string oid, NoSortHashtable hash)
        {
            if (order != null)
            {
                BLL.T_AirCompany b_aircompany = new BLL.T_AirCompany();
                Model.T_AirCompany m_aircompany = b_aircompany.GetModel(order.airNo.Substring(0, 2));

                if (m_aircompany != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_OrderFlightInfo(");
                    strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent)");
                    strSql.Append(" values (");
                    strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSJetquay,@dcEJetquay,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcSeatMsg,@dcContent");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnFlightType", SqlDbType.Int,4) ,
                        new SqlParameter("@dnAirID", SqlDbType.Int,4) ,
                        new SqlParameter("@dcAirCode", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@dcSJetquay", SqlDbType.VarChar, 10),
                        new SqlParameter("@dcEJetquay", SqlDbType.VarChar, 10),
                        new SqlParameter("@dcSCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcECode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcSTime", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcETime", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcJixing", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4) ,
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@dcCompanyLogo", SqlDbType.Text) ,
                        new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@dcSeatMsg", SqlDbType.NVarChar, 20),
                        new SqlParameter("@dcContent", SqlDbType.NVarChar,200)
                    };

                    parameters[0].Value = Utils.getDataID("of");
                    parameters[1].Value = oid;
                    parameters[2].Value = 0;
                    parameters[3].Value = 0;
                    parameters[4].Value = 0;
                    parameters[5].Value = order.airNo;
                    parameters[6].Value = order.scity;
                    parameters[7].Value = order.ecity;
                    parameters[8].Value = order.fligthList[0].hzl;
                    parameters[9].Value = "";
                    parameters[10].Value = order.scity;
                    parameters[11].Value = order.ecity;
                    parameters[12].Value = order.fligthList[0].stime;
                    parameters[13].Value = order.fligthList[0].etime;
                    parameters[14].Value = "";
                    parameters[15].Value = m_aircompany.dcAirCompanyID;
                    parameters[16].Value = m_aircompany.dcCompanyName;
                    parameters[17].Value = m_aircompany.dcEnCompanyName;
                    parameters[18].Value = m_aircompany.dcCompanyLogo;
                    parameters[19].Value = m_aircompany.dcCompanyCode;
                    parameters[20].Value = getCangwei(order.fligthList[0].airCabin);
                    parameters[21].Value = "";
                    hash.Add(strSql, parameters);
                }
            }

            return hash;
        }

        private string getCangwei(string v)
        {
            string text = "";
            switch (v)
            {
                case "A": text = "头等舱"; break;
                case "F": text = "头等舱"; break;
                case "C": text = "商务舱"; break;
                case "J": text = "商务舱"; break;
                default: text = "经济舱"; break;
            }
            return text;
        }
        #endregion

    }
}