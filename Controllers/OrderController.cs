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

namespace ApiAirkxCompany.Controllers
{
    public class OrderController : ApiController
    {
        #region 提交国际订单
        /// <summary>
        /// 提交国际订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public HttpResponseMessage SubmitOrder([FromBody] OrderBody order)
        {
            if (order != null)
            {
                Random rd = new Random();
                string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000, 9999).ToString();
                NoSortHashtable hash = new NoSortHashtable();

                if (order.persons.Count > 0)
                {
                    // 添加常用乘机人
                    // hash = runPerson(order.persons, order.cid, hash);
                    // 添加订单乘机人
                    hash = addOrderPerson(order.persons, orderid, hash);
                }

                // 添加去程
                if (order.airinfo != null && order.airinfo.flightInfo != null && order.airinfo.flightInfo.airID > 0)
                {
                    hash = addflight(order.airinfo.flightInfo.airID, orderid, order.airinfo.airtype, 0, hash);
                    if (order.airinfo.flightInfo.toFlightInfo.Length > 0)
                    {
                        for (int i = 0; i < order.airinfo.flightInfo.toFlightInfo.Length; i++)
                        {
                            hash = addsubflight(order.airinfo.flightInfo.toFlightInfo[i], orderid, order.airinfo.airtype, 0, i, hash);
                        }
                    }
                }
                // 添加回程
                if (order.airinfo != null && order.airinfo.airtype == 1 && order.airinfo.backFlightInfo != null && order.airinfo.backFlightInfo.airID > 0)
                {
                    hash = addflight(order.airinfo.backFlightInfo.airID, orderid, order.airinfo.airtype, 1, hash);
                    if (order.airinfo.backFlightInfo.toFlightInfo.Length > 0)
                    {
                        for (int i = 0; i < order.airinfo.backFlightInfo.toFlightInfo.Length; i++)
                        {
                            hash = addsubflight(order.airinfo.backFlightInfo.toFlightInfo[i], orderid, order.airinfo.airtype, 1, i, hash);
                        }
                    }
                }
                // 添加订单主体
                BLL.T_TicketPrice b_price = new BLL.T_TicketPrice();
                Model.T_TicketPrice m_price = new Model.T_TicketPrice();

                BLL.T_Ticket b_ticket = new BLL.T_Ticket();
                Model.T_Ticket m_ticket = new Model.T_Ticket();

                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = new Model.T_Company();

                m_price = b_price.GetModel(order.airinfo.flightInfo.detailID);
                m_ticket = b_ticket.GetModel(order.airinfo.flightInfo.ticketID);
                m_company = b_company.GetModel(order.cid);


                if (m_price != null && m_ticket != null && m_company != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Order(");
                    strSql.Append("dcOrderID,dcOrderCode,dnOrderType,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcCompanyName,dcLinkName,dcPhone,dnPrice,dnTax,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID");
                    strSql.Append(") values (");
                    strSql.Append("@dcOrderID,@dcOrderCode,@dnOrderType,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcCompanyName,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime,@dnTicketID,@dnDetailID");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
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
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcContent", SqlDbType.Text) ,
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime) ,
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4)
                    };

                    int tax = order.airinfo.airtype == 1 ? m_ticket.WFS : m_ticket.DCS;
                    decimal total = (m_price.TicketPrice + tax) * order.persons.Count;

