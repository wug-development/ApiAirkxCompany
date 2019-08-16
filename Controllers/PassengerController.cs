using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class PassengerController : ApiController
    {

        #region 获取乘机人
        /// <summary>
        /// 获取乘机人
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
        #endregion
    }
}