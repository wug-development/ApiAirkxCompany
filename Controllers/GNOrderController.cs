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
    public class GNOrderController : ApiController
    {

        private NoSortHashtable hash = new NoSortHashtable();

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

                if (order.personlist.Count > 0)
                {
                    // 添加常用乘机人
                    addPerson(order.personlist, order.cid);
                    // 添加订单乘机人
                    addOrderPersonList(order.personlist, orderid);
                }

                // 添加去程
                if (order.airbody != null && order.airseat != null)
                {
                    addOrderFlight(order, orderid);
                }

                // 添加订单主体

                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = b_company.GetModel(order.cid);

                if (m_company != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Order(");
                    strSql.Append("dcOrderID,dcOrderCode,dnOrderType,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcCompanyName,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID");
                    strSql.Append(") values (");
                    strSql.Append("@dcOrderID,@dcOrderCode,@dnOrderType,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcCompanyName,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnServicePrice,@dnSafePrice,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime,@dnTicketID,@dnDetailID");
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
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcContent", SqlDbType.Text) ,
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime) ,
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4)
                    };

                    int tax = 0;
                    double price = order.airseat.parPrice + order.airbody.airportTax + order.airbody.fuelTax;
                    double total = price * order.personlist.Count;

                    parameters[0].Value = orderid;
                    parameters[1].Value = "";// 订单编码
                    parameters[2].Value = 0;// 订单类型（0国内航班订单1国际航班订单）
                    parameters[3].Value = 0;
                    parameters[4].Value = order.sdate;
                    parameters[5].Value = "";
                    parameters[6].Value = order.scity.name;
                    parameters[7].Value = order.ecity.name;
                    parameters[8].Value = order.cid;
                    parameters[9].Value = order.cname;
                    parameters[10].Value = order.personlist[0].name;// 联系人
                    parameters[11].Value = order.personlist[0].phone;// 联系电话
                    parameters[12].Value = price;
                    parameters[13].Value = tax;
                    parameters[14].Value = m_company.dnServicePirce;
                    parameters[15].Value = 20;
                    parameters[16].Value = total;
                    parameters[17].Value = "";// 备注
                    parameters[18].Value = m_company.dcAdminID;
                    parameters[19].Value = m_company.dcAdminName;
                    parameters[20].Value = DateTime.Now;
                    parameters[21].Value = 0;
                    parameters[22].Value = 0;

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
        public void addPerson(List<PersonList> p, string cid)
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
                    parameters[4].Value = person.hzh;
                    parameters[5].Value = person.hzyxq;
                    parameters[6].Value = person.sex;
                    parameters[7].Value = person.idcard;
                    parameters[8].Value = person.phone;
                    parameters[9].Value = person.jjphone;
                    parameters[10].Value = person.type == "成人" ? 1 : (person.type == "儿童" ? 2 : 3);
                    hash.Add(strSql, parameters);
                }
            }
        }


        /// <summary>
        /// 添加订单乘机人
        /// </summary>
        /// <param name="p">乘机人列表</param>
        /// <param name="oid">订单ID</param>
        public void addOrderPersonList(List<PersonList> p, string oid)
        {
            int i = 0;
            foreach (PersonList person in p)
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
                parameters[2].Value = person.name;
                parameters[3].Value = person.csrq;
                parameters[4].Value = person.hzh;
                parameters[5].Value = person.hzyxq;
                parameters[6].Value = person.sex;
                parameters[7].Value = person.idcard;
                parameters[8].Value = person.phone;
                parameters[9].Value = person.jjphone;
                parameters[10].Value = person.type == "成人" ? 1 : (person.type == "儿童" ? 2 : 3);
                hash.Add(strSql, parameters);
            }
        }


        /// <summary>
        /// 添加航线SQL
        /// </summary>
        /// <param name="order"></param>
        /// <param name="oid"></param>
        public void addOrderFlight(OrderBody order, string oid)
        {
            if (order != null)
            {
                BLL.T_AirCompany b_aircompany = new BLL.T_AirCompany();
                Model.T_AirCompany m_aircompany = b_aircompany.GetModel(order.airbody.flightNo.Substring(0, 2));

                if (m_aircompany != null)
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

                    parameters[0].Value = Utils.getDataID("of");
                    parameters[1].Value = oid;
                    parameters[2].Value = 0;
                    parameters[3].Value = 0;
                    parameters[4].Value = 0;
                    parameters[5].Value = order.airbody.flightNo;
                    parameters[6].Value = order.scity.airportname;
                    parameters[7].Value = order.ecity.airportname;
                    parameters[8].Value = order.scity.code;
                    parameters[9].Value = order.ecity.code;
                    parameters[10].Value = order.sdate;
                    parameters[11].Value = "";
                    parameters[12].Value = order.airbody.planeType;
                    parameters[13].Value = m_aircompany.dcAirCompanyID;
                    parameters[14].Value = m_aircompany.dcCompanyName;
                    parameters[15].Value = m_aircompany.dcEnCompanyName;
                    parameters[16].Value = m_aircompany.dcCompanyLogo;
                    parameters[17].Value = m_aircompany.dcCompanyCode;
                    parameters[18].Value = "";
                    hash.Add(strSql, parameters);
                }
            }
        }

        #endregion

    }
}