                    parameters[0].Value = orderid;
                    parameters[1].Value = "";// 订单编码
                    parameters[2].Value = 1;// 订单类型（0国内航班订单1国际航班订单）
                    parameters[3].Value = order.airinfo.airtype;
                    parameters[4].Value = order.airinfo.startDate;
                    parameters[5].Value = order.airinfo.backDate;
                    parameters[6].Value = order.airinfo.startCity;
                    parameters[7].Value = order.airinfo.backCity;
                    parameters[8].Value = order.cid;
                    parameters[9].Value = order.cname;
                    parameters[10].Value = order.persons[0].PName;// 联系人
                    parameters[11].Value = m_company.dcPhone;// 联系电话
                    parameters[12].Value = m_price.TicketPrice;
                    parameters[13].Value = tax;
                    parameters[14].Value = total;
                    parameters[15].Value = "";// 备注
                    parameters[16].Value = m_company.dcAdminID;
                    parameters[17].Value = m_company.dcAdminName;
                    parameters[18].Value = DateTime.Now;
                    parameters[19].Value = order.airinfo.flightInfo.ticketID;
                    parameters[20].Value = order.airinfo.flightInfo.detailID;

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
        /// 添加常用乘机人
        /// </summary>
        /// <param name="p">乘机人列表</param>
        /// <param name="cid">用户ID</param>
        public NoSortHashtable runPerson(List<Person> p, string cid, NoSortHashtable hash)
        {
            int i = 0;
            foreach (Person person in p)
            {
                if (String.IsNullOrEmpty(person.ID))
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
                    parameters[2].Value = person.PName;
                    parameters[3].Value = person.PBD;
                    parameters[4].Value = person.PHZ;
                    parameters[5].Value = person.PHZYXQ;
                    parameters[6].Value = person.PSEX;
                    parameters[7].Value = "";
                    parameters[8].Value = "";
                    parameters[9].Value = "";
                    parameters[10].Value = 1;
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
        public NoSortHashtable addOrderPerson(List<Person> p, string oid, NoSortHashtable hash)
        {
            int i = 0;
            foreach (Person person in p)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_OrderPerson(");
                strSql.Append("dcOPID,dcOrderID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType");
                strSql.Append(") values (");
                strSql.Append("@dcOPID,@dcOrderID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType");
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
                    new SqlParameter("@dcType", SqlDbType.Int,4)
                };

                parameters[0].Value = Utils.getDataID("op") + i++;
                parameters[1].Value = oid;
                parameters[2].Value = person.PName;
                parameters[3].Value = person.PBD;
                parameters[4].Value = person.PHZ;
                parameters[5].Value = person.PHZYXQ;
                parameters[6].Value = person.PSEX;
                parameters[7].Value = "";
                parameters[8].Value = "";
                parameters[9].Value = "";
                parameters[10].Value = 1;
                hash.Add(strSql, parameters);
            }
            return hash;
        }

        /// <summary>
        /// 添加航线
        /// </summary>
        /// <param name="airid">航班ID</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="airtype">航班类型0单程1往返</param>
        /// <param name="flighttype">航线类型0去程1回程</param>
        public NoSortHashtable addflight(int airid, string orderid, int airtype, int flighttype, NoSortHashtable hash)
        {
            BLL.T_AirFlightInfo b_flightinfo = new BLL.T_AirFlightInfo();
            Model.T_AirFlightInfo m_flightinfo = new Model.T_AirFlightInfo();

            BLL.T_AirCompany b_aircompany = new BLL.T_AirCompany();
            Model.T_AirCompany m_aircompany = new Model.T_AirCompany();

            m_flightinfo = b_flightinfo.GetModel(airid);
            if (m_flightinfo != null)
            {
                m_aircompany = b_aircompany.GetModel(m_flightinfo.CompanyCode);
                if (m_aircompany != null)
                {
                    hash = addOrderFlight(m_flightinfo, m_aircompany, orderid, airtype, flighttype, 0, hash);
                }
            }
            return hash;
        }

        /// <summary>
        /// 添加转机航线
        /// </summary>
        /// <param name="airid">航班ID</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="airtype">航班类型0单程1往返</param>
        /// <param name="flighttype">航线类型0去程1回程</param>
        /// <param name="i">第几次转机</param>
        public NoSortHashtable addsubflight(int airid, string orderid, int airtype, int flighttype, int i, NoSortHashtable hash)
        {
            BLL.T_AirFlightInfoTo b_flightinfo = new BLL.T_AirFlightInfoTo();
            Model.T_AirFlightInfoTo m_flightinfo = new Model.T_AirFlightInfoTo();

            BLL.T_AirCompany b_aircompany = new BLL.T_AirCompany();
            Model.T_AirCompany m_aircompany = new Model.T_AirCompany();

            m_flightinfo = b_flightinfo.GetModel(airid);
            if (m_flightinfo != null)
            {
                m_aircompany = b_aircompany.GetModel(m_flightinfo.CompanyCode);
                if (m_aircompany != null)
                {
                    hash = addOrderSubFlight(m_flightinfo, m_aircompany, orderid, airtype, flighttype, i + 1, hash);
                }
            }
            return hash;
        }

        /// <summary>
        /// 添加航线SQL
        /// </summary>
        /// <param name="model"></param>
        /// <param name="aircompany"></param>
        /// <param name="oid"></param>
        /// <param name="airtype"></param>
        /// <param name="flighttype"></param>
        /// <param name="i"></param>
        public NoSortHashtable addOrderFlight(Model.T_AirFlightInfo model, Model.T_AirCompany aircompany, string oid, int airtype, int flighttype, int i, NoSortHashtable hash)
        {
            if (model != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_OrderFlightInfo(");
                strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent");
                strSql.Append(") values (");
                strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcContent");
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
                    new SqlParameter("@dcContent", SqlDbType.NVarChar,200)
                };

                parameters[0].Value = Utils.getDataID("of") + i;
                parameters[1].Value = oid;
                parameters[2].Value = airtype;
                parameters[3].Value = flighttype;
                parameters[4].Value = model.AirID;
                parameters[5].Value = model.AirCode;
                parameters[6].Value = model.SPortName;
                parameters[7].Value = model.EPortName;
                parameters[8].Value = model.SCode;
                parameters[9].Value = model.ECode;
                parameters[10].Value = model.STime;
                parameters[11].Value = model.ETime;
                parameters[12].Value = model.Jixing;
                parameters[13].Value = aircompany.dcAirCompanyID;
                parameters[14].Value = aircompany.dcCompanyName;
                parameters[15].Value = aircompany.dcEnCompanyName;
                parameters[16].Value = aircompany.dcCompanyLogo;
                parameters[17].Value = aircompany.dcCompanyCode;
                parameters[18].Value = "";
                hash.Add(strSql, parameters);
            }
            return hash;
        }

        /// <summary>
        /// 添加转机航线SQL
        /// </summary>
        /// <param name="model"></param>
        /// <param name="aircompany"></param>
        /// <param name="oid"></param>
        /// <param name="airtype"></param>
        /// <param name="flighttype"></param>
        /// <param name="i"></param>
        public NoSortHashtable addOrderSubFlight(Model.T_AirFlightInfoTo model, Model.T_AirCompany aircompany, string oid, int airtype, int flighttype, int i, NoSortHashtable hash)
        {
            if (model != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_OrderFlightInfo(");
                strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent");
                strSql.Append(") values (");
                strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcContent");
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
                    new SqlParameter("@dcContent", SqlDbType.NVarChar,200)
                };

                parameters[0].Value = Utils.getDataID("oft") + i;
                parameters[1].Value = oid;
                parameters[2].Value = airtype;
                parameters[3].Value = flighttype;
                parameters[4].Value = model.AirID;
                parameters[5].Value = model.AirCode;
                parameters[6].Value = model.SPortName;
                parameters[7].Value = model.EPortName;
                parameters[8].Value = model.SCode;
                parameters[9].Value = model.ECode;
                parameters[10].Value = model.STime;
                parameters[11].Value = model.ETime;
                parameters[12].Value = model.Jixing;
                parameters[13].Value = aircompany.dcAirCompanyID;
                parameters[14].Value = aircompany.dcCompanyName;
                parameters[15].Value = aircompany.dcEnCompanyName;
                parameters[16].Value = aircompany.dcCompanyLogo;
                parameters[17].Value = aircompany.dcCompanyCode;
                parameters[18].Value = "";
                hash.Add(strSql, parameters);
            }
            return hash;
        }

        #endregion

        #region 提交定制行程
        /// <summary>
        /// 提交定制行程
        /// </summary>
        /// <param name="content">行程内容</param>
        /// <param name="cid">企业ID</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public HttpResponseMessage SubmitDingzhiOrder([FromBody] DZOrderBody order)
        {
            Random rd = new Random();
            string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000, 9999).ToString();

            try
            {
                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = new Model.T_Company();

                m_company = b_company.GetModel(PageValidate.SQL_KILL(order.cid));

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_Order(");
                strSql.Append("dcOrderID,dcOrderCode,dnOrderType,dnAirType,dcCompanyID,dcCompanyName,dcLinkName,dcPhone,dnTax,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime");
                strSql.Append(") values (");
                strSql.Append("@dcOrderID,@dcOrderCode,@dnOrderType,@dnAirType,@dcCompanyID,@dcCompanyName,@dcLinkName,@dcPhone,@dnTax,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime");
                strSql.Append(") ");

                SqlParameter[] parameters = {
                    new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dnOrderType", SqlDbType.Int,4) ,
                    new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcCompanyName", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,
                    new SqlParameter("@dcPhone", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,
                    new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                    new SqlParameter("@dcContent", SqlDbType.Text) ,
                    new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,
                    new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,
                    new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime)
                };

                int tax = 0;
                decimal total = 0;

                parameters[0].Value = orderid;
                parameters[1].Value = "";// 订单编码
                parameters[2].Value = 1;// 订单类型（0国内航班订单1国际航班订单）
                if (!string.IsNullOrWhiteSpace(order.ordertype))
                {
                    if (order.ordertype == "0")
                    {
                        parameters[2].Value = 0;
                    }
                }
                parameters[3].Value = 2;//0直飞 1往返 2定制
                parameters[4].Value = m_company.dcCompanyID;
                parameters[5].Value = m_company.dcUserName;
                parameters[6].Value = m_company.dcLinkName;// 联系人
                parameters[7].Value = m_company.dcPhone;// 联系电话
                parameters[8].Value = tax;
                parameters[9].Value = total;
                parameters[10].Value = order.content;// 备注
                parameters[11].Value = m_company.dcAdminID;
                parameters[12].Value = m_company.dcAdminName;
                parameters[13].Value = DateTime.Now;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                return Utils.pubResult(1, "提交成功", "");
            }
            catch
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }

        #endregion

        #region 获取订单列表
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getOrderList(string cid, int page, int pagenum, string sdate, string edate, string filtername, string tno, string subcid)
        {
            string sqlwhere = "";
            string _cid = "";
            if (!string.IsNullOrWhiteSpace(subcid))
            {
                _cid = PageValidate.SQL_KILL(subcid);
                sqlwhere += " and dcCompanyID = '" + _cid + "' ";
            }
            else if (!string.IsNullOrWhiteSpace(cid))
            {
                _cid = PageValidate.SQL_KILL(cid);
                sqlwhere = " and dcCompanyID = '" + _cid + "' ";
            }
            if (!string.IsNullOrWhiteSpace(sdate))
            {
                sdate = PageValidate.SQL_KILL(sdate);
                sqlwhere += " and dtAddTime > '" + sdate + "' ";
            }
            if (!string.IsNullOrWhiteSpace(edate))
            {
                edate = PageValidate.SQL_KILL(edate);
                sqlwhere += " and dtAddTime < '" + edate + "' ";
            }
            if (!string.IsNullOrWhiteSpace(filtername))
            {
                filtername = PageValidate.SQL_KILL(filtername);
                sqlwhere += " and dcLinkName like '%" + filtername + "%' ";
            }
            if (!string.IsNullOrWhiteSpace(tno))
            {
                tno = PageValidate.SQL_KILL(tno);
                sqlwhere += " and dcTicketNO = '" + tno + "' ";
            }
            string orderby = " order by dtAddTime desc ";
            string sql = " dcOrderID as OrderID,dcOrderCode as OrderCode,dcLinkName as name,dnTotalPrice as TotalPrice,dcStartCity as startCity,dcBackCity as endCity,dcStartDate as startDate,dtAddTime as addTime,dnStatus as Status,dnIsTicket as isTicket from T_Order where 1=1 " + sqlwhere;
            sql = Utils.createPageSql(sql, orderby, page, pagenum);
            string sqlcount = " select count(1) from T_Order where 1=1 " + sqlwhere;
            try
            {
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                int count = 1;
                if (page == 1) 
                {
                    count = Convert.ToInt32(DbHelperSQL.GetSingle(sqlcount));
                }
                var obj = new
                {
                    data = dt,
                    count = count
                };
                return Utils.pubResult(1, "success", obj);
            }
            catch
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }
        #endregion

        #region 获取订单详情
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getOrderInfo(string id)
        {
            string n = PageValidate.SQL_KILL(id);
            string sqlwhere = "";
            if (n != "")
            {
                sqlwhere = " and dcOrderID = '" + n + "' ";
            }
            string sql = "select * from T_Order where 1=1 " + sqlwhere;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string strsql = " select dcPerName as pername,dcSex as sex,dcPassportNo as pno,dcPhone as phone,dcIDNumber as idcard,dcType as type from T_OrderPerson where dcOrderID='" + dt.Rows[0]["dcOrderID"] + "'; ";
                strsql += " select * from T_OrderFlightInfo where  dcOrderID='" + dt.Rows[0]["dcOrderID"] + "'; ";
                DataSet ds = DbHelperSQL.Query(strsql);
                string json = Utils.tableToJson(dt);

                JArray aobj = (JArray)JsonConvert.DeserializeObject(json);
                JObject jo = JObject.Parse(aobj[0].ToString());
                jo["person"] = JArray.Parse(Utils.tableToJson(ds.Tables[0]));
                jo["flight"] = JArray.Parse(Utils.tableToJson(ds.Tables[1]));

                return Utils.pubResult(1, "success", jo);
            }
            else
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }
        #endregion

