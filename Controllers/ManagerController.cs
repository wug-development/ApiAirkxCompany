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
    public class ManagerController : ApiController
    {
        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetList(int page, int pagenum)
        {
            string sql = "select top " + (page * pagenum) + " dcAdminID as id,dcAdminName as name,dcPassword as pass,dcPhone as phone,dcQQ as qq from T_Admin where dcAdminID not in (";
            sql += " select top " + ((page - 1) * pagenum) + " dcAdminID from T_Admin where dnIsCheck != 2 and dcAdminID != 'a000001' order by dtAddDate desc) and dnIsCheck != 2 and dcAdminID != 'a000001' order by dtAddDate desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            object count = 0;
            if (page == 1)
            {
                string sqlcount = "select count (dcAdminID) from dbo.T_Admin where dnIsCheck != 2 and dcAdminID != 'a000001' ";
                count = DbHelperSQL.GetSingle(sqlcount);
            }

            var obj = new
            {
                pagecount = count,
                data = dt
            };
            return Utils.pubResult(1, "获取成功", obj);
        }

        [HttpGet]
        public HttpResponseMessage GetList()
        {
            string sql = " select dcAdminID as id,dcAdminName as name from T_Admin where dnIsCheck != 2";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }

        [HttpGet]
        public HttpResponseMessage DelUser(string id)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Admin set ");
			strSql.Append("dnIsCheck=2 ");
			strSql.Append("where ");
			strSql.Append("dcAdminID=@dcAdminID ");

			SqlParameter[] parameters = {
                new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
            };
            parameters[0].Value = id;

            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return Utils.pubResult(rows);
        }

        [HttpGet]
        public HttpResponseMessage AddUser(string name, string pass, string phone, string qq)
        {
            BLL.T_Admin b_admin = new BLL.T_Admin();
            Model.T_Admin m_admin = new Model.T_Admin();

            int num = b_admin.GetModelList(" dcAdminName='" + name + "' ").Count;
            if (num > 0)
            {
                return Utils.pubResult(-1, "用户已存在", "");
            }
            else
            {
                m_admin.dcAdminID = Utils.getDataID("a");
                m_admin.dcAdminName = name;
                m_admin.dcRealName = name;
                m_admin.dcPassword = pass;
                m_admin.dcPhone = phone;
                m_admin.dcQQ = qq;
                return Utils.pubResult(b_admin.Add(m_admin) ? 1 : 0);
            }
        }

        [HttpGet]
        public HttpResponseMessage EditUser(string id, string name, string pass, string phone, string qq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Admin set ");
            strSql.Append("dcAdminName=@dcAdminName, ");
            strSql.Append("dcPassword=@dcPassword, ");
            strSql.Append("dcRealName=@dcRealName, ");
            strSql.Append("dcPhone=@dcPhone, ");
            strSql.Append("dcQQ=@dcQQ ");
            strSql.Append("where ");
            strSql.Append("dcAdminID=@dcAdminID ");

            SqlParameter[] parameters = {
                new SqlParameter("@dcAdminName", SqlDbType.VarChar,20),
                new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
                new SqlParameter("@dcRealName", SqlDbType.VarChar,20),
                new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
                new SqlParameter("@dcQQ", SqlDbType.VarChar,20),
                new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
            };
            parameters[0].Value = name;
            parameters[1].Value = pass;
            parameters[2].Value = name;
            parameters[3].Value = phone;
            parameters[4].Value = qq;
            parameters[5].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return Utils.pubResult(rows);
        }
    }
}