using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ApiAirkxCompany
{
    public class OrderTicketSql
    {
        public OrderTicketSql()
        {

        }

        #region 获取修改订单SQL
        public static NoSortHashtable getOrderSql(Model.T_Order model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Order set ");
            strSql.Append("dcOrderCode=@dcOrderCode,");
            strSql.Append("dcTicketNO=@dcTicketNO,");
            strSql.Append("dnOrderType=@dnOrderType,");
            strSql.Append("dnAirType=@dnAirType,");
            strSql.Append("dcStartDate=@dcStartDate,");
            strSql.Append("dcBackDate=@dcBackDate,");
            strSql.Append("dcStartCity=@dcStartCity,");
            strSql.Append("dcBackCity=@dcBackCity,");
            strSql.Append("dcCompanyID=@dcCompanyID,");
            strSql.Append("dcCompanyName=@dcCompanyName,");
            strSql.Append("dcLinkName=@dcLinkName,");
            strSql.Append("dcPhone=@dcPhone,");
            strSql.Append("dnPrice=@dnPrice,");
            strSql.Append("dnTax=@dnTax,");
            strSql.Append("dnServicePrice=@dnServicePrice,");
            strSql.Append("dnSafePrice=@dnSafePrice,");
            strSql.Append("dnTotalPrice=@dnTotalPrice,");
            strSql.Append("dnDiscount=@dnDiscount,");
            strSql.Append("dnChangePrice=@dnChangePrice,");
            strSql.Append("dnChangeDatePrice=@dnChangeDatePrice,");
            strSql.Append("dnChaPrice=@dnChaPrice,");
            strSql.Append("dcContent=@dcContent,");
            strSql.Append("dcAdminID=@dcAdminID,");
            strSql.Append("dcAdminName=@dcAdminName,");
            strSql.Append("dnTicketID=@dnTicketID,");
            strSql.Append("dnDetailID=@dnDetailID,");
            strSql.Append("dcCTCT=@dcCTCT,");
            strSql.Append("dnStatus=@dnStatus,");
            strSql.Append("dnOrderStatus=@dnOrderStatus,");
            strSql.Append("dnIsTicket=@dnIsTicket,");
            strSql.Append("dnIsPay=@dnIsPay,");
            strSql.Append("dtAddTime=@dtAddTime,");
            strSql.Append("dtEditTime=@dtEditTime,");
            strSql.Append("dcLiantuoOrderNo=@dcLiantuoOrderNo");
            strSql.Append(" where dcOrderID=@dcOrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40),
                    new SqlParameter("@dcTicketNO", SqlDbType.VarChar,100),
                    new SqlParameter("@dnOrderType", SqlDbType.Int,4),
                    new SqlParameter("@dnAirType", SqlDbType.Int,4),
                    new SqlParameter("@dcStartDate", SqlDbType.VarChar,20),
                    new SqlParameter("@dcBackDate", SqlDbType.VarChar,20),
                    new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30),
                    new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30),
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,40),
                    new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
                    new SqlParameter("@dnPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnTax", SqlDbType.Decimal,9),
                    new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnDiscount", SqlDbType.Decimal,9),
                    new SqlParameter("@dnChangePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnChangeDatePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dnChaPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@dcContent", SqlDbType.Text),
                    new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dnTicketID", SqlDbType.Int,4),
                    new SqlParameter("@dnDetailID", SqlDbType.Int,4),
                    new SqlParameter("@dcCTCT", SqlDbType.VarChar,20),
                    new SqlParameter("@dnStatus", SqlDbType.Int,4),
                    new SqlParameter("@dnOrderStatus", SqlDbType.Int,4),
                    new SqlParameter("@dnIsTicket", SqlDbType.Int,4),
                    new SqlParameter("@dnIsPay", SqlDbType.Int,4),
                    new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime),
                    new SqlParameter("@dtEditTime", SqlDbType.SmallDateTime),
                    new SqlParameter("@dcLiantuoOrderNo", SqlDbType.VarChar,20),
                    new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)};
            parameters[0].Value = model.dcOrderCode;
            parameters[1].Value = model.dcTicketNO;
            parameters[2].Value = model.dnOrderType;
            parameters[3].Value = model.dnAirType;
            parameters[4].Value = model.dcStartDate;
            parameters[5].Value = model.dcBackDate;
            parameters[6].Value = model.dcStartCity;
            parameters[7].Value = model.dcBackCity;
            parameters[8].Value = model.dcCompanyID;
            parameters[9].Value = model.dcCompanyName;
            parameters[10].Value = model.dcLinkName;
            parameters[11].Value = model.dcPhone;
            parameters[12].Value = model.dnPrice;
            parameters[13].Value = model.dnTax;
            parameters[14].Value = model.dnServicePrice;
            parameters[15].Value = model.dnSafePrice;
            parameters[16].Value = model.dnTotalPrice;
            parameters[17].Value = model.dnDiscount;
            parameters[18].Value = model.dnChangePrice;
            parameters[19].Value = model.dnChangeDatePrice;
            parameters[20].Value = model.dnChaPrice;
            parameters[21].Value = model.dcContent;
            parameters[22].Value = model.dcAdminID;
            parameters[23].Value = model.dcAdminName;
            parameters[24].Value = model.dnTicketID;
            parameters[25].Value = model.dnDetailID;
            parameters[26].Value = model.dcCTCT;
            parameters[27].Value = model.dnStatus;
            parameters[28].Value = model.dnOrderStatus;
            parameters[29].Value = model.dnIsTicket;
            parameters[30].Value = model.dnIsPay;
            parameters[31].Value = model.dtAddTime;
            parameters[32].Value = model.dtEditTime;
            parameters[33].Value = model.dcLiantuoOrderNo;
            parameters[34].Value = model.dcOrderID;

            hash.Add(strSql, parameters);
            return hash;
        }

        #endregion

        #region 获取添加出票单SQL
        public static NoSortHashtable getTicketSql(Model.T_TicketSheet model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_TicketSheet(");
            strSql.Append("dcTSID,dnFlightClass,dcAirCompanyName,dcOrderCode,dcStartCity,dcBackCity,dnSellPrice,dnReturnPoint1,dnReturnPoint2,dnReturnPoint3,dnTax,dnPersonNumber,dnYaoWeiPrice,dnHKYWID,dcLXR,dnShiShouPrice,dnReturnPrice,dnShiJiDaoZhang,dnJieSuanPrice,dnLiRun,dnDiJia,dnFandianPrice,dnHangXiePrice,dnCountPrice,dnYingShouPrice,dcOutTicketID,dcOutTicketName,dcCPDXX,dnTotalPrice,dcCompanyID,dcCompanyName,dcLinkName,dnFlightPrice,dcTicketNO,dcOrderID,dnServicePrice,dnSafePrice,dcStartDate,dnTicketPrice,dcRakedClass,dcPersonName,dcFlightNumber,dcFlightTime,dcOther,dcPaymentMethod1,dnPaymentPrice1,dcPaymentMethod2,dnPaymentPrice2,dcPaymentMethod3,dnPaymentPrice3,dcPaymentMethod4,dnPaymentPrice4,dnStatus,dnBonus,dnDiscount,dcSendTicketType,dcSendTicketerName,dcAddUser,dtAddTime");
            strSql.Append(") values (");
            strSql.Append("@dcTSID,@dnFlightClass,@dcAirCompanyName,@dcOrderCode,@dcStartCity,@dcBackCity,@dnSellPrice,@dnReturnPoint1,@dnReturnPoint2,@dnReturnPoint3,@dnTax,@dnPersonNumber,@dnYaoWeiPrice,@dnHKYWID,@dcLXR,@dnShiShouPrice,@dnReturnPrice,@dnShiJiDaoZhang,@dnJieSuanPrice,@dnLiRun,@dnDiJia,@dnFandianPrice,@dnHangXiePrice,@dnCountPrice,@dnYingShouPrice,@dcOutTicketID,@dcOutTicketName,@dcCPDXX,@dnTotalPrice,@dcCompanyID,@dcCompanyName,@dcLinkName,@dnFlightPrice,@dcTicketNO,@dcOrderID,@dnServicePrice,@dnSafePrice,@dcStartDate,@dnTicketPrice,@dcRakedClass,@dcPersonName,@dcFlightNumber,@dcFlightTime,@dcOther,@dcPaymentMethod1,@dnPaymentPrice1,@dcPaymentMethod2,@dnPaymentPrice2,@dcPaymentMethod3,@dnPaymentPrice3,@dcPaymentMethod4,@dnPaymentPrice4,@dnStatus,@dnBonus,@dnDiscount,@dcSendTicketType,@dcSendTicketerName,@dcAddUser,@dtAddTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@dcTSID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnFlightClass", SqlDbType.Int,4) ,
                        new SqlParameter("@dcAirCompanyName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,
                        new SqlParameter("@dnSellPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnReturnPoint1", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnReturnPoint2", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnReturnPoint3", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnPersonNumber", SqlDbType.Int,4) ,
                        new SqlParameter("@dnYaoWeiPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnHKYWID", SqlDbType.Int,4) ,
                        new SqlParameter("@dcLXR", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnShiShouPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnReturnPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnShiJiDaoZhang", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnJieSuanPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnLiRun", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnDiJia", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnFandianPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnHangXiePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnCountPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnYingShouPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcOutTicketID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcOutTicketName", SqlDbType.NVarChar,40) ,
                        new SqlParameter("@dcCPDXX", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,40) ,
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnFlightPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcTicketNO", SqlDbType.VarChar,100) ,
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dnTicketPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcRakedClass", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dcPersonName", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@dcFlightNumber", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcFlightTime", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcOther", SqlDbType.Text) ,
                        new SqlParameter("@dcPaymentMethod1", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnPaymentPrice1", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcPaymentMethod2", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnPaymentPrice2", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcPaymentMethod3", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnPaymentPrice3", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcPaymentMethod4", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dnPaymentPrice4", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnStatus", SqlDbType.Int,4) ,
                        new SqlParameter("@dnBonus", SqlDbType.Int,4) ,
                        new SqlParameter("@dnDiscount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcSendTicketType", SqlDbType.NVarChar,10) ,
                        new SqlParameter("@dcSendTicketerName", SqlDbType.NVarChar,10) ,
                        new SqlParameter("@dcAddUser", SqlDbType.NVarChar,20) ,
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime)

            };

            parameters[0].Value = model.dcTSID;
            parameters[1].Value = model.dnFlightClass;
            parameters[2].Value = model.dcAirCompanyName;
            parameters[3].Value = model.dcOrderCode;
            parameters[4].Value = model.dcStartCity;
            parameters[5].Value = model.dcBackCity;
            parameters[6].Value = model.dnSellPrice;
            parameters[7].Value = model.dnReturnPoint1;
            parameters[8].Value = model.dnReturnPoint2;
            parameters[9].Value = model.dnReturnPoint3;
            parameters[10].Value = model.dnTax;
            parameters[11].Value = model.dnPersonNumber;
            parameters[12].Value = model.dnYaoWeiPrice;
            parameters[13].Value = model.dnHKYWID;
            parameters[14].Value = model.dcLXR;
            parameters[15].Value = model.dnShiShouPrice;
            parameters[16].Value = model.dnReturnPrice;
            parameters[17].Value = model.dnShiJiDaoZhang;
            parameters[18].Value = model.dnJieSuanPrice;
            parameters[19].Value = model.dnLiRun;
            parameters[20].Value = model.dnDiJia;
            parameters[21].Value = model.dnFandianPrice;
            parameters[22].Value = model.dnHangXiePrice;
            parameters[23].Value = model.dnCountPrice;
            parameters[24].Value = model.dnYingShouPrice;
            parameters[25].Value = model.dcOutTicketID;
            parameters[26].Value = model.dcOutTicketName;
            parameters[27].Value = model.dcCPDXX;
            parameters[28].Value = model.dnTotalPrice;
            parameters[29].Value = model.dcCompanyID;
            parameters[30].Value = model.dcCompanyName;
            parameters[31].Value = model.dcLinkName;
            parameters[32].Value = model.dnFlightPrice;
            parameters[33].Value = model.dcTicketNO;
            parameters[34].Value = model.dcOrderID;
            parameters[35].Value = model.dnServicePrice;
            parameters[36].Value = model.dnSafePrice;
            parameters[37].Value = model.dcStartDate;
            parameters[38].Value = model.dnTicketPrice;
            parameters[39].Value = model.dcRakedClass;
            parameters[40].Value = model.dcPersonName;
            parameters[41].Value = model.dcFlightNumber;
            parameters[42].Value = model.dcFlightTime;
            parameters[43].Value = model.dcOther;
            parameters[44].Value = model.dcPaymentMethod1;
            parameters[45].Value = model.dnPaymentPrice1;
            parameters[46].Value = model.dcPaymentMethod2;
            parameters[47].Value = model.dnPaymentPrice2;
            parameters[48].Value = model.dcPaymentMethod3;
            parameters[49].Value = model.dnPaymentPrice3;
            parameters[50].Value = model.dcPaymentMethod4;
            parameters[51].Value = model.dnPaymentPrice4;
            parameters[52].Value = model.dnStatus;
            parameters[53].Value = model.dnBonus;
            parameters[54].Value = model.dnDiscount;
            parameters[55].Value = model.dcSendTicketType;
            parameters[56].Value = model.dcSendTicketerName;
            parameters[57].Value = model.dcAddUser;
            parameters[58].Value = model.dtAddTime;

            hash.Add(strSql, parameters);
            return hash;
        }
        #endregion

        #region 获取企业账户修改SQL
        public static NoSortHashtable getAccountSql(Model.T_CompanyAccount model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_CompanyAccount set ");

            strSql.Append(" dcCAID = @dcCAID , ");
            strSql.Append(" dcCompanyID = @dcCompanyID , ");
            strSql.Append(" dnCreditLine = @dnCreditLine , ");
            strSql.Append(" dnDebt = @dnDebt , ");
            strSql.Append(" dnPayCount = @dnPayCount , ");
            strSql.Append(" dnUrgentMoney = @dnUrgentMoney , ");
            strSql.Append(" dcLastOrderDate = @dcLastOrderDate , ");
            strSql.Append(" dnTotalTicketPrice = @dnTotalTicketPrice  ");
            strSql.Append(" where dcCAID=@dcCAID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@dcCAID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dnCreditLine", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnDebt", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnPayCount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dnUrgentMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@dcLastOrderDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dnTotalTicketPrice", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.dcCAID;
            parameters[1].Value = model.dcCompanyID;
            parameters[2].Value = model.dnCreditLine;
            parameters[3].Value = model.dnDebt;
            parameters[4].Value = model.dnPayCount;
            parameters[5].Value = model.dnUrgentMoney;
            parameters[6].Value = model.dcLastOrderDate;
            parameters[7].Value = model.dnTotalTicketPrice;

            hash.Add(strSql, parameters);
            return hash;
        }
        #endregion

        #region 获取修改行程SQL
        public static NoSortHashtable getOrderFlightSql(Model.T_OrderFlightInfo model, NoSortHashtable hash)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_OrderFlightInfo set ");
            strSql.Append("dcOrderID=@dcOrderID,");
            strSql.Append("dnAirType=@dnAirType,");
            strSql.Append("dnFlightType=@dnFlightType,");
            strSql.Append("dnAirID=@dnAirID,");
            strSql.Append("dcAirCode=@dcAirCode,");
            strSql.Append("dcSPortName=@dcSPortName,");
            strSql.Append("dcEPortName=@dcEPortName,");
            strSql.Append("dcSJetquay=@dcSJetquay,");
            strSql.Append("dcEJetquay=@dcEJetquay,");
            strSql.Append("dcSCode=@dcSCode,");
            strSql.Append("dcECode=@dcECode,");
            strSql.Append("dcSTime=@dcSTime,");
            strSql.Append("dcETime=@dcETime,");
            strSql.Append("dcJixing=@dcJixing,");
            strSql.Append("dcAirCompanyID=@dcAirCompanyID,");
            strSql.Append("dcCompanyName=@dcCompanyName,");
            strSql.Append("dcEnCompanyName=@dcEnCompanyName,");
            strSql.Append("dcCompanyLogo=@dcCompanyLogo,");
            strSql.Append("dcCompanyCode=@dcCompanyCode,");
            strSql.Append("dcSeatMsg=@dcSeatMsg,");
            strSql.Append("dcContent=@dcContent");
            strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
            SqlParameter[] parameters = {
                new SqlParameter("@dcOrderID", SqlDbType.VarChar,40),
                new SqlParameter("@dnAirType", SqlDbType.Int,4),
                new SqlParameter("@dnFlightType", SqlDbType.Int,4),
                new SqlParameter("@dnAirID", SqlDbType.Int,4),
                new SqlParameter("@dcAirCode", SqlDbType.VarChar,20),
                new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50),
                new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50),
                new SqlParameter("@dcSJetquay", SqlDbType.VarChar,10),
                new SqlParameter("@dcEJetquay", SqlDbType.VarChar,10),
                new SqlParameter("@dcSCode", SqlDbType.VarChar,10),
                new SqlParameter("@dcECode", SqlDbType.VarChar,10),
                new SqlParameter("@dcSTime", SqlDbType.VarChar,20),
                new SqlParameter("@dcETime", SqlDbType.VarChar,20),
                new SqlParameter("@dcJixing", SqlDbType.VarChar,10),
                new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4),
                new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20),
                new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50),
                new SqlParameter("@dcCompanyLogo", SqlDbType.Text),
                new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10),
                new SqlParameter("@dcSeatMsg", SqlDbType.NVarChar,20),
                new SqlParameter("@dcContent", SqlDbType.NVarChar,200),
                new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)};
            parameters[0].Value = model.dcOrderID;
            parameters[1].Value = model.dnAirType;
            parameters[2].Value = model.dnFlightType;
            parameters[3].Value = model.dnAirID;
            parameters[4].Value = model.dcAirCode;
            parameters[5].Value = model.dcSPortName;
            parameters[6].Value = model.dcEPortName;
            parameters[7].Value = model.dcSJetquay;
            parameters[8].Value = model.dcEJetquay;
            parameters[9].Value = model.dcSCode;
            parameters[10].Value = model.dcECode;
            parameters[11].Value = model.dcSTime;
            parameters[12].Value = model.dcETime;
            parameters[13].Value = model.dcJixing;
            parameters[14].Value = model.dcAirCompanyID;
            parameters[15].Value = model.dcCompanyName;
            parameters[16].Value = model.dcEnCompanyName;
            parameters[17].Value = model.dcCompanyLogo;
            parameters[18].Value = model.dcCompanyCode;
            parameters[19].Value = model.dcSeatMsg;
            parameters[20].Value = model.dcContent;
            parameters[21].Value = model.dcOrderFlightID;

            hash.Add(strSql, parameters);
            return hash;
        }
        #endregion
    }
}