using Codeplex.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
                        strsql += " ;select * from newsubairtimeinfo where AirID = " + dr["AirID"];
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

        #region 获取国内航班
        [HttpGet]
        public HttpResponseMessage GetGNFlight(string scity, string ecity, string sdate)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";
            try
            {
                string stime = Utils.GetTimeStamp();
                string url = "http://api.51book.com/" + agencyCode + "/51/search/Flight/json";
                string _params = "{\"rsIsGzip\":true,\"rqIdentification\":\"" + sCode + "\",\"timeStamp\":" + stime + "," +
                    "\"rqData\":{\"routeType\":\"OW\",\"cabinClass\":null,\"directFlight\":null,\"airline\":\"\",\"segments\":" +
                    "[{\"departureTime\":\"" + sdate + "\",\"departureAirport\":\"" + scity + "\",\"arrivalAirport\":\"" + ecity + "\"}]," +
                    "\"passengerType\":1,\"needPnr\":0}," +
                    "\"thirdUsername\":\"" + agencyCode + "\"}";
                string rqData = "{\"routeType\":\"OW\",\"cabinClass\":null,\"directFlight\":null,\"airline\":\"\",\"segments\":" +
                    "[{\"departureTime\":\"" + sdate + "\",\"departureAirport\":\"" + scity + "\",\"arrivalAirport\":\"" + ecity + "\"}]," +
                    "\"passengerType\":1,\"needPnr\":0}";
                int Timeout = 5000;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.UserAgent = null;
                request.Timeout = Timeout;
                string sign = PageValidate.Md5(_params + sCode);
                request.Headers.Add("USERNAME:" + agencyCode);
                request.Headers.Add("SIGN:" + sign);


                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("sIsGzip", "true");
                parameters.Add("rqIdentification", sCode);
                parameters.Add("timeStamp", stime);
                parameters.Add("rqData", rqData);
                parameters.Add("thirdUsername", agencyCode);
                Encoding requestEncoding = Encoding.GetEncoding("UTF-8");
                //如果需要POST数据  
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stm = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                StreamReader myStreamReader = new StreamReader(stm, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                stm.Close();
                // string retString = queryPlatDataOnlinePost(url, parameters, Timeout, _params);
                return Utils.pubResult(1, "获取成功", JsonConvert.DeserializeObject(retString));
            }
            catch
            {
                return Utils.pubResult(0);
            }
        }

        #endregion
        
        #region 获取国内航班
        [HttpGet]
        public HttpResponseMessage GetGNFlights(string scity, string ecity, string sdate)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";
            try
            {
                getAvailableFlightWithPriceAndCommision.availableFlightWithPriceAndCommisionRequest rq = new getAvailableFlightWithPriceAndCommision.availableFlightWithPriceAndCommisionRequest();
                rq.agencyCode = agencyCode;
                rq.group = "";
                rq.officeNo = "";
                rq.pid = "";
                rq.orgAirportCode = scity;
                rq.dstAirportCode = ecity;
                rq.airlineCode = "";
                rq.date = sdate;
                rq.depTime = "";
                rq.direct = "";
                rq.onlyAvailableSeat = 1;
                rq.onlyNormalCommision = 1;
                rq.onlyOnWorkingCommision = 0;
                rq.onlySelfPNR = 0;
                rq.onlyAvailableSeatSpecified = true;
                rq.onlySelfPNRSpecified = true;
                rq.onlyNormalCommisionSpecified = true;
                rq.onlyOnWorkingCommisionSpecified = true;
                rq.sign = Utils.Md5(agencyCode + rq.dstAirportCode + rq.onlyAvailableSeat +
                    rq.onlyNormalCommision + rq.onlyOnWorkingCommision + rq.onlySelfPNR + rq.orgAirportCode + sCode);
                rq.param1 = "";
                rq.param2 = "";
                rq.param3 = "";
                rq.param4 = "";
                getAvailableFlightWithPriceAndCommision.GetAvailableFlightWithPriceAndCommisionServiceImpl_1_0Service ws = new getAvailableFlightWithPriceAndCommision.GetAvailableFlightWithPriceAndCommisionServiceImpl_1_0Service();
                getAvailableFlightWithPriceAndCommision.availableFlightWithPriceAndCommisionReply rep = ws.getAvailableFlightWithPriceAndCommision(rq);
                if (rep.returnCode == "S")
                {
                    int len = rep.flightItems[0].flights.Length;
                    List<string> arr = new List<string>();
                    string _str = "", _strs = "";
                    for (int i = 0; i < len; i++)
                    {
                        string _k = rep.flightItems[0].flights[i].flightNo.Substring(0, 2);
                        if (_str.IndexOf(_k) < 0)
                        {
                            _str += "," + _k;
                        }
                        string sc = rep.flightItems[0].flights[i].orgCity;
                        if (_strs.IndexOf(sc) < 0)
                        {
                            _strs += "," + sc;
                        }
                        string ec = rep.flightItems[0].flights[i].dstCity;
                        if (_strs.IndexOf(ec) < 0)
                        {
                            _strs += "," + ec;
                        }
                    }
                    string sql = "select CarrierCode,ShortName from Airways where charindex(CarrierCode, '" + _str + "')>0 ";
                    SqlHelperTool dbhelper = new SqlHelperTool("connstr");
                    DataTable dt = dbhelper.Query(sql).Tables[0];

                    sql = " select dcCode,dcAirPortName from T_City where charindex(dcCode, '" + _strs + "')>0 ";
                    DataTable dtport = DbHelperSQL.Query(sql).Tables[0];

                    var obj = new
                    {
                        data = rep,
                        airCompany = dt,
                        airPort = dtport
                    };
                    return Utils.pubResult(1, "获取成功", obj);
                }
                else
                {
                    return Utils.pubResult(0);
                }
            }
            catch(Exception e)
            {
                return Utils.pubResult(0);
            }
        }

        #endregion

        #region 获取退改签内容
        [HttpGet]
        public HttpResponseMessage GetFlightTGQ(string flightNo, string seatCode)
        {
            string no = PageValidate.SQL_KILL(flightNo);
            string code = PageValidate.SQL_KILL(seatCode);
            string sql = " select top 1 CabVisor as content from Airkx_Visor where AirCode = '" + no + "' and CabCode like '%" + code + "%' ";
            SqlHelperTool sqltool = new SqlHelperTool("newconn");
            object obj =  sqltool.GetSingle(sql);
            if (obj != null)
            {
                return Utils.pubResult(1, "获取成功", obj.ToString());
            }
            else
            {
                return Utils.pubResult(1, "获取成功", "");
            }
        }
        #endregion

        #region 获取儿童价
        [HttpGet]
        public HttpResponseMessage GetChildPrice(string scity, string ecity, string sdate, string flightNo, string seat)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";
            getChildPolicyAndFlightService.GetChildPolicyAndFlightServiceImpl_1_0Service s = new getChildPolicyAndFlightService.GetChildPolicyAndFlightServiceImpl_1_0Service();
            getChildPolicyAndFlightService.getChildPolicyAndFlightRequest rq = new getChildPolicyAndFlightService.getChildPolicyAndFlightRequest();
            rq.agencyCode = agencyCode;
            rq.depCode = scity;
            rq.arrCode = ecity;
            rq.flightNo = flightNo;
            rq.depDate = sdate;
            rq.passengerType = "CHD";
            rq.seatClass = seat;
            rq.sign = Utils.Md5(agencyCode + ecity + scity + sCode);
            rq.param1 = "";
            rq.param2 = "";
            rq.param3 = "";
            rq.param4 = "";
            getChildPolicyAndFlightService.abstractLiantuoReply rep = s.getChildPolicyAndFlight(rq);
            if (rep.returnCode == "S")
            {
                return Utils.pubResult(1, "成功", rep);
            }
            else
            {
                return Utils.pubResult(0);
            }
        }
        #endregion

        #region Post请求

        private string queryPlatDataOnlinePost(string strUrl, IDictionary<string, string> parameters, int timeout, string p)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";
            try
            {
                if (string.IsNullOrEmpty(strUrl))
                {
                    throw new ArgumentNullException("url");
                }
                HttpWebRequest request = WebRequest.Create(strUrl) as HttpWebRequest;
                //request.ServicePoint.Expect100Continue = false;
                //request.ServicePoint.UseNagleAlgorithm = false; //是否使用 Nagle 不使用 提高效率
                                                                //request.AllowWriteStreamBuffering = false; //数据是否缓冲 false 提高效率
                request.Method = "POST";
                request.ContentType = "application/json;";//没效果
                request.Accept = "text/plain;charset=utf-8";   //该编码有效，可解决乱码问题 
                request.Headers.Add("USERNAME:" + agencyCode);
                string sign = PageValidate.Md5(p + sCode);
                request.Headers.Add("SIGN:" + sign);

                request.Timeout = timeout;


                Encoding requestEncoding = Encoding.GetEncoding("UTF-8");
                //如果需要POST数据  
                if (!(parameters == null || parameters.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in parameters.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                    byte[] data = requestEncoding.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
;
                //string retString = myStreamReader.ReadToEnd();
                //myStreamReader.Close();
                //stm.Close();

                //获取响应，并设置响应编码
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stm = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码
                }
                //读取响应流
                StreamReader myStreamReader = new StreamReader(stm, Encoding.UTF8);
                string returnData = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                response.Close();
                return returnData;
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}