        #region 获取企业订单乘客
        [HttpGet]
        public HttpResponseMessage GetOrderPerson(string cid, int page, int pagenum, string filterdate, string filtername)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = " and b.dcCompanyID = '" + n + "' and a.dcOrderID = b.dcOrderID ";
            if (!string.IsNullOrWhiteSpace(filtername))
            {
                sqlwhere += " and dcPerName like '% " + PageValidate.SQL_KILL(filtername) + " %' ";
            }
            if (!string.IsNullOrWhiteSpace(filterdate))
            {
                string[] dates = filterdate.Split(',');
                sqlwhere += " and dtAddTime>='" + PageValidate.SQL_KILL(dates[0]) + "' ";
                sqlwhere += " and dtAddTime<='" + PageValidate.SQL_KILL(dates[1]) + "' ";
            }
            string sqlfeild = " dcPerName as CjrName,dcStartCity as scity,dcBackCity as ecity,     dcUserName as cname,dcPerID as id,dcBirthday as CSRQ,dcPassportNo as HZH,dcPassportDate as HZYXQ,dcSex as Sex,dcIDNumber as idcard,a.dcPhone as phone,dcUrgentPhone as jingji,dcType as type,a.dtAddTime as adddate ";
            string sql = "select top " + (page * pagenum) + sqlfeild + " from T_Passenger a,T_Company b where 1=1 " + sqlwhere + " and a.dcPerID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcPerID from T_Passenger a,T_Company b where 1=1 " + sqlwhere + ")";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcOPID) from T_OrderPerson a,T_Company b where 1=1 " + sqlwhere;
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
                m_order.dcStartCity = order.dcStartCity;
                m_order.dcBackCity = order.dcBackCity;
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
        
