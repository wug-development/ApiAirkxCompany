using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ApiAirkxCompany
{
    public class CompanyMethods
    {

        public static StringBuilder companyinfosql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Company(");
            strSql.Append("dcCompanyID,dcUserName,dcPassword,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dtCheckOutDate,dcLinkName,dcPhone,dcAdminID,dcAdminName,dcOther)");
            strSql.Append(" values (");
            strSql.Append("@dcCompanyID,@dcUserName,@dcPassword,@dcFullName,@dcShortName,@dcRegistrationNumber,@dnRegisteredFunds,@dcBusinessAddress,@dcMainBusiness,@dcShareholder,@dcLegalRepresentative,@dcLicenseRegistrationAddr,@dcBankAccount,@dcOpeningBank,@dcParentCompanyID,@dnCreditLine,@dtCheckOutDate,@dcLinkName,@dcPhone,@dcAdminID,@dcAdminName,@dcOther)");
            return strSql;
        }

        public static SqlParameter[] companyParams(string id, CompanyInfo comInfo, string uname, string upass, string other, string parentno, LinkMan lman)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcUserName", SqlDbType.NVarChar,40),
                    new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
                    new SqlParameter("@dcFullName", SqlDbType.NVarChar,60),
                    new SqlParameter("@dcShortName", SqlDbType.NVarChar,30),
                    new SqlParameter("@dcRegistrationNumber", SqlDbType.VarChar,32),
                    new SqlParameter("@dnRegisteredFunds", SqlDbType.Decimal,9),
                    new SqlParameter("@dcBusinessAddress", SqlDbType.NVarChar,120),
                    new SqlParameter("@dcMainBusiness", SqlDbType.NVarChar,200),
                    new SqlParameter("@dcShareholder", SqlDbType.NVarChar,200),
                    new SqlParameter("@dcLegalRepresentative", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcLicenseRegistrationAddr", SqlDbType.NVarChar,120),
                    new SqlParameter("@dcBankAccount", SqlDbType.VarChar,40),
                    new SqlParameter("@dcOpeningBank", SqlDbType.NVarChar,50),
                    new SqlParameter("@dcParentCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dnCreditLine", SqlDbType.Int,4),
                    new SqlParameter("@dtCheckOutDate", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
                    new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcOther", SqlDbType.NVarChar,200)};
            parameters[0].Value = id;
            parameters[1].Value = uname;
            parameters[2].Value = upass;
            parameters[3].Value = comInfo.nickname;
            parameters[4].Value = uname;
            parameters[5].Value = comInfo.reno;
            if (comInfo.remoney == "" || comInfo.remoney == null)
            {
                parameters[6].Value = 0;
            }
            else
            {
                parameters[6].Value = comInfo.remoney;
            }
            parameters[7].Value = comInfo.readdr;
            parameters[8].Value = comInfo.business;
            parameters[9].Value = comInfo.shareholder;
            parameters[10].Value = comInfo.legal;
            parameters[11].Value = comInfo.licenseAddr;
            parameters[12].Value = comInfo.bankAccount;
            parameters[13].Value = comInfo.bankName;
            parameters[14].Value = parentno;
            parameters[15].Value = comInfo.credit;
            parameters[16].Value = DateTime.Now;
            parameters[17].Value = lman.name;
            parameters[18].Value = lman.phone;
            parameters[19].Value = comInfo.manager.id;
            parameters[20].Value = comInfo.manager.name;
            parameters[21].Value = other;
            return parameters;
        }


        public static StringBuilder companyaccountsql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_CompanyAccount(");
            strSql.Append("dcCAID,dcCompanyID,dnCreditLine,dnDebt,dnPayCount,dnUrgentMoney,dcLastOrderDate)");
            strSql.Append(" values (");
            strSql.Append("@dcCAID,@dcCompanyID,@dnCreditLine,@dnDebt,@dnPayCount,@dnUrgentMoney,@dcLastOrderDate)");
            return strSql;
        }

        /// <summary>
        /// 添加企业账户信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="comid">企业ID</param>
        /// <param name="credit">信用额</param>
        /// <returns></returns>
        public static SqlParameter[] companyAccountParams(string id, string comid, string credit)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCAID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dnCreditLine", SqlDbType.Decimal,9),
                    new SqlParameter("@dnDebt", SqlDbType.Decimal,9),
                    new SqlParameter("@dnPayCount", SqlDbType.Decimal,9),
                    new SqlParameter("@dnUrgentMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@dcLastOrderDate", SqlDbType.VarChar,20)};
            parameters[0].Value = id;
            parameters[1].Value = comid;
            parameters[2].Value = credit;
            parameters[3].Value = 0;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = "";
            return parameters;
        }

        public static StringBuilder linkmansql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_CompanyLinkMan(");
            strSql.Append("dcCLMID,dcCompanyID,dcLinkName,dcPhone,dcEmail,dcQQ,dcWechat)");
            strSql.Append(" values (");
            strSql.Append("@dcCLMID,@dcCompanyID,@dcLinkName,@dcPhone,@dcEmail,@dcQQ,@dcWechat)");
            return strSql;
        }

        public static SqlParameter[] linkmanParams(string id, string comid, LinkMan linkman)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCLMID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
                    new SqlParameter("@dcEmail", SqlDbType.VarChar,60),
                    new SqlParameter("@dcQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@dcWechat", SqlDbType.VarChar,50)};
            parameters[0].Value = id;
            parameters[1].Value = comid;
            parameters[2].Value = linkman.name;
            parameters[3].Value = linkman.phone;
            parameters[4].Value = linkman.email;
            parameters[5].Value = linkman.qq;
            parameters[6].Value = linkman.wechart;
            return parameters;
        }

        public static StringBuilder comfieldsql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_CompanyBillField(");
            strSql.Append("dcCBFID,dcBillFieldName,dcCompanyID)");
            strSql.Append(" values (");
            strSql.Append("@dcCBFID,@dcBillFieldName,@dcCompanyID)");
            return strSql;
        }

        public static SqlParameter[] comfieldParams(string id, string comid, string name)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCBFID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcBillFieldName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)};
            parameters[0].Value = id;
            parameters[1].Value = name;
            parameters[2].Value = comid;
            return parameters;
        }

        public static StringBuilder delcomfieldSql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_CompanyBillField ");
            strSql.Append(" where dcCompanyID=@dcCompanyID ");
            return strSql;
        }

        public static SqlParameter[] delcomfieldParams(string comid)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)          };
            parameters[0].Value = comid;
            return parameters;
        }
    }
}