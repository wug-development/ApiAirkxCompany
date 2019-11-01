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
    public class PassengerController : ApiController
    {

        #region 获取乘机人列表
        /// <summary>
        /// 获取企业乘机人
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPersons(string id)
        {
            string n = PageValidate.SQL_KILL(id);
            string sql = "select dcPerID as id,dcPerName as CjrName,dcBirthday as CSRQ,dcPassportNo as HZH,dcPassportDate as HZYXQ,dcSex as Sex,dcIDNumber as idcard,dcPhone as phone,dcUrgentPhone as jingji,dcType as type,dtAddTime as adddate";
            sql += " from T_Passenger where dcCompanyID = '" + n + "' ";
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

        /// <summary>
        /// 获取企业乘机人
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPersonList(string cid)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sql = "select dcPerID as id,dcPerName as name,dcBirthday as csrq,dcPassportNo as hzh,dcPassportDate as hzyxq,dcSex as sex,dcIDNumber as idcard,dcPhone as phone,dcUrgentPhone as jjphone,dcType as type";
            sql += " from T_Passenger where dcCompanyID = '" + n + "' ";
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

        /// <summary>
        /// 获取企业乘机人
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllList(string cid)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sql = "select dcPerID as id,dcPerName as name";
            sql += " from T_Passenger where dcCompanyID = '" + n + "' ";
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
        
        [HttpGet]
        public HttpResponseMessage getPersonList(string cid, int page, int pagenum, string filtername, string filterphone)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sqlwhere = " and a.dcCompanyID = '" + n + "' and a.dcCompanyID = b.dcCompanyID ";
            if (!string.IsNullOrWhiteSpace(filtername))
            {
                sqlwhere += " and dcPerName like '% " + PageValidate.SQL_KILL(filtername) + " %' ";
            }
            if (!string.IsNullOrWhiteSpace(filterphone))
            {
                sqlwhere += " and dcPhone like '% " + PageValidate.SQL_KILL(filterphone) + " %' ";
            }
            string sqlfeild = " dcUserName as cname,dcPerID as id,dcPerName as CjrName,dcBirthday as CSRQ,dcPassportNo as HZH,dcPassportDate as HZYXQ,dcSex as Sex,dcIDNumber as idcard,a.dcPhone as phone,dcUrgentPhone as jingji,dcType as type,a.dtAddTime as adddate ";
            string sql = "select top " + (page * pagenum) + sqlfeild + " from T_Passenger a,T_Company b where 1=1 " + sqlwhere + " and a.dcPerID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcPerID from T_Passenger a,T_Company b where 1=1 " + sqlwhere + ")";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            decimal count = 0;
            if (page == 1)
            {
                string sqlcount = "select count(a.dcPerID) from T_Passenger a,T_Company b where 1=1 " + sqlwhere;
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

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <param name="id">乘机人ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage delPerson(string cid, string id)
        {
            string _cid = PageValidate.SQL_KILL(cid);
            string _id = PageValidate.SQL_KILL(id);
            string sql = " delete from T_Passenger where dcPerID='" + _id + "' and dcCompanyID='" + _cid + "' ";
            int count = DbHelperSQL.ExecuteSql(sql);
            if (count > 0)
            {
                return Utils.pubResult(1, "删除成功", "");
            }
            else
            {
                return Utils.pubResult(0, "删除失败", "");
            }
        }

        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="cid">企业ID</param>
        /// <param name="id">乘机人ID</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage savePerson([FromBody] Passenger p)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Passenger set ");
            strSql.Append(" dcPerName = @dcPerName , ");
            strSql.Append(" dcPassportNo = @dcPassportNo , ");
            strSql.Append(" dcPassportDate = @dcPassportDate , ");
            strSql.Append(" dcIDNumber = @dcIDNumber , ");
            strSql.Append(" dcPhone = @dcPhone , ");
            strSql.Append(" dcUrgentPhone = @dcUrgentPhone ");
            strSql.Append(" where dcPerID=@dcPerID  ");

            SqlParameter[] parameters = {
                new SqlParameter("@dcPerID", SqlDbType.VarChar,40) ,
                new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,
                new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,
                new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,
                new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,
                new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,
                new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,
            };

            parameters[0].Value = p.id;
            parameters[1].Value = p.name;
            parameters[2].Value = p.hzh;
            parameters[3].Value = p.hzyxq;
            parameters[4].Value = p.idcard;
            parameters[5].Value = p.phone;
            parameters[6].Value = p.jjphone;
            int count = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (count > 0)
            {
                return Utils.pubResult(1, "保存成功", "");
            }
            else
            {
                return Utils.pubResult(0, "保存失败", "");
            }
        }
    }
}