        #region 改期或退票订单
        /// <summary>
        /// 改期或退票订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage changeOrder([FromBody] changeOrderBody orderinfo)
        {
            Model.T_Order m_order = orderinfo.orderinfo;
            BLL.T_Order b_order = new BLL.T_Order();
            if (m_order != null)
            {
                Random rd = new Random();
                string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000, 9999).ToString();
                m_order.dcOrderID = orderid;
                m_order.dnStatus = 0;
                if (m_order.dnOrderStatus == 2)
                {
                    m_order.dnStatus = 1;
                }
                else
                {
                    m_order.dcAdminID = "";
                    m_order.dcAdminName = "";
                }
                m_order.dnIsTicket = 0;
                m_order.dtAddTime = DateTime.Now;
                m_order.dtEditTime = m_order.dtAddTime;
                m_order.dnIsPay = 0;

                try
                {
                    b_order.Add(m_order);
                    BLL.T_OrderPerson b_op = new BLL.T_OrderPerson();
                    for (int i = 0; i < orderinfo.personlist.Count; i++)
                    {
                        orderinfo.personlist[i].dcOrderID = orderid;
                        orderinfo.personlist[i].dcOPID = Utils.getDataID("op") + i;
                        b_op.Add(orderinfo.personlist[i]);
                    }
                    BLL.T_OrderFlightInfo b_of = new BLL.T_OrderFlightInfo();
                    orderinfo.flightinfo.dcOrderID = orderid;
                    orderinfo.flightinfo.dcOrderFlightID = Utils.getDataID("of");
                    b_of.Add(orderinfo.flightinfo);

                    return Utils.pubResult(1);
                }
                catch
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

        #region 删除订单乘机人
        [HttpGet]
        public HttpResponseMessage DelPerson(string id)
        {
            string _id = PageValidate.SQL_KILL(id);
            if (!string.IsNullOrWhiteSpace(_id))
            {
                string sql = " delete from T_OrderPerson where charindex(dcOPID, '" + _id + "')>0  ";
                int count = DbHelperSQL.ExecuteSql(sql);
                if (count > 0)
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

        #region 获取企业今日订单
        [HttpGet]
        public HttpResponseMessage GetNowOrder(string cid, int page, int pagenum)
        {
            string v = PageValidate.SQL_KILL(cid);
            string sdate = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            string edate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            string sqlwhere = " and dcCompanyID = '" + v + "' and dtAddTime > '" + sdate + "' and dtAddTime < '" + edate + "' ";
            string sql = " select top " + (page * pagenum) + " * from T_Order a where a.dcOrderID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcOrderID from T_Order where 1=1 " + sqlwhere + " order by dtAddTime desc)";
            sql += " " + sqlwhere + " order by a.dtAddTime desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            object count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcOrderID) from T_Order where 1=1 " + sqlwhere;
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

    }

    public class changeOrderBody
    {
        public Model.T_Order orderinfo { get; set; }
        public List<Model.T_OrderPerson> personlist { get; set; }
        public Model.T_OrderFlightInfo flightinfo { get; set; }
    }
}