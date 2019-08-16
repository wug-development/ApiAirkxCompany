using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class CityController : ApiController
    {
        // GET api/<controller>/5
        public HttpResponseMessage GetCity()
        {
            string sql = " select dnCityID as id,dcCode as code,dcCityName as name,dcEnCityName as enname,dcCountry as country,dcAirPortName as airportname from T_City where dnType=2 order by dnIsHot desc, dcPinyin asc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "获取成功", dt);
        }

        /// <summary>
        /// 获取国内国际城市
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllCity()
        {
            string sql = " select dnCityID as id,dcCode as code,dcCityName as name,dcEnCityName as enname,dcPinyin as pinyin,dcCountry as country,dcAirPortName as airportname,dnIsHot as hot from T_City as gn where dnType=2 order by dnIsHot desc, dcPinyin asc";
            sql += " select dnCityID as id,dcCode as code,dcCityName as name,dcEnCityName as enname,dcPinyin as pinyin,dcCountry as country,dcAirPortName as airportname,dnIsHot as hot from T_City as gj where dnType=1 order by dnIsHot desc, dcPinyin asc";
            DataSet dt = DbHelperSQL.Query(sql);
            return Utils.pubResult(1, "获取成功", dt);
        }
    }
}