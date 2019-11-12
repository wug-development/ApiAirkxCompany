using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_TicketSheet
		public class T_TicketSheet
	{
   		     
      		
		private string _dctsid;
		/// <summary>
		/// 出票单ID
        /// </summary>	
        public string dcTSID
        {
            get{ return _dctsid; }
            set{ _dctsid = value; }
        }        
			
		private int _dnflightclass;
		/// <summary>
		/// 航班类型(0国内1国际)
        /// </summary>	
        public int dnFlightClass
        {
            get{ return _dnflightclass; }
            set{ _dnflightclass = value; }
        }        
			
		private string _dcaircompanyname;
		/// <summary>
		/// 航空公司中文名称
        /// </summary>	
        public string dcAirCompanyName
        {
            get{ return _dcaircompanyname; }
            set{ _dcaircompanyname = value; }
        }        
			
		private string _dcordercode;
		/// <summary>
		/// 记录编号
        /// </summary>	
        public string dcOrderCode
        {
            get{ return _dcordercode; }
            set{ _dcordercode = value; }
        }        
			
		private string _dcstartcity;
		/// <summary>
		/// 出发城市
        /// </summary>	
        public string dcStartCity
        {
            get{ return _dcstartcity; }
            set{ _dcstartcity = value; }
        }        
			
		private string _dcbackcity;
		/// <summary>
		/// 目的地
        /// </summary>	
        public string dcBackCity
        {
            get{ return _dcbackcity; }
            set{ _dcbackcity = value; }
        }        
			
		private decimal _dnsellprice;
		/// <summary>
		/// 销售价
        /// </summary>	
        public decimal dnSellPrice
        {
            get{ return _dnsellprice; }
            set{ _dnsellprice = value; }
        }        
			
		private decimal _dnreturnpoint1;
		/// <summary>
		/// 返点1
        /// </summary>	
        public decimal dnReturnPoint1
        {
            get{ return _dnreturnpoint1; }
            set{ _dnreturnpoint1 = value; }
        }        
			
		private decimal _dnreturnpoint2;
		/// <summary>
		/// 返点2
        /// </summary>	
        public decimal dnReturnPoint2
        {
            get{ return _dnreturnpoint2; }
            set{ _dnreturnpoint2 = value; }
        }        
			
		private decimal _dnreturnpoint3;
		/// <summary>
		/// 返点3
        /// </summary>	
        public decimal dnReturnPoint3
        {
            get{ return _dnreturnpoint3; }
            set{ _dnreturnpoint3 = value; }
        }        
			
		private decimal _dntax;
		/// <summary>
		/// 税
        /// </summary>	
        public decimal dnTax
        {
            get{ return _dntax; }
            set{ _dntax = value; }
        }        
			
		private int _dnpersonnumber;
		/// <summary>
		/// 人数
        /// </summary>	
        public int dnPersonNumber
        {
            get{ return _dnpersonnumber; }
            set{ _dnpersonnumber = value; }
        }        
			
		private decimal _dnyaoweiprice;
		/// <summary>
		/// 要位费
        /// </summary>	
        public decimal dnYaoWeiPrice
        {
            get{ return _dnyaoweiprice; }
            set{ _dnyaoweiprice = value; }
        }        
			
		private int _dnhkywid;
		/// <summary>
		/// 人ID(FinanceDB-HKYWInfo)
        /// </summary>	
        public int dnHKYWID
        {
            get{ return _dnhkywid; }
            set{ _dnhkywid = value; }
        }        
			
		private string _dclxr;
		/// <summary>
		/// 人
        /// </summary>	
        public string dcLXR
        {
            get{ return _dclxr; }
            set{ _dclxr = value; }
        }        
			
		private decimal _dnshishouprice;
		/// <summary>
		/// 实收
        /// </summary>	
        public decimal dnShiShouPrice
        {
            get{ return _dnshishouprice; }
            set{ _dnshishouprice = value; }
        }        
			
		private decimal _dnreturnprice;
		/// <summary>
		/// 返
        /// </summary>	
        public decimal dnReturnPrice
        {
            get{ return _dnreturnprice; }
            set{ _dnreturnprice = value; }
        }        
			
		private decimal _dnshijidaozhang;
		/// <summary>
		/// 实际到账
        /// </summary>	
        public decimal dnShiJiDaoZhang
        {
            get{ return _dnshijidaozhang; }
            set{ _dnshijidaozhang = value; }
        }        
			
		private decimal _dnjiesuanprice;
		/// <summary>
		/// 结算价
        /// </summary>	
        public decimal dnJieSuanPrice
        {
            get{ return _dnjiesuanprice; }
            set{ _dnjiesuanprice = value; }
        }        
			
		private decimal _dnlirun;
		/// <summary>
		/// 利润
        /// </summary>	
        public decimal dnLiRun
        {
            get{ return _dnlirun; }
            set{ _dnlirun = value; }
        }        
			
		private decimal _dndijia;
		/// <summary>
		/// 底价
        /// </summary>	
        public decimal dnDiJia
        {
            get{ return _dndijia; }
            set{ _dndijia = value; }
        }        
			
		private decimal _dnfandianprice;
		/// <summary>
		/// 返点金额
        /// </summary>	
        public decimal dnFandianPrice
        {
            get{ return _dnfandianprice; }
            set{ _dnfandianprice = value; }
        }        
			
		private decimal _dnhangxieprice;
		/// <summary>
		/// 航协结算
        /// </summary>	
        public decimal dnHangXiePrice
        {
            get{ return _dnhangxieprice; }
            set{ _dnhangxieprice = value; }
        }        
			
		private decimal _dncountprice;
		/// <summary>
		/// 合计
        /// </summary>	
        public decimal dnCountPrice
        {
            get{ return _dncountprice; }
            set{ _dncountprice = value; }
        }        
			
		private decimal _dnyingshouprice;
		/// <summary>
		/// 应收
        /// </summary>	
        public decimal dnYingShouPrice
        {
            get{ return _dnyingshouprice; }
            set{ _dnyingshouprice = value; }
        }        
			
		private string _dcoutticketid;
		/// <summary>
		/// 出票点ID
        /// </summary>	
        public string dcOutTicketID
        {
            get{ return _dcoutticketid; }
            set{ _dcoutticketid = value; }
        }        
			
		private string _dcoutticketname;
		/// <summary>
		/// 出票点名称
        /// </summary>	
        public string dcOutTicketName
        {
            get{ return _dcoutticketname; }
            set{ _dcoutticketname = value; }
        }        
			
		private string _dccpdxx;
		/// <summary>
		/// 出票点支付
        /// </summary>	
        public string dcCPDXX
        {
            get{ return _dccpdxx; }
            set{ _dccpdxx = value; }
        }        
			
		private decimal _dntotalprice;
		/// <summary>
		/// 票价
        /// </summary>	
        public decimal dnTotalPrice
        {
            get{ return _dntotalprice; }
            set{ _dntotalprice = value; }
        }        
			
		private string _dccompanyid;
		/// <summary>
		/// 企业ID
        /// </summary>	
        public string dcCompanyID
        {
            get{ return _dccompanyid; }
            set{ _dccompanyid = value; }
        }        
			
		private string _dccompanyname;
		/// <summary>
		/// 企业名称
        /// </summary>	
        public string dcCompanyName
        {
            get{ return _dccompanyname; }
            set{ _dccompanyname = value; }
        }        
			
		private string _dclinkname;
		/// <summary>
		/// 客户
        /// </summary>	
        public string dcLinkName
        {
            get{ return _dclinkname; }
            set{ _dclinkname = value; }
        }        
			
		private decimal _dnflightprice;
		/// <summary>
		/// 行程单金额
        /// </summary>	
        public decimal dnFlightPrice
        {
            get{ return _dnflightprice; }
            set{ _dnflightprice = value; }
        }        
			
		private string _dcticketno;
		/// <summary>
		/// 票号
        /// </summary>	
        public string dcTicketNO
        {
            get{ return _dcticketno; }
            set{ _dcticketno = value; }
        }        
			
		private string _dcorderid;
		/// <summary>
		/// 订单ID
        /// </summary>	
        public string dcOrderID
        {
            get{ return _dcorderid; }
            set{ _dcorderid = value; }
        }        
			
		private decimal _dnserviceprice;
		/// <summary>
		/// 服务费
        /// </summary>	
        public decimal dnServicePrice
        {
            get{ return _dnserviceprice; }
            set{ _dnserviceprice = value; }
        }        
			
		private decimal _dnsafeprice;
		/// <summary>
		/// 保险费
        /// </summary>	
        public decimal dnSafePrice
        {
            get{ return _dnsafeprice; }
            set{ _dnsafeprice = value; }
        }        
			
		private string _dcstartdate;
		/// <summary>
		/// 出发日期
        /// </summary>	
        public string dcStartDate
        {
            get{ return _dcstartdate; }
            set{ _dcstartdate = value; }
        }        
			
		private decimal _dnticketprice;
		/// <summary>
		/// 账单票价
        /// </summary>	
        public decimal dnTicketPrice
        {
            get{ return _dnticketprice; }
            set{ _dnticketprice = value; }
        }        
			
		private string _dcrakedclass;
		/// <summary>
		/// 机舱类型
        /// </summary>	
        public string dcRakedClass
        {
            get{ return _dcrakedclass; }
            set{ _dcrakedclass = value; }
        }        
			
		private string _dcpersonname;
		/// <summary>
		/// 乘机人
        /// </summary>	
        public string dcPersonName
        {
            get{ return _dcpersonname; }
            set{ _dcpersonname = value; }
        }        
			
		private string _dcflightnumber;
		/// <summary>
		/// 航班号
        /// </summary>	
        public string dcFlightNumber
        {
            get{ return _dcflightnumber; }
            set{ _dcflightnumber = value; }
        }        
			
		private string _dcflighttime;
		/// <summary>
		/// 起飞时间
        /// </summary>	
        public string dcFlightTime
        {
            get{ return _dcflighttime; }
            set{ _dcflighttime = value; }
        }        
			
		private string _dcother;
		/// <summary>
		/// 备注
        /// </summary>	
        public string dcOther
        {
            get{ return _dcother; }
            set{ _dcother = value; }
        }        
			
		private string _dcpaymentmethod1;
		/// <summary>
		/// 收款类型1
        /// </summary>	
        public string dcPaymentMethod1
        {
            get{ return _dcpaymentmethod1; }
            set{ _dcpaymentmethod1 = value; }
        }        
			
		private decimal _dnpaymentprice1;
		/// <summary>
		/// 收款价格1
        /// </summary>	
        public decimal dnPaymentPrice1
        {
            get{ return _dnpaymentprice1; }
            set{ _dnpaymentprice1 = value; }
        }        
			
		private string _dcpaymentmethod2;
		/// <summary>
		/// 收款类型2
        /// </summary>	
        public string dcPaymentMethod2
        {
            get{ return _dcpaymentmethod2; }
            set{ _dcpaymentmethod2 = value; }
        }        
			
		private decimal _dnpaymentprice2;
		/// <summary>
		/// 收款价格2
        /// </summary>	
        public decimal dnPaymentPrice2
        {
            get{ return _dnpaymentprice2; }
            set{ _dnpaymentprice2 = value; }
        }        
			
		private string _dcpaymentmethod3;
		/// <summary>
		/// 收款类型3
        /// </summary>	
        public string dcPaymentMethod3
        {
            get{ return _dcpaymentmethod3; }
            set{ _dcpaymentmethod3 = value; }
        }        
			
		private decimal _dnpaymentprice3;
		/// <summary>
		/// 收款价格3
        /// </summary>	
        public decimal dnPaymentPrice3
        {
            get{ return _dnpaymentprice3; }
            set{ _dnpaymentprice3 = value; }
        }        
			
		private string _dcpaymentmethod4;
		/// <summary>
		/// 收款类型4
        /// </summary>	
        public string dcPaymentMethod4
        {
            get{ return _dcpaymentmethod4; }
            set{ _dcpaymentmethod4 = value; }
        }        
			
		private decimal _dnpaymentprice4;
		/// <summary>
		/// 收款价格4
        /// </summary>	
        public decimal dnPaymentPrice4
        {
            get{ return _dnpaymentprice4; }
            set{ _dnpaymentprice4 = value; }
        }        
			
		private int _dnstatus;
		/// <summary>
		/// 状态(0未出票1已出票)
        /// </summary>	
        public int dnStatus
        {
            get{ return _dnstatus; }
            set{ _dnstatus = value; }
        }        
			
		private int _dnbonus;
		/// <summary>
		/// 奖金
        /// </summary>	
        public int dnBonus
        {
            get{ return _dnbonus; }
            set{ _dnbonus = value; }
        }        
			
		private decimal _dndiscount;
		/// <summary>
		/// 折扣
        /// </summary>	
        public decimal dnDiscount
        {
            get{ return _dndiscount; }
            set{ _dndiscount = value; }
        }        
			
		private string _dcsendtickettype;
		/// <summary>
		/// 送票方式
        /// </summary>	
        public string dcSendTicketType
        {
            get{ return _dcsendtickettype; }
            set{ _dcsendtickettype = value; }
        }        
			
		private string _dcsendticketername;
		/// <summary>
		/// 送票员
        /// </summary>	
        public string dcSendTicketerName
        {
            get{ return _dcsendticketername; }
            set{ _dcsendticketername = value; }
        }        
			
		private string _dcadduser;
		/// <summary>
		/// 添加人
        /// </summary>	
        public string dcAddUser
        {
            get{ return _dcadduser; }
            set{ _dcadduser = value; }
        }        
			
		private DateTime _dtaddtime;
		/// <summary>
		/// 添加时间
        /// </summary>	
        public DateTime dtAddTime
        {
            get{ return _dtaddtime; }
            set{ _dtaddtime = value; }
        }        
		   
	}
}