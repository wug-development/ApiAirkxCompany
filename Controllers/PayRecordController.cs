using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;

namespace ApiAirkxCompany.Controllers
{
    public class PayRecordController : ApiController
    {

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

    }
}