using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage getPersonList(string cid)
        {
            string n = PageValidate.SQL_KILL(cid);
            string sql = "select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and a.dcCompanyID = '" + n + "'";
            sql += " union all select a.*,b.dcUserName as uname from T_Passenger a,T_Company b where 1=1 and a.dcCompanyID in (select dcCompanyID from T_Company where dcParentCompanyID= '" + n + "'  )";

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
    }
}