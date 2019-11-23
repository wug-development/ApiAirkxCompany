using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Data.SqlClient;

namespace ApiAirkxCompany.Controllers
{
    public class PayRecordController : ApiController
    {
        #region 获取付款记录
        /// <summary>
        /// 获取付款记录
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getRecordList(string cid)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = "";
            if (n != "")
            {
                sqlwhere = " and dcCompanyID = '" + n + "' ";
            }
            string sql = "select Count(dnTotalPrice) from T_Order where 1=1 " + sqlwhere;
            sql += "; select Count(dnMoney) from T_PayRecord where dnStatus = 1 " + sqlwhere;
            sql += "; select * from T_PayRecord where dnStatus = 1 " + sqlwhere;

            DataSet ds = DbHelperSQL.Query(sql);

            if (ds != null && ds.Tables.Count > 0)
            {
                int qk = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                int paycount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                var obj = new
                {
                    recordlist = JsonConvert.DeserializeObject(Utils.tableToJson(ds.Tables[2])),
                    qiankuan = (qk - paycount) > 0 ? (qk - paycount) : 0,
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
        /// 分页获取付款记录
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <param name="page">页码</param>
        /// <param name="pagenum">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getPayList(string cid, int page, int pagenum)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = " and a.dcCompanyID in (SELECT  t.dcCompanyID FROM T_Company AS t where t.dcParentCompanyID='" + n + "' or t.dcCompanyID = '" + n + "') and a.dcCompanyID=b.dcCompanyID ";

            string sqlfield = " dcPRID as id,dnMoney as money,dcPayType as method,dcPayDate as datetime,b.dcUserName as company,dcRemarks as other,dnStatus as status ";
            string sql = " select top " + (page * pagenum) + sqlfield + "  from T_PayRecord a,T_Company b where 1=1 " + sqlwhere + " and a.dcPRID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " a.dcPRID from T_PayRecord a,T_Company b where 1=1 " + sqlwhere + " ) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcPRID) from T_PayRecord a,T_Company b where 1=1 " + sqlwhere;
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

        #region 提交付款记录
        [HttpPost]
        public HttpResponseMessage submitPayRecord([FromBody] PayRecordBody record)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_PayRecord(");
                strSql.Append("dcPRID,dcCompanyID,dnMoney,dcPayType,dcPayDate,dcRemarks,dnStatus,dcAdminID,dcAdminName,dtAddDatetime)");
                strSql.Append(" values (");
                strSql.Append("@dcPRID,@dcCompanyID,@dnMoney,@dcPayType,@dcPayDate,@dcRemarks,@dnStatus,@dcAdminID,@dcAdminName,@dtAddDatetime)");
                SqlParameter[] parameters = {
                    new SqlParameter("@dcPRID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
                    new SqlParameter("@dnMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@dcPayType", SqlDbType.NVarChar,20),
                    new SqlParameter("@dcPayDate", SqlDbType.VarChar,20),
                    new SqlParameter("@dcRemarks", SqlDbType.NVarChar,200),
                    new SqlParameter("@dnStatus", SqlDbType.Int,4),
                    new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
                    new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
                    new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime)};
                parameters[0].Value = Utils.getDataID("pr");
                parameters[1].Value = record.cid;
                parameters[2].Value = record.money;
                parameters[3].Value = record.payType;
                parameters[4].Value = record.date;
                parameters[5].Value = record.other;
                parameters[6].Value = 0;
                parameters[7].Value = record.manage.id;
                parameters[8].Value = record.manage.name;
                parameters[9].Value = DateTime.Now;
                int count = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (count > 0)
                {
                    return Utils.pubResult(1, "提交成功", "");
                }
                else
                {
                    return Utils.pubResult(0, "提交失败", "请检查数据！");
                }
            }
            catch
            {
                return Utils.pubResult(0, "提交失败", "请检查数据！");
            }
        }

        #endregion

        #region 确认收款
        [HttpGet]
        public HttpResponseMessage comfirmPay(string id, string mid)
        {
            BLL.T_Admin b_admin = new BLL.T_Admin();
            Model.T_Admin m_admin = b_admin.GetModel(mid);
            string _id = PageValidate.SQL_KILL(id);
            if (m_admin != null)
            {
                if (m_admin.dnIsCheck == 1)
                {
                    BLL.T_PayRecord b_pay = new BLL.T_PayRecord();
                    Model.T_PayRecord m_pay = b_pay.GetModel(id);
                    if (m_pay != null)
                    {
                        m_pay.dnStatus = 1;
                        m_pay.dcComfirmAdminID = mid;
                        m_pay.dcComfirmDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        b_pay.Update(m_pay);


                        BLL.T_Company b_com = new BLL.T_Company();
                        Model.T_Company m_com = new Model.T_Company();
                        m_com = b_com.GetModel(m_pay.dcCompanyID);

                        BLL.T_CompanyAccount b_caccount = new BLL.T_CompanyAccount();
                        Model.T_CompanyAccount m_caccount = b_caccount.GetCModel(m_pay.dcCompanyID);
                        m_caccount.dnPayCount += m_pay.dnMoney;
                        decimal qk = m_caccount.dnTotalTicketPrice - m_caccount.dnPayCount;
                        if (qk < 0)
                        {
                            m_caccount.dnDebt = 0;
                        }
                        else
                        {
                            m_caccount.dnDebt = qk;
                        }
                        decimal cl = m_com.dnCreditLine - Math.Abs(m_caccount.dnDebt);
                        if (cl > 0)
                        {
                            m_caccount.dnCreditLine = cl;// 可用信用额度
                            m_caccount.dnUrgentMoney = 0;// 急需结算金额
                        }
                        else
                        {
                            m_caccount.dnCreditLine = 0;
                            m_caccount.dnUrgentMoney = cl;
                        }
                        b_caccount.Update(m_caccount);

                        return Utils.pubResult(1, "保存成功", "");
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
            else
            {
                return Utils.pubResult(0);
            }
        }

        #endregion
    }
}