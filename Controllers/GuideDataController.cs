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
    public class GuideDataController : ApiController
    {
        #region 导乘机人
        [HttpGet]
        public HttpResponseMessage GuideLinkMan(string uname)
        {
            string sql = "select * from dbo.Airkx_CJR where username='" + uname + "'";
            SqlHelperTool dbhelper = new SqlHelperTool("connstr");
            DataTable dt = dbhelper.Query(sql).Tables[0];

            sql = " select dcCompanyID from T_Company where dcFirstLetter = '" + uname + "' ";
            string cid = DbHelperSQL.GetSingle(sql).ToString();

            if (dt != null && !String.IsNullOrWhiteSpace(cid))
            {
                NoSortHashtable hash = new NoSortHashtable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into T_Passenger(");
                    strSql.Append("dcPerID,dcCompanyID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType");
                    strSql.Append(") values (");
                    strSql.Append("@dcPerID,@dcCompanyID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType");
                    strSql.Append(") ");

                    SqlParameter[] parameters = {
                        new SqlParameter("@dcPerID", SqlDbType.VarChar,45) ,
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@dcPerName", SqlDbType.NVarChar,40) ,
                        new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,
                        new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,
                        new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@dcType", SqlDbType.Int,4)
                    };

                    parameters[0].Value = Utils.getDataID("per") + i;
                    parameters[1].Value = cid;
                    parameters[2].Value = dt.Rows[i]["CJRName"].ToString();
                    parameters[3].Value = dt.Rows[i]["CJRCSRQ"].ToString();
                    string no = dt.Rows[i]["CJRHZ"].ToString();
                    if (no.IndexOf("NI") > -1)
                    {
                        no = no.Substring(2, 18);
                    }
                    if (no.ToString().Length == 18)
                    {
                        parameters[4].Value = "";
                        parameters[5].Value = "";
                        parameters[6].Value = "";
                        parameters[7].Value = no;
                    }
                    else
                    {
                        parameters[4].Value = dt.Rows[i]["CJRHZ"].ToString();
                        parameters[5].Value = dt.Rows[i]["HZYXQ"].ToString();
                        parameters[6].Value = "";
                        parameters[7].Value = "";
                    }
                    if (dt.Rows[i]["CJRMobile"].ToString().Length > 11)
                    {
                        parameters[8].Value = dt.Rows[i]["CJRMobile"].ToString().Substring(0, 11);
                    }
                    else
                    {
                        parameters[8].Value = dt.Rows[i]["CJRMobile"].ToString();
                    }
                    parameters[9].Value = "";
                    parameters[10].Value = 1;
                    hash.Add(strSql, parameters);
                }
                try
                {
                    DbHelperSQL.ExecuteSqlTran(hash);
                    return Utils.pubResult(1, hash.Count.ToString(), dt.Rows.Count);
                }
                catch (Exception e)
                {
                    return Utils.pubResult(0, e.Message, "");
                }
            }
            else
            {
                return Utils.pubResult(0, "没有此账号", "");
            }
        }
        #endregion
    }
}