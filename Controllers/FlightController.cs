using Codeplex.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ApiAirkxCompany.Controllers
{
    public class FlightController : ApiController
    {
        #region 获取航班列表
        /// <summary>
        /// 获取航班列表
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFlightList(string scode, string ecode, int type, int db)
        {
            string _scode = PageValidate.SQL_KILL(scode);
            string _ecode = PageValidate.SQL_KILL(ecode);
            string _type = type == 1 ? "往返" : "单程";
            string sql = "select TicketID,AirCompany,DCS,WFS from T_Ticket where CityCode like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%';" +
                " select DetailID,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM from T_TicketPrice where TicketType = '" + _type + "' and TicketID in (select TicketID from T_Ticket where  CityCode like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%');" +
                " select AirID,AirCode,SPortName,EPortName,CompanyCode,STime,ETime,Jixing from T_AirFlightInfo where SCode='" + _scode + "' AND ECode='" + _ecode + "' and CompanyCode in (select AirCompany from T_Ticket where CityCode like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%'); " +
                " ";
            if (type == 1) {
                sql += " select AirID,AirCode,SPortName,EPortName,CompanyCode,STime,ETime,Jixing from T_AirFlightInfo where SCode='" + _ecode + "' AND ECode='" + _scode + "' and CompanyCode in (select AirCompany from T_Ticket where CityCode like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%'); ";
            }
            DataSet ds = DbHelperSQL.Query(sql);

            DataTable t_jipiao = ds.Tables[0];
            DataTable piaojia = ds.Tables[1];
            DataTable hangxian = ds.Tables[2];

            string strsql = "";

            #region 票价
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Newtonsoft.Json.Linq.JArray jsonPiaojia = new Newtonsoft.Json.Linq.JArray();
            for (int i = 0; i < t_jipiao.Rows.Count; i++)
            {
                var rows = from item in piaojia.AsEnumerable()
                          where item.Field<int>("TicketID") == Convert.ToInt32(t_jipiao.Rows[i]["TicketID"])
                          select item;
                                
                string _j = Utils.tableToJson(rows, piaojia);
                var d = JsonConvert.DeserializeObject(_j);
                jsonPiaojia.Add(d);
            }
            #endregion

            #region 去程航线 转机
            Newtonsoft.Json.Linq.JArray jsonHangxian = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray jsonZhuanji = new Newtonsoft.Json.Linq.JArray();
            for (int i = 0; i < t_jipiao.Rows.Count; i++)
            {
                var rows = from item in hangxian.AsEnumerable()
                           where item.Field<string>("CompanyCode") == t_jipiao.Rows[i]["AirCompany"].ToString()
                           select item;

                string _j = Utils.tableToJson(rows, hangxian);
                var d = JsonConvert.DeserializeObject(_j);
                jsonHangxian.Add(d);

                Newtonsoft.Json.Linq.JArray hxZhuanji = new Newtonsoft.Json.Linq.JArray();
                foreach (DataRow dr in rows) { 
                    strsql = "select * from T_AirFlightInfoTo where AirID = " + dr["AirID"];
                    DataTable dsto = DbHelperSQL.Query(strsql).Tables[0];
                    string _m = Utils.tableToJson(dsto);
                    var g = JsonConvert.DeserializeObject(_m);
                    hxZhuanji.Add(g);
                }

                jsonZhuanji.Add(hxZhuanji);
            }
            #endregion

            #region 回程航线 转机
            Newtonsoft.Json.Linq.JArray jsonHangxianS = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray jsonZhuanjiS = new Newtonsoft.Json.Linq.JArray();
            if (type == 1)
            {
                DataTable hangxianS = ds.Tables[3];
                for (int i = 0; i < t_jipiao.Rows.Count; i++)
                {
                    var rows = from item in hangxianS.AsEnumerable()
                               where item.Field<string>("CompanyCode") == t_jipiao.Rows[i]["AirCompany"].ToString()
                               select item;

                    string _j = Utils.tableToJson(rows, hangxianS);
                    var d = JsonConvert.DeserializeObject(_j);
                    jsonHangxianS.Add(d);

                    Newtonsoft.Json.Linq.JArray hxZhuanjiS = new Newtonsoft.Json.Linq.JArray();
                    foreach (DataRow dr in rows)
                    {
                        strsql = "select * from T_AirFlightInfoTo where AirID = " + dr["AirID"];
                        DataTable dsto = DbHelperSQL.Query(strsql).Tables[0];
                        string _m = Utils.tableToJson(dsto);
                        var g = JsonConvert.DeserializeObject(_m);
                        hxZhuanjiS.Add(g);
                    }

                    jsonZhuanjiS.Add(hxZhuanjiS);
                }
            }
            #endregion

            var obj = new {
                jipiao = t_jipiao,
                piaojia = jsonPiaojia,
                hangxian = jsonHangxian,
                zhuanji = jsonZhuanji,
                hangxianS = jsonHangxianS,
                zhuanjiS = jsonZhuanjiS
            };

            return Utils.pubResult(1, "success", obj);
        }
        #endregion


        #region 获取航班列表_MySql
        /// <summary>
        /// 获取航班列表
        /// </summary>
        /// <param name="id">企业ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFlightList(string scode, string ecode, int type)
        {
            string _scode = PageValidate.SQL_KILL(scode);
            string _ecode = PageValidate.SQL_KILL(ecode);
            string _type = type == 1 ? "往返" : "单程";
            string sql = "select TicketID,AirCompany,DCS,WFS from pt_ticketinfo where CityCode1 like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%';" +
                " select DetailID,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM from ticketdetailinfo where TicketType = '" + _type + "' and TicketID in (select TicketID from pt_ticketinfo where  CityCode1 like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%');" +
                " select AirID,AirCode,SPortName,EPortName,CompanyCode,STime,ETime,Jixing from newairtimeinfo where SCode='" + _scode + "' AND ECode='" + _ecode + "' and CompanyCode in (select AirCompany from pt_ticketinfo where CityCode1 like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%'); " +
                " ";
            if (type == 1)
            {
                sql += " select AirID,AirCode,SPortName,EPortName,CompanyCode,STime,ETime,Jixing from newairtimeinfo where SCode='" + _ecode + "' AND ECode='" + _scode + "' and CompanyCode in (select AirCompany from pt_ticketinfo where CityCode1 like '%" + _scode + "%' AND EndCity like '%" + _ecode + "%'); ";
            }
            DataSet ds = MySqlHelper.Query(sql);

            DataTable t_jipiao = ds.Tables[0];
            DataTable piaojia = ds.Tables[1];
            DataTable hangxian = ds.Tables[2];

            string strsql = "";

            #region 票价
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Newtonsoft.Json.Linq.JArray jsonPiaojia = new Newtonsoft.Json.Linq.JArray();
            for (int i = 0; i < t_jipiao.Rows.Count; i++)
            {
                var rows = from item in piaojia.AsEnumerable()
                           where item.Field<string>("TicketID") == Convert.ToString(t_jipiao.Rows[i]["TicketID"])
                           select item;

                string _j = Utils.tableToJson(rows, piaojia);
                var d = JsonConvert.DeserializeObject(_j);
                jsonPiaojia.Add(d);
            }
            #endregion

            #region 去程航线 转机
            Newtonsoft.Json.Linq.JArray jsonHangxian = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray jsonZhuanji = new Newtonsoft.Json.Linq.JArray();
            for (int i = 0; i < t_jipiao.Rows.Count; i++)
            {
                var rows = from item in hangxian.AsEnumerable()
                           where item.Field<string>("CompanyCode") == t_jipiao.Rows[i]["AirCompany"].ToString()
                           select item;

                string _j = Utils.tableToJson(rows, hangxian);
                var d = JsonConvert.DeserializeObject(_j);
                jsonHangxian.Add(d);

                strsql = "";
                Newtonsoft.Json.Linq.JArray hxZhuanji = new Newtonsoft.Json.Linq.JArray();
                foreach (DataRow dr in rows)
                {
                    strsql += " ;select * from newsubairtimeinfo where AirID = " + dr["AirID"];
                }
                if (strsql != "")
                {
                    DataSet dsa = MySqlHelper.Query(strsql);
                    for(int m=0; m < dsa.Tables.Count; m++)
                    {
                        string _m = Utils.tableToJson(dsa.Tables[m]);
                        var g = JsonConvert.DeserializeObject(_m);
                        hxZhuanji.Add(g);
                    }
                }

                jsonZhuanji.Add(hxZhuanji);
            }
            #endregion

            #region 回程航线 转机
            Newtonsoft.Json.Linq.JArray jsonHangxianS = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray jsonZhuanjiS = new Newtonsoft.Json.Linq.JArray();
            if (type == 1)
            {
                DataTable hangxianS = ds.Tables[3];
                for (int i = 0; i < t_jipiao.Rows.Count; i++)
                {
                    var rows = from item in hangxianS.AsEnumerable()
                               where item.Field<string>("CompanyCode") == t_jipiao.Rows[i]["AirCompany"].ToString()
                               select item;

                    string _j = Utils.tableToJson(rows, hangxianS);
                    var d = JsonConvert.DeserializeObject(_j);
                    jsonHangxianS.Add(d);

                    strsql = "";
                    Newtonsoft.Json.Linq.JArray hxZhuanjiS = new Newtonsoft.Json.Linq.JArray();
                    foreach (DataRow dr in rows)
                    {
                        strsql = " ;select * from newsubairtimeinfo where AirID = " + dr["AirID"];
                    }
                    if (strsql != "")
                    {
                        DataSet dsa = MySqlHelper.Query(strsql);
                        for (int m = 0; m < dsa.Tables.Count; m++)
                        {
                            string _m = Utils.tableToJson(dsa.Tables[m]);
                            var g = JsonConvert.DeserializeObject(_m);
                            hxZhuanjiS.Add(g);
                        }
                    }

                    jsonZhuanjiS.Add(hxZhuanjiS);
                }
            }
            #endregion

            var obj = new
            {
                jipiao = t_jipiao,
                piaojia = jsonPiaojia,
                hangxian = jsonHangxian,
                zhuanji = jsonZhuanji,
                hangxianS = jsonHangxianS,
                zhuanjiS = jsonZhuanjiS
            };

            return Utils.pubResult(1, "success", obj);
        }
        #endregion
    }
}