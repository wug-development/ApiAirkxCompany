using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiAirkxCompany.createOrderByPassengerService;

namespace ApiAirkxCompany
{
    public class CreateGNOrder
    {
        /// <summary>
        /// 第三方下单 停用
        /// </summary>
        /// <param name="order">订单内容</param>
        /// <param name="oid">订单ID</param>
        /// <param name="aname">订票联系人</param>
        /// <param name="aphone">订票联系人电话</param>
        /// <returns></returns>
        public static createOrderByPassengerReply createOrders(OrderBody order, string oid, string aname, string aphone)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";
            createOrderByPassengerRequest req = new createOrderByPassengerRequest();

            #region BookPnr
            wsBookPnr bookpnr = new wsBookPnr();
            wsAirSegment s = new wsAirSegment();
            s.flightNo = order.airbody.flightNo;
            s.depCode = order.airbody.orgCity;
            s.arrCode = order.airbody.dstCity;
            s.seatClass = order.airseat.seatCode;
            s.depDate = order.sdate;
            s.depTime = order.airbody.depTime;
            s.arrTime = order.airbody.arriTime;
            s.planeModel = order.airbody.planeType;
            List<wsAirSegment> segment = new List<wsAirSegment>();
            segment.Add(s);
            List<wsBookPassenger> passengers = new List<wsBookPassenger>();
            for (int i = 0; i < order.personlist.Count; i++)
            {
                wsBookPassenger p = new wsBookPassenger();
                p.name = order.personlist[i].name;
                if (order.personlist[i].type.Length == 1)
                {
                    p.type = order.personlist[i].type == "1" ? 0 : 1;
                }
                else
                {
                    p.type = order.personlist[i].type == "成人" ? 0 : 1;
                    p.typeSpecified = true;
                }
                p.identityType = getCardType(order.personlist[i].cardtype);
                p.identityNo = order.personlist[i].idcard;
                if (!string.IsNullOrWhiteSpace(order.personlist[i].csrq))
                {
                    p.birthday = order.personlist[i].csrq;
                }
                p.param1 = order.personlist[i].phone;
                passengers.Add(p);
            }

            bookpnr.parPrice = order.airseat.parPrice;
            bookpnr.parPriceSpecified = true;
            bookpnr.fuelTax = order.airbody.fuelTax;
            bookpnr.fuelTaxSpecified = true;
            bookpnr.airportTax = order.airbody.airportTax;
            bookpnr.airportTaxSpecified = true;
            bookpnr.segments = segment.ToArray();
            bookpnr.passengers = passengers.ToArray();
            #endregion


            req.agencyCode = agencyCode;
            req.sign = Utils.Md5(agencyCode + order.airseat.policyData.policyId + sCode);
            req.policyId = order.airseat.policyData.policyId;
            req.linkMan = aname; //order.personlist[0].name;
            req.linkPhone = aphone; //order.personlist[0].phone;
            if (!string.IsNullOrWhiteSpace(order.personlist[0].jjphone))
            {
                req.otherLinkMethod = order.personlist[0].jjphone;
            }
            req.notifiedUrl = "http://dakehuapi.airkx.cn/api/gnorder/notifiedorder";
            req.paymentReturnUrl = "http://dakehuapi.airkx.cn/api/gnorder/notifiedpay";
            req.outOrderNo = oid;
            req.pnrInfo = bookpnr;
            req.allowSwitchPolicy = 0;
            req.allowSwitchPolicySpecified = true;
            req.needSpeRulePolicy = 0;
            req.needSpeRulePolicySpecified = true;
            //req.b2cProfit = "";
            //req.b2cClientPay = "";
            //req.createdBy = "";
            //req.param1 = "";
            //req.param2 = "";
            //req.param3 = "";
            //req.param4 = "";
            //req.param5 = "";
            CreateOrderByPassengerServiceImpl_1_0Service oservice = new CreateOrderByPassengerServiceImpl_1_0Service();
            createOrderByPassengerReply res = oservice.createOrderByPassenger(req);
            
