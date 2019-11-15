using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ApiAirkxCompany.Controllers
{
    public class AccountController : ApiController
    {
        // GET api/<controller>/5 ricky
        [HttpGet]
        public HttpResponseMessage Login(string uname, string upass)
        {
            string username = PageValidate.SQL_KILL(uname);
            string password = PageValidate.SQL_KILL(upass);
            string sql = " select top 1 * from T_Admin where dcAdminName = '" + username + "' and dcPassword = '" + password + "' and dnIsCheck=1 ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                sql = " select b.dcMenuID as id,b.dcMenuName as name,b.dcKey as keys from T_AdminMenu a,T_Menus b where dcAdminID = '" + dt.Rows[0]["dcAdminID"] + "' and a.dcMenuID=b.dcMenuID and b.dnIsShow=1 ";
                DataTable dt_menu = DbHelperSQL.Query(sql).Tables[0];


                sql = " select dcLimitName as name from T_AdminLimit a,T_Limits b where a.dcAdminID = '" + dt.Rows[0]["dcAdminID"] + "' and a.dcLimitID=b.dcLimitID ";
                DataTable dt_limit = DbHelperSQL.Query(sql).Tables[0];

                var obj = new
                {
                    id = dt.Rows[0]["dcAdminID"],
                    uname = dt.Rows[0]["dcAdminName"],
                    realname = dt.Rows[0]["dcRealName"],
                    menus = dt_menu,
                    limits = dt_limit
                };
                return Utils.pubResult(1, "登录成功", obj);
            }
            else
            {
                return Utils.pubResult(0);
            }
        }
        
        // GET api/<controller>/5 ricky
        [HttpGet]
        public HttpResponseMessage getList()
        {
            string sql = " select dcAdminID as id,dcAdminName as name from T_Admin where dcAdminID != 'a000001' ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return Utils.pubResult(1, "获取成功", dt);
            }
            else
            {
                return Utils.pubResult(0);
            }
        }
    }
}