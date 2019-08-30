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
        private Hashtable hash = new Hashtable();

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
                string orderid = DateTime.Now.ToString("yyMMddhhmm") + rd.Next(1000,9999).ToString();
                                
                if (order.persons.Count > 0) {
                    // 添加常用乘机人
                    runPerson(order.persons, order.cid);
                    // 添加订单乘机人
                    addOrderPerson(order.persons, orderid);
                }

                // 添加去程
                if (order.airinfo != null && order.airinfo.flightInfo != null && order.airinfo.flightInfo.airID > 0) {
                    addflight(order.airinfo.flightInfo.airID, orderid, order.airinfo.airtype, 0);
                    if (order.airinfo.flightInfo.toFlightInfo.Length > 0) {
                        for (int i = 0; i< order.airinfo.flightInfo.toFlightInfo.Length; i++)
                        {
                            addsubflight(order.airinfo.flightInfo.toFlightInfo[i], orderid, order.airinfo.airtype, 0, i);
                        }                        
                    }
                }
                // 添加回程
                if (order.airinfo != null && order.airinfo.airtype == 1 && order.airinfo.backFlightInfo != null && order.airinfo.backFlightInfo.airID > 0)
                {
                    addflight(order.airinfo.backFlightInfo.airID, orderid, order.airinfo.airtype, 1);
                    if (order.airinfo.backFlightInfo.toFlightInfo.Length > 0)
                    {
                        for (int i = 0; i < order.airinfo.backFlightInfo.toFlightInfo.Length; i++)
                        {
                            addsubflight(order.airinfo.backFlightInfo.toFlightInfo[i], orderid, order.airinfo.airtype, 1, i);
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
                    strSql.Append("dcOrderID,dcOrderCode,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID");
                    strSql.Append(") values (");
                    strSql.Append("@dcOrderID,@dcOrderCode,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime,@dnTicketID,@dnDetailID");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcBackDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
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
                    parameters[2].Value = order.airinfo.airtype;
                    parameters[3].Value = order.airinfo.startDate;
                    parameters[4].Value = order.airinfo.backDate;
                    parameters[5].Value = order.airinfo.startCity;
                    parameters[6].Value = order.airinfo.backCity;
                    parameters[7].Value = order.cid;
                    parameters[8].Value = m_company.dcLinkName;// 联系人
                    parameters[9].Value = m_company.dcPhone;// 联系电话
                    parameters[10].Value = m_price.TicketPrice;
                    parameters[11].Value = tax;
                    parameters[12].Value = total;
                    parameters[13].Value = "";// 备注
                    parameters[14].Value = m_company.dcAdminID;
                    parameters[15].Value = m_company.dcAdminName;
                    parameters[16].Value = DateTime.Now;
                    parameters[17].Value = order.airinfo.flightInfo.ticketID;
                    parameters[18].Value = order.airinfo.flightInfo.detailID;

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
        public void runPerson(List<Person> p, string cid)
        {
            int i = 0;
            foreach (Person person in p)
            {
                if (!String.IsNullOrEmpty(person.ID))
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Passenger(");
                    strSql.Append("dcPerID,dcCompanyID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType,dtAddTime");
                    strSql.Append(") values (");
                    strSql.Append("@dcPerID,@dcCompanyID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType,@dtAddTime");
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

                    parameters[0].Value = Utils.getDataID("per" + i++);
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
        }

        /// <summary>
        /// 添加订单乘机人
        /// </summary>
        /// <param name="p">乘机人列表</param>
        /// <param name="oid">订单ID</param>
        public void addOrderPerson(List<Person> p, string oid)
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

                parameters[0].Value = Utils.getDataID("op" + i++);
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
        }

        /// <summary>
        /// 添加航线
        /// </summary>
        /// <param name="airid">航班ID</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="airtype">航班类型0单程1往返</param>
        /// <param name="flighttype">航线类型0去程1回程</param>
        public void addflight(int airid, string orderid, int airtype, int flighttype)
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
                    addOrderFlight(m_flightinfo, m_aircompany, orderid, airtype, flighttype, 0);
                }
            }
        }

        /// <summary>
        /// 添加转机航线
        /// </summary>
        /// <param name="airid">航班ID</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="airtype">航班类型0单程1往返</param>
        /// <param name="flighttype">航线类型0去程1回程</param>
        /// <param name="i">第几次转机</param>
        public void addsubflight(int airid, string orderid, int airtype, int flighttype, int i)
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
                    addOrderSubFlight(m_flightinfo, m_aircompany, orderid, airtype, flighttype, i + 1);
                }
            }
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
        public void addOrderFlight(Model.T_AirFlightInfo model, Model.T_AirCompany aircompany, string oid, int airtype, int flighttype, int i)
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

                parameters[0].Value = Utils.getDataID("of" + i);
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
        public void addOrderSubFlight(Model.T_AirFlightInfoTo model, Model.T_AirCompany aircompany, string oid, int airtype, int flighttype, int i)
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

                parameters[0].Value = Utils.getDataID("oft" + i);
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
        }

        #endregion

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getOrderList(string cid)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = "";
            if (n != "")
            {
                sqlwhere = " and dcCompanyID = '" + n + "' ";
            }
            string sql = "select dcOrderID as OrderID,dcOrderCode as OrderCode,dnTotalPrice as TotalPrice,dcStartCity as startCity,dcBackCity as endCity,dcStartDate as startDate from T_Order where 1=1 " + sqlwhere;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];                       
            if (dt != null && dt.Rows.Count > 0)
            {
                string strsql = "";
                int qk = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strsql += " select dcPerName as pername from T_OrderPerson where dcOrderID='" + dt.Rows[i]["OrderID"] + "'; ";
                    qk += Convert.ToInt32(dt.Rows[i]["TotalPrice"]);
                }
                DataSet ds = DbHelperSQL.Query(strsql);
                string json = Utils.tableToJson(dt);
                
                JArray objA = JArray.Parse(json);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    objA[j]["person"] = JArray.Parse(Utils.tableToJson(ds.Tables[j]));
                }

                string sqlpay = "  select Count(dnMoney) from T_PayRecord where dnStatus = 1 and dcCompanyID = '" + n + "' ";
                int paycount = Convert.ToInt32(DbHelperSQL.GetSingle(sqlpay));

                var obj = new
                {
                    orderlist = objA,
                    qiankuan = (qk - paycount) > 0? (qk - paycount) : 0,
                    paycount = paycount
                };

                return Utils.pubResult(1, "success", obj);
            }
            else
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }

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
                string strsql = " select dcPerName as pername,dcSex as sex,dcPassportNo as pno,dcType as type from T_OrderPerson where dcOrderID='" + dt.Rows[0]["dcOrderID"] + "'; ";
                strsql += " select * from T_OrderFlightInfo where  dcOrderID='" + dt.Rows[0]["dcOrderID"] + "'; ";
                DataSet ds = DbHelperSQL.Query(strsql);
                string json = Utils.tableToJson(dt);

                JArray aobj = JArray.Parse(json);
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
    }
}