            if (res.returnCode == "F")
            {
                LoggerHelper.Info(" 下单失败：订单号:" + oid + "   Code:" + res.returnCode + "   Message:" + res.returnMessage);
            }
            return res;
        }

        /// <summary>
        /// 第三方下单 使用中
        /// </summary>
        /// <param name="order">订单内容</param>
        /// <param name="oid">订单ID</param>
        /// <param name="aname">订票联系人</param>
        /// <param name="aphone">订票联系人电话</param>
        /// <returns></returns>
        public static GDSBookingServiceImp.gdsBookingReply createOrder(OrderBody order, string oid, string aname, string aphone)
        {
            string agencyCode = "KX888";
            string sCode = "AEA34Pd!";

            #region BookPnr
            GDSBookingServiceImp.wsBookingSegment s = new GDSBookingServiceImp.wsBookingSegment();

            s.orgCode = order.airbody.orgCity;
            s.dstCode = order.airbody.dstCity;
            s.flightNo = order.airbody.flightNo;
            s.seatClass = order.airseat.seatCode;
            s.depDate = order.sdate;
            s.routeType = "0";
            List<GDSBookingServiceImp.wsBookingSegment> segment = new List<GDSBookingServiceImp.wsBookingSegment>();
            segment.Add(s);
            List<GDSBookingServiceImp.wsBookingPassenger> passengers = new List<GDSBookingServiceImp.wsBookingPassenger>();
            for (int i = 0; i < order.personlist.Count; i++)
            {
                GDSBookingServiceImp.wsBookingPassenger p = new GDSBookingServiceImp.wsBookingPassenger();
                p.name = order.personlist[i].name;
                if (order.personlist[i].type.Length == 1)
                {
                    p.passengerType = order.personlist[i].type;
                }
                else
                {
                    p.passengerType = order.personlist[i].type == "成人" ? "1" : "2";
                }

                p.identityType = getCardType(order.personlist[i].cardtype);
                p.identityNo = order.personlist[i].idcard;
                p.telePhone = order.personlist[i].phone;

                passengers.Add(p);
            }

            #endregion
            

            GDSBookingServiceImp.GDSBookingServiceImpl_1_0Service gdso = new GDSBookingServiceImp.GDSBookingServiceImpl_1_0Service();
            GDSBookingServiceImp.gdsBookingRequest reqs = new GDSBookingServiceImp.gdsBookingRequest();
            reqs.agencyCode = agencyCode;
            reqs.doPat = "T";
            reqs.doRT = "T";
            reqs.officeNo = "PEK455";
            reqs.contacts = new string[] { "13800001234" };// aphone
            if (order.sdate == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                reqs.leaveDate = DateTime.Now.ToString("yyyy-MM-dd");
                reqs.leaveTime = order.airbody.depTime.Replace(":", "");
            }
            else
            {
                reqs.leaveDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");
                reqs.leaveTime = order.airbody.depTime.Replace(":", "");
            }
            reqs.passengers = passengers.ToArray();
            reqs.segments = segment.ToArray();
            reqs.sign = Utils.Md5(reqs.agencyCode + reqs.doPat + reqs.doRT + reqs.leaveDate + reqs.leaveTime + sCode);
            GDSBookingServiceImp.gdsBookingReply res = gdso.gdsBooking(reqs);
            if (res.returnCode == "F")
            {
                LoggerHelper.Info(" 下单失败：订单号:" + oid + "   Code:" + res.returnCode + "   Message:" + res.returnMessage);
            }
            return res;
        }

        private static string getCardType(string v)
        {
            string text = "";
            if (v.Length == 1)
            {
                text = v;
            }
            else
            {
                switch (v)
                {
                    case "身份证": text = "1"; break;
                    case "护照": text = "2"; break;
                    case "军官证": text = "3"; break;
                    case "士兵证": text = "4"; break;
                    case "台胞证": text = "5"; break;
                    default: text = "6"; break;
                }
            }
            return text;
        }
    }
}