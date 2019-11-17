using System;
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
    public class CompanyController : ApiController
    {
        #region 获取筛选企业
        /// <summary>
        /// 获取筛选企业
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFilterCompany(string name)
        {
            string v = PageValidate.SQL_KILL(name);
            string sqlwhere = "";
            if (v != "")
            {
                sqlwhere = " and dcUserName like '%" + v + "%' or dcFirstLetter like '%" + v + "%' ";
                string sql = " select dcCompanyID as id,dcUserName as name,dcFirstLetter as firstletter,dcShortName as shortname,dcFullName as nickname from T_Company where 1=1 " + sqlwhere + " and dcParentCompanyID='' and dnIsCheck!=2  ";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                return Utils.pubResult(1, "获取成功", dt); 
            }
            else
            { 
                return Utils.pubResult(1, "获取成功", "");
            }
        }
        #endregion
        
        #region 获取筛选子企业
        /// <summary>
        /// 获取筛选企业
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFilterSubCompany(string id)
        {
            string v = PageValidate.SQL_KILL(id);
            string sqlwhere = "";
            if (v != "")
            {
                sqlwhere = " and dcParentCompanyID='" + v + "' ";
            }
            string sql = " select dcCompanyID as id,dcUserName as name,dcFirstLetter as firstletter,dcShortName as shortname,dcFullName as nickname from T_Company where 1=1 " + sqlwhere + " and dnIsCheck!=2  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            return Utils.pubResult(1, "获取成功", dt);
        }
        #endregion

        #region 获取企业用户列表
        /// <summary>
        /// 获取企业用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagenum"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCompanyList(int page, int pagenum, string filters)
        {
            string sqlwhere = "";
            if (filters != null && filters != "")
            {
                string v = PageValidate.SQL_KILL(filters);
                sqlwhere = " and dcUserName like '%" + v + "%' ";
            }
            string sql = " select top " + (page * pagenum) + " a.dcCompanyID as id,dcUserName as name,dcPassword as pass,dcFirstLetter as firstletter,c.dcLinkName as linkman,c.dcPhone as phone,b.dnCreditLine as xinyong,b.dnDebt as qiankuan,dcShortName as shortname,dcFullName as nickname,(select count (b.dcCompanyID) from dbo.T_Company b where b.dcParentCompanyID=a.dcCompanyID) as childnum from T_Company a,T_CompanyAccount b,T_CompanyLinkMan c where dcParentCompanyID='' and dnIsCheck!=2 and a.dcCompanyID=c.dcCompanyID and a.dcCompanyID=b.dcCompanyID and a.dcCompanyID not in ( ";
            sql += " select top " + ((page - 1) * pagenum) + " dcCompanyID  from T_Company where dcParentCompanyID='' and dnIsCheck!=2 " + sqlwhere + " order by dtAddDatetime desc) " + sqlwhere + " order by dtAddDatetime desc ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            DataTable _d = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                _d = dt.AsEnumerable().Cast<DataRow>().GroupBy(p => p.Field<string>("id")).Select(p => p.FirstOrDefault()).CopyToDataTable();
            }

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcCompanyID) from dbo.T_Company where dcParentCompanyID='' " + sqlwhere;
                count = Convert.ToDecimal(DbHelperSQL.GetSingle(sqlcount));
            }

            var res = new
            {
                data = _d,
                pagecount = Math.Ceiling(count / pagenum)
            };
            return Utils.pubResult(1, "获取成功", res);
        }
        #endregion

        #region 获取账单字段
        /// <summary>
        /// 获取账单字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBillFieldList()
        {
            string sql = " select dcBillFieldID as id,dcBillFieldName as name  from T_BillField where 1=1 ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "success", dt);
        }
        #endregion

        #region 获取企业账单字段
        /// <summary>
        /// 获取企业账单字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetField(string cid)
        {
            string sql = " select dcBillFieldName as name from T_CompanyBillField where 1=1 and dcCompanyID = '" + cid + "' ";// dcCBFID as id,
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "success", dt);
        }
        #endregion

        #region 注册企业用户
        /// <summary>
        /// 注册企业用户
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddCompany([FromBody] Company company)
        {
            string hand = PageValidate.SQL_KILL(company.comShorthand);
            string sql = " select count(1) from T_Company where dcUserName='" + hand + "'";
            int count = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            if (count < 1)
            {
                string comid = Utils.getDataID("com");
                NoSortHashtable SQLStringList = new NoSortHashtable();

                SQLStringList.Add(CompanyMethods.companyinfosql(), CompanyMethods.companyParams(comid, company.comInfo, company.comShorthand, company.comPass, company.firstLetter, company.comInfo.other, "", company.linkman[0]));
                SQLStringList.Add(CompanyMethods.companyaccountsql(), CompanyMethods.companyAccountParams(Utils.getDataID("cma"), comid, company.comInfo.remoney));

                for (int i = 0; i < company.linkman.Count; i++)
                {
                    SQLStringList.Add(CompanyMethods.linkmansql(), CompanyMethods.linkmanParams(Utils.getDataID("lm" + i), comid, company.linkman[i]));
                }
                string[] companyFields = company.billfields.Split(',');
                for (int m = 0; m < companyFields.Length; m++)
                {
                    SQLStringList.Add(CompanyMethods.comfieldsql(), CompanyMethods.comfieldParams(Utils.getDataID("cf" + m), comid, companyFields[m]));
                }
                for (int n = 0; n < company.subcompany.Count; n++)
                {
                    string subcomid = Utils.getDataID("coms" + n);
                    SQLStringList.Add(CompanyMethods.companyinfosql(), CompanyMethods.companyParams(subcomid, company.comInfo, company.subcompany[n].comShorthand, company.subcompany[n].comPass, company.subcompany[n].firstLetter, company.subcompany[n].other, comid, company.subcompany[n].linkmanList));
                    SQLStringList.Add(CompanyMethods.companyaccountsql(), CompanyMethods.companyAccountParams(Utils.getDataID("cma" + n), subcomid, company.comInfo.remoney));
                    SQLStringList.Add(CompanyMethods.linkmansql(), CompanyMethods.linkmanParams(Utils.getDataID("lms" + n), subcomid, company.subcompany[n].linkmanList));
                }

                try
                {
                    DbHelperSQL.ExecuteSqlTran(SQLStringList);
                    return Utils.pubResult(1);
                }
                catch
                {
                    return Utils.pubResult(0, "error", "注册失败，请检查数据！");
                }
            }
            else
            {
                return Utils.pubResult(-1, "error", "注册失败，企业简称已存在！");
            }
        }
        #endregion

        #region 编辑企业信息
        /// <summary>
        /// 编辑企业用户
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EditCompany([FromBody] Company company)
        {
            string cid = company.companyid;
            if (!string.IsNullOrWhiteSpace(cid))
            {
                string comid = PageValidate.SQL_KILL(cid);
                Dictionary<StringBuilder, SqlParameter[]> SQLStringList = new Dictionary<StringBuilder, SqlParameter[]>();

                SQLStringList.Add(CompanyMethods.companyinfoupsql(), CompanyMethods.companyUpParams(comid, company.comInfo, company.comShorthand, company.comPass, company.firstLetter, company.comInfo.other, "", company.linkman[0]));
                SQLStringList.Add(CompanyMethods.companyaccountUpSql(), CompanyMethods.companyAccountUpParams(comid, company.comInfo.remoney));

                // 企业联系人
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from T_CompanyLinkMan ");
                strSql.Append(" where dcCompanyID=@dcCompanyID ");
                SqlParameter[] parameters = {
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)  };
                parameters[0].Value = comid;

                SQLStringList.Add(strSql, parameters);

                for (int i = 0; i < company.linkman.Count; i++)
                {
                    SQLStringList.Add(CompanyMethods.linkmansql(), CompanyMethods.linkmanParams(Utils.getDataID("lm" + i), comid, company.linkman[i]));
                }

                // 企业账单显示字段
                StringBuilder strSqlacount = new StringBuilder();
                strSqlacount.Append("delete from T_CompanyBillField ");
                strSqlacount.Append(" where dcCompanyID=@dcCompanyID ");
                SqlParameter[] parameterss = {
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)  };
                parameterss[0].Value = comid;
                SQLStringList.Add(strSqlacount, parameterss);

                string[] companyFields = company.billfields.Split(',');
                for (int m = 0; m < companyFields.Length; m++)
                {
                    SQLStringList.Add(CompanyMethods.comfieldsql(), CompanyMethods.comfieldParams(Utils.getDataID("cf" + m), comid, companyFields[m]));
                }

                // 子公司
                for (int n = 0; n < company.subcompany.Count; n++)
                {
                    string subcomid = company.subcompany[n].cid;
                    // 子公司信息
                    SQLStringList.Add(CompanyMethods.companyinfoupsql(), CompanyMethods.companySubUpParams(company.comInfo, company.subcompany[n], comid));
                    // 子公司账户资金信息
                    SQLStringList.Add(CompanyMethods.companyaccountUpSql(), CompanyMethods.companyAccountUpParams(subcomid, company.comInfo.remoney));
                    // 子公司联系人
                    StringBuilder strSqls = new StringBuilder();
                    strSqls.Append("delete from T_CompanyLinkMan ");
                    strSqls.Append(" where dcCompanyID=@dcCompanyID ");
                    SqlParameter[] parametersub = {
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)  };
                    parametersub[0].Value = subcomid;

                    SQLStringList.Add(strSqls, parametersub);
                    SQLStringList.Add(CompanyMethods.linkmansql(), CompanyMethods.linkmanParams(Utils.getDataID("lms"+n), subcomid, company.subcompany[n].linkmanList));
                    
                }

                try
                {
                    DbHelperSQL.ExecuteSqlTran(SQLStringList);
                    return Utils.pubResult(1);
                }
                catch
                {
                    return Utils.pubResult(0, "error", "保存失败，请检查数据！");
                }
            }
            else
            {
                return Utils.pubResult(-1, "error", "保存失败，请刷新重试已存在！");
            }
        }
        #endregion
                
        #region 获取子公司
        /// <summary>
        /// 获取子公司
        /// </summary>
        /// <param name="id">母公司ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSubCompany(string id)
        {
            string v = PageValidate.SQL_KILL(id);
            string sqlfield = "a.dcCompanyID as id,dcUserName as name,dcFirstLetter as firstletter,dcPassword as pass,c.dcLinkName as linkman,c.dcPhone as phone,dnCreditLine as xinyong,1 as qiankuan";
            string sql = " select " + sqlfield + " from T_Company a, T_CompanyLinkMan c where dcParentCompanyID='" + id + "' and a.dcCompanyID=c.dcCompanyID  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            return Utils.pubResult(1, "获取成功", dt);
        }
        #endregion

        #region 获取企业账户信息
        /// <summary>
        /// 获取企业账户信息
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        public HttpResponseMessage getCompanyAccount(string id)
        {
            string _id = PageValidate.SQL_KILL(id);
            string sql = " select top 1 a.dnCreditLine as creditcount,b.dnCreditLine as credit ,b.dnDebt as debt ,b.dnPayCount as paycount,b.dnUrgentMoney as urgentmoney,b.dcLastOrderDate as lastdate from T_Company a, T_CompanyAccount b where a.dcCompanyID=b.dcCompanyID and a.dcCompanyID='" + _id + "' ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "success", dt);
        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email">收件人地址</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SendEmail(string email)
        {
            // 13701381359@163.com   zk721215
            string ebody = "<html> <head></head> <body> <table width='640px'> <tbody> <tr> <td> <a href='http://www.airkx.com' target='_blank'><img src='http://www.airkx.com/images/userregister.png' width='640' height='860' alt='点击重新设置密码' /></a> </td> </tr> </tbody> </table> </body> </html>";
            int res = Utils.SendMail(email, ebody, null, null, "");
            return Utils.pubResult(res);
        }
        #endregion

        #region 删除企业用户
        /// <summary>
        /// 删除企业用户
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelCompany(string id)
        {
            string v = PageValidate.SQL_KILL(id);
            string sql = " update T_Company set dnIsCheck=2 where dcCompanyID = '" + v + "' ";            
            return Utils.pubResult(DbHelperSQL.ExecuteSql(sql));
        }
        #endregion

        #region 获取企业信息
        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetInfo(string id)
        {
            string sqlfeild = " dcCompanyID as cid,dcUserName as comShorthand,dcPassword as comPass,dcFirstLetter as firstLetter,dcFullName as nickname,dcRegistrationNumber as reno,dnRegisteredFunds as remoney,dcBusinessAddress as readdr,dcMainBusiness as business,";
            sqlfeild += "dcShareholder as shareholder,dcLegalRepresentative as legal,dcLicenseRegistrationAddr as licenseAddr,dcBankAccount as bankAccount,dcOpeningBank as bankName,";
            sqlfeild += "dnCreditLine as credit,dnServicePirce as servicePirce, dtCheckOutDate as settleDate,dcAdminID as mid,dcAdminName as mname,dcOther as other";
            
            string linkfeild = "b.dcLinkName as name,b.dcPhone as phone,b.dcEmail as email,b.dcQQ as qq,b.dcWechat as wechart";

            string sql = " select " + sqlfeild + " from T_Company where dcCompanyID = '" + id + "'; ";
            sql += " select " + sqlfeild + " from T_Company where dcParentCompanyID = '" + id + "'; ";
            sql += " select " + linkfeild + " from T_CompanyLinkMan b where dcCompanyID = '" + id + "'; ";
            sql += " select " + linkfeild + " from T_Company a,T_CompanyLinkMan b where a.dcCompanyID = b.dcCompanyID and dcParentCompanyID = '" + id + "'; ";
            sql += " select dcBillFieldName as name from T_CompanyBillField where dcCompanyID = '" + id + "'; ";
            DataSet ds = DbHelperSQL.Query(sql);
            return Utils.pubResult(1, "success", ds);
        }
        #endregion

        #region 企业登录
        /// <summary>
        /// 企业登录
        /// </summary>
        /// <param name="uname">账号</param>
        /// <param name="upass">密码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Login(string uname, string upass)
        {
            string n = PageValidate.SQL_KILL(uname);
            string p = PageValidate.SQL_KILL(upass);
            string sql = " select top 1 dcCompanyID as id,dcUserName as uname,dcFirstLetter as firstletter,dcFullName as allname,dcShortName as shortname,dcPassword as upass,dnIsCheck as status from T_Company where dcUserName = '" + n + "' and dcPassword = '" + p + "' ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if(dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "1")
                {
                    return Utils.pubResult(1, "success", dt);
                }
                else
                {
                    return Utils.pubResult(0, "该账号已停用！", "");
                }
            }
            else
            {
                return Utils.pubResult(0, "用户名密码错误！", "");
            }
        }
        #endregion

        #region 获取联系人
        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetLinkman(string id)
        {
            string n = PageValidate.SQL_KILL(id);
            string sql = "select dcCLMID as id,dcCompanyID as cid,dcLinkName as linkname,dcPhone as phone,dcEmail as email,dcQQ as qq,dcWechat as wechat from T_CompanyLinkMan where dcCompanyID='" + n + "'  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return Utils.pubResult(1, "success", dt);
            }
            else
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }
        #endregion

        #region 获取子公司联系人
        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSubCompanyLinkman(string id)
        {
            string n = PageValidate.SQL_KILL(id);
            string sql = "select a.dcUserName as uname, a.dcPassword as upass, dcCLMID as id,a.dcCompanyID as cid,b.dcLinkName as linkname,b.dcPhone as phone,b.dcEmail as email,b.dcQQ as qq,b.dcWechat as wechat"; 
            sql += " from T_Company a, T_CompanyLinkMan b where a.dcParentCompanyID = '" + n + "' and a.dcCompanyID = b.dcCompanyID  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return Utils.pubResult(1, "success", dt);
            }
            else
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }
        #endregion

        #region 连续30天未出票的客户
        /// <summary>
        /// 连续30天未出票的客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getNotPurchased(int page, int pagenum)
        {
            string sqlwhere = " and a.dcCompanyID=b.dcCompanyID and b.dcLastOrderDate != '' and b.dcLastOrderDate <= '" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd") + "'";
            string sql = " select top " + (page * pagenum) + " a.dcUserName as name,b.dcLastOrderDate as lastdate from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere + " and a.dcCompanyID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " a.dcCompanyID from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere + ")  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcCompanyID) from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere;
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

        #region 需要催款的客户
        /// <summary>
        /// 需要催款的客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getMoreDateOrder(int page, int pagenum)
        {
            string sqlwhere = " and a.dcCompanyID=b.dcCompanyID and b.dnUrgentMoney > 0";
            string sql = " select top " + (page * pagenum) + " a.dcUserName as name,b.dcLastOrderDate,b.dnDebt as debt,dcLastOrderDate as lastdate,dnUrgentMoney as price,b.dnCreditLine as credit from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere + " and a.dcCompanyID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " a.dcCompanyID from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere + " ) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcCompanyID) from T_Company a,T_CompanyAccount b where 1=1 " + sqlwhere;
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
    }
}