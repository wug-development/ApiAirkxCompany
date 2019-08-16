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
                sqlwhere = " and dcFullName like '%" + v + "%' ";
            }
            string sql = " select dcCompanyID as id,dcUserName as name,dcShortName as shortname,dcFullName as nickname from T_Company where 1=1 " + sqlwhere + " and dcParentCompanyID='' and dnIsCheck!=2  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            return Utils.pubResult(1, "获取成功", dt); 
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
            string sql = " select dcCompanyID as id,dcUserName as name,dcShortName as shortname,dcFullName as nickname from T_Company where 1=1 " + sqlwhere + " and dnIsCheck!=2  ";
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
                sqlwhere = " and dcUserName='" + v + "' ";
            }
            string sql = " select top " + (page * pagenum) + " a.dcCompanyID as id,dcUserName as name,dcPassword as pass,c.dcLinkName as linkman,c.dcPhone as phone,dnCreditLine as xinyong,1 as qiankuan,dcShortName as shortname,dcFullName as nickname,(select count (b.dcCompanyID) from dbo.T_Company b where b.dcParentCompanyID=a.dcCompanyID) as childnum from T_Company a,T_CompanyLinkMan c where dcParentCompanyID='' and dnIsCheck!=2 and a.dcCompanyID=c.dcCompanyID and a.dcCompanyID not in ( ";
            sql += " select top " + ((page - 1) * pagenum) + " dcCompanyID  from T_Company where dcParentCompanyID='' and dnIsCheck!=2 " + sqlwhere + " order by dtAddDatetime desc) " + sqlwhere + " order by dtAddDatetime desc ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            DataTable _d = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                _d = dt.AsEnumerable().Cast<DataRow>().GroupBy(p => p.Field<string>("id")).Select(p => p.FirstOrDefault()).CopyToDataTable();
            }

            object count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcCompanyID) from dbo.T_Company where dcParentCompanyID='' " + sqlwhere;
                count = DbHelperSQL.GetSingle(sqlcount);
            }

            var res = new
            {
                data = _d,
                pageCount = count
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

        #region 注册企业用户
        /// <summary>
        /// 注册企业用户
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddCompany([FromBody] Company company)
        {
            string comid = Utils.getDataID("com");
            Hashtable SQLStringList = new Hashtable();
            SQLStringList.Add(CompanyMethods.companyinfosql(), CompanyMethods.companyParams(comid, company.comInfo, company.comShorthand, company.comPass, company.comInfo.other, ""));
            for (int i = 0; i < 2; i++)
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
                SQLStringList.Add(CompanyMethods.companyinfosql(), CompanyMethods.companyParams(subcomid, company.comInfo, company.subcompany[n].comShorthand, company.subcompany[n].comPass, company.subcompany[n].other, comid));
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
            string sqlfield = "a.dcCompanyID as id,dcUserName as name,dcPassword as pass,c.dcLinkName as linkman,c.dcPhone as phone,dnCreditLine as xinyong,1 as qiankuan";
            string sql = " select " + sqlfield + " from T_Company a, T_CompanyLinkMan c where dcParentCompanyID='" + id + "' and a.dcCompanyID=c.dcCompanyID  ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            return Utils.pubResult(1, "获取成功", dt);
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
            string sqlfeild = " dcUserName as comShorthand,dcPassword as comPass,dcFullName as nickname,dcRegistrationNumber as reno,dnRegisteredFunds as remoney,dcBusinessAddress as readdr,dcMainBusiness as business,";
            sqlfeild += "dcShareholder as shareholder,dcLegalRepresentative as legal,dcLicenseRegistrationAddr as licenseAddr,dcBankAccount as bankAccount,dcOpeningBank as bankName,";
            sqlfeild += "dnCreditLine as credit,dtCheckOutDate as settleDate,dcAdminID as manager,dcOther as other";
            
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
            string sql = " select top 1 dcCompanyID as id,dcUserName as uname,dcFullName as allname,dcShortName as shortname,dcPassword as upass,dnIsCheck as status from T_Company where dcUserName = '" + n + "' and dcPassword = '" + p + "' ";
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
            string sql = "select a.dcUserName as uname, a.dcPassword as upass, dcCLMID as id,a.dcCompanyID as cid,dcLinkName as linkname,dcPhone as phone,dcEmail as email,dcQQ as qq,dcWechat as wechat"; 
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
    }
}