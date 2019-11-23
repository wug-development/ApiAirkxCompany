using Newtonsoft.Json;
using System;
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
    public class PeopleController : ApiController
    {
        /// <summary>
        /// 获取乘机人列表
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getPersonList(string cid, int page, int pagenum, string filtername)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = "";
            filtername = PageValidate.SQL_KILL(filtername);
            if (!string.IsNullOrWhiteSpace(filtername))
            {
                sqlwhere = " and a.dcPerName like '%" + filtername + "%' ";
            }
            string orderby = " order by dtAddTime desc ";
            string sql = " * from(select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and a.dcCompanyID = '" + n + "'"+ sqlwhere + " and a.dcCompanyID=b.dcCompanyID ";
            sql += " union all select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and b.dcParentCompanyID = '" + n + "'" + sqlwhere + " and a.dcCompanyID=b.dcCompanyID) as tb ";

            sql = Utils.createPageSql(sql, orderby, page, pagenum);


            try
            {
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                int count = 0;
                if (page == 1)
                {
                    string sqlcount = " select count(1) from (" +
                        "select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and a.dcCompanyID = '" + n + "'" + sqlwhere + " and a.dcCompanyID=b.dcCompanyID" +
                        " union all select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and b.dcParentCompanyID = '" + n + "'" + sqlwhere + " and a.dcCompanyID=b.dcCompanyID" +
                        ") as t ";
                    count = Convert.ToInt32(DbHelperSQL.GetSingle(sqlcount));
                }
                var obj = new { 
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

        /// <summary>
        /// 保存乘机人
        /// </summary>
        /// <param name="person">乘机人信息</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage savePerson([FromBody] Persons person)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Passenger set ");
            strSql.Append("dcPerName=@dcPerName,");
            strSql.Append("dcBirthday=@dcBirthday,");
            strSql.Append("dcPassportNo=@dcPassportNo,");
            strSql.Append("dcPassportDate=@dcPassportDate,");
            strSql.Append("dcSex=@dcSex,");
            strSql.Append("dcIDNumber=@dcIDNumber,");
            strSql.Append("dcPhone=@dcPhone,");
            strSql.Append("dcUrgentPhone=@dcUrgentPhone");
            strSql.Append(" where dcPerID=@dcPerID ");
            SqlParameter[] parameters = {
                new SqlParameter("@dcPerName", SqlDbType.NVarChar,20),
                new SqlParameter("@dcBirthday", SqlDbType.VarChar,20),
                new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25),
                new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20),
                new SqlParameter("@dcSex", SqlDbType.NVarChar,10),
                new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20),
                new SqlParameter("@dcPhone", SqlDbType.VarChar,20),
                new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20),
                new SqlParameter("@dcPerID", SqlDbType.VarChar,40)};

            parameters[0].Value = person.CjrName;
            parameters[1].Value = person.CSRQ;
            parameters[2].Value = person.HZH;
            parameters[3].Value = person.HZYXQ;
            parameters[4].Value = person.Sex;
            parameters[5].Value = person.idcard;
            parameters[6].Value = person.phone;
            parameters[7].Value = person.jingji;
            parameters[8].Value = person.id;
            int count = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            if (count > 0)
            {
                return Utils.pubResult(1, "success", "");
            }
            else
            {
                return Utils.pubResult(0, "获取失败", "");
            }
        }
    }
}