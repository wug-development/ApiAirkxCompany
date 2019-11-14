/**  版本信息模板在安装目录下，可自行修改。
* T_TicketSheet.cs
*
* 功 能： N/A
* 类 名： T_TicketSheet
*/
using System;
namespace ApiAirkxCompany.Model
{
	/// <summary>
	/// T_TicketSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class T_TicketSheet
	{
		public T_TicketSheet()
		{}
		#region Model
		private string _dctsid="";
		private int _dnflightclass=0;
		private string _dcaircompanyname="";
		private string _dcordercode="";
		private string _dcstartcity="";
		private string _dcbackcity="";
		private decimal _dnsellprice=0M;
		private decimal _dnreturnpoint1=0M;
		private decimal _dnreturnpoint2=0M;
		private decimal _dnreturnpoint3=0M;
		private decimal _dntax=0M;
		private int _dnpersonnumber=0;
		private decimal _dnyaoweiprice=0M;
		private int _dnhkywid=0;
		private string _dclxr="";
		private decimal _dnshishouprice=0M;
		private decimal _dnreturnprice=0M;
		private decimal _dnshijidaozhang=0M;
		private decimal _dnjiesuanprice=0M;
		private decimal _dnlirun=0M;
		private decimal _dndijia=0M;
		private decimal _dnfandianprice=0M;
		private decimal _dnhangxieprice=0M;
		private decimal _dncountprice=0M;
		private decimal _dnyingshouprice=0M;
		private string _dcoutticketid;
		private string _dcoutticketname="";
		private string _dccpdxx="支付宝";
		private decimal _dntotalprice=0M;
		private string _dccompanyid="";
		private string _dccompanyname="";
		private string _dclinkname="";
		private decimal _dnflightprice=0M;
		private string _dcticketno="";
		private string _dcorderid="";
		private decimal _dnserviceprice=0M;
		private decimal _dnsafeprice=0M;
		private string _dcstartdate="";
		private decimal _dnticketprice=0M;
		private string _dcrakedclass="";
		private string _dcpersonname="";
		private string _dcflightnumber="";
		private string _dcflighttime="";
		private string _dcother="";
		private string _dcpaymentmethod1="";
		private decimal _dnpaymentprice1=0M;
		private string _dcpaymentmethod2="";
		private decimal _dnpaymentprice2=0M;
		private string _dcpaymentmethod3="";
		private decimal _dnpaymentprice3=0M;
		private string _dcpaymentmethod4="";
		private decimal _dnpaymentprice4=0M;
		private int _dnstatus=0;
		private int _dnbonus=0;
		private decimal _dndiscount=0M;
		private string _dcsendtickettype="不送";
		private string _dcsendticketername="";
		private string _dcadduser="";
		private DateTime _dtaddtime= DateTime.Now;
		/// <summary>
		/// 出票单ID
		/// </summary>
		public string dcTSID
		{
			set{ _dctsid=value;}
			get{return _dctsid;}
		}
		/// <summary>
		/// 航班类型(0国内1国际)
		/// </summary>
		public int dnFlightClass
		{
			set{ _dnflightclass=value;}
			get{return _dnflightclass;}
		}
		/// <summary>
		/// 航空公司中文名称
		/// </summary>
		public string dcAirCompanyName
		{
			set{ _dcaircompanyname=value;}
			get{return _dcaircompanyname;}
		}
		/// <summary>
		/// 记录编号
		/// </summary>
		public string dcOrderCode
		{
			set{ _dcordercode=value;}
			get{return _dcordercode;}
		}
		/// <summary>
		/// 出发城市
		/// </summary>
		public string dcStartCity
		{
			set{ _dcstartcity=value;}
			get{return _dcstartcity;}
		}
		/// <summary>
		/// 目的地
		/// </summary>
		public string dcBackCity
		{
			set{ _dcbackcity=value;}
			get{return _dcbackcity;}
		}
		/// <summary>
		/// 销售价
		/// </summary>
		public decimal dnSellPrice
		{
			set{ _dnsellprice=value;}
			get{return _dnsellprice;}
		}
		/// <summary>
		/// 返点1
		/// </summary>
		public decimal dnReturnPoint1
		{
			set{ _dnreturnpoint1=value;}
			get{return _dnreturnpoint1;}
		}
		/// <summary>
		/// 返点2
		/// </summary>
		public decimal dnReturnPoint2
		{
			set{ _dnreturnpoint2=value;}
			get{return _dnreturnpoint2;}
		}
		/// <summary>
		/// 返点3
		/// </summary>
		public decimal dnReturnPoint3
		{
			set{ _dnreturnpoint3=value;}
			get{return _dnreturnpoint3;}
		}
		/// <summary>
		/// 税
		/// </summary>
		public decimal dnTax
		{
			set{ _dntax=value;}
			get{return _dntax;}
		}
		/// <summary>
		/// 人数
		/// </summary>
		public int dnPersonNumber
		{
			set{ _dnpersonnumber=value;}
			get{return _dnpersonnumber;}
		}
		/// <summary>
		/// 要位费
		/// </summary>
		public decimal dnYaoWeiPrice
		{
			set{ _dnyaoweiprice=value;}
			get{return _dnyaoweiprice;}
		}
		/// <summary>
		/// 人ID(FinanceDB-HKYWInfo)
		/// </summary>
		public int dnHKYWID
		{
			set{ _dnhkywid=value;}
			get{return _dnhkywid;}
		}
		/// <summary>
		/// 人
		/// </summary>
		public string dcLXR
		{
			set{ _dclxr=value;}
			get{return _dclxr;}
		}
		/// <summary>
		/// 实收
		/// </summary>
		public decimal dnShiShouPrice
		{
			set{ _dnshishouprice=value;}
			get{return _dnshishouprice;}
		}
		/// <summary>
		/// 返
		/// </summary>
		public decimal dnReturnPrice
		{
			set{ _dnreturnprice=value;}
			get{return _dnreturnprice;}
		}
		/// <summary>
		/// 实际到账
		/// </summary>
		public decimal dnShiJiDaoZhang
		{
			set{ _dnshijidaozhang=value;}
			get{return _dnshijidaozhang;}
		}
		/// <summary>
		/// 结算价
		/// </summary>
		public decimal dnJieSuanPrice
		{
			set{ _dnjiesuanprice=value;}
			get{return _dnjiesuanprice;}
		}
		/// <summary>
		/// 利润
		/// </summary>
		public decimal dnLiRun
		{
			set{ _dnlirun=value;}
			get{return _dnlirun;}
		}
		/// <summary>
		/// 底价
		/// </summary>
		public decimal dnDiJia
		{
			set{ _dndijia=value;}
			get{return _dndijia;}
		}
		/// <summary>
		/// 返点金额
		/// </summary>
		public decimal dnFandianPrice
		{
			set{ _dnfandianprice=value;}
			get{return _dnfandianprice;}
		}
		/// <summary>
		/// 航协结算
		/// </summary>
		public decimal dnHangXiePrice
		{
			set{ _dnhangxieprice=value;}
			get{return _dnhangxieprice;}
		}
		/// <summary>
		/// 合计
		/// </summary>
		public decimal dnCountPrice
		{
			set{ _dncountprice=value;}
			get{return _dncountprice;}
		}
		/// <summary>
		/// 应收
		/// </summary>
		public decimal dnYingShouPrice
		{
			set{ _dnyingshouprice=value;}
			get{return _dnyingshouprice;}
		}
		/// <summary>
		/// 出票点ID
		/// </summary>
		public string dcOutTicketID
		{
			set{ _dcoutticketid=value;}
			get{return _dcoutticketid;}
		}
		/// <summary>
		/// 出票点名称
		/// </summary>
		public string dcOutTicketName
		{
			set{ _dcoutticketname=value;}
			get{return _dcoutticketname;}
		}
		/// <summary>
		/// 出票点支付
		/// </summary>
		public string dcCPDXX
		{
			set{ _dccpdxx=value;}
			get{return _dccpdxx;}
		}
		/// <summary>
		/// 票价
		/// </summary>
		public decimal dnTotalPrice
		{
			set{ _dntotalprice=value;}
			get{return _dntotalprice;}
		}
		/// <summary>
		/// 企业ID
		/// </summary>
		public string dcCompanyID
		{
			set{ _dccompanyid=value;}
			get{return _dccompanyid;}
		}
		/// <summary>
		/// 企业名称
		/// </summary>
		public string dcCompanyName
		{
			set{ _dccompanyname=value;}
			get{return _dccompanyname;}
		}
		/// <summary>
		/// 客户
		/// </summary>
		public string dcLinkName
		{
			set{ _dclinkname=value;}
			get{return _dclinkname;}
		}
		/// <summary>
		/// 行程单金额
		/// </summary>
		public decimal dnFlightPrice
		{
			set{ _dnflightprice=value;}
			get{return _dnflightprice;}
		}
		/// <summary>
		/// 票号
		/// </summary>
		public string dcTicketNO
		{
			set{ _dcticketno=value;}
			get{return _dcticketno;}
		}
		/// <summary>
		/// 订单ID
		/// </summary>
		public string dcOrderID
		{
			set{ _dcorderid=value;}
			get{return _dcorderid;}
		}
		/// <summary>
		/// 服务费
		/// </summary>
		public decimal dnServicePrice
		{
			set{ _dnserviceprice=value;}
			get{return _dnserviceprice;}
		}
		/// <summary>
		/// 保险费
		/// </summary>
		public decimal dnSafePrice
		{
			set{ _dnsafeprice=value;}
			get{return _dnsafeprice;}
		}
		/// <summary>
		/// 出发日期
		/// </summary>
		public string dcStartDate
		{
			set{ _dcstartdate=value;}
			get{return _dcstartdate;}
		}
		/// <summary>
		/// 账单票价
		/// </summary>
		public decimal dnTicketPrice
		{
			set{ _dnticketprice=value;}
			get{return _dnticketprice;}
		}
		/// <summary>
		/// 机舱类型
		/// </summary>
		public string dcRakedClass
		{
			set{ _dcrakedclass=value;}
			get{return _dcrakedclass;}
		}
		/// <summary>
		/// 乘机人
		/// </summary>
		public string dcPersonName
		{
			set{ _dcpersonname=value;}
			get{return _dcpersonname;}
		}
		/// <summary>
		/// 航班号
		/// </summary>
		public string dcFlightNumber
		{
			set{ _dcflightnumber=value;}
			get{return _dcflightnumber;}
		}
		/// <summary>
		/// 起飞时间
		/// </summary>
		public string dcFlightTime
		{
			set{ _dcflighttime=value;}
			get{return _dcflighttime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string dcOther
		{
			set{ _dcother=value;}
			get{return _dcother;}
		}
		/// <summary>
		/// 收款类型1
		/// </summary>
		public string dcPaymentMethod1
		{
			set{ _dcpaymentmethod1=value;}
			get{return _dcpaymentmethod1;}
		}
		/// <summary>
		/// 收款价格1
		/// </summary>
		public decimal dnPaymentPrice1
		{
			set{ _dnpaymentprice1=value;}
			get{return _dnpaymentprice1;}
		}
		/// <summary>
		/// 收款类型2
		/// </summary>
		public string dcPaymentMethod2
		{
			set{ _dcpaymentmethod2=value;}
			get{return _dcpaymentmethod2;}
		}
		/// <summary>
		/// 收款价格2
		/// </summary>
		public decimal dnPaymentPrice2
		{
			set{ _dnpaymentprice2=value;}
			get{return _dnpaymentprice2;}
		}
		/// <summary>
		/// 收款类型3
		/// </summary>
		public string dcPaymentMethod3
		{
			set{ _dcpaymentmethod3=value;}
			get{return _dcpaymentmethod3;}
		}
		/// <summary>
		/// 收款价格3
		/// </summary>
		public decimal dnPaymentPrice3
		{
			set{ _dnpaymentprice3=value;}
			get{return _dnpaymentprice3;}
		}
		/// <summary>
		/// 收款类型4
		/// </summary>
		public string dcPaymentMethod4
		{
			set{ _dcpaymentmethod4=value;}
			get{return _dcpaymentmethod4;}
		}
		/// <summary>
		/// 收款价格4
		/// </summary>
		public decimal dnPaymentPrice4
		{
			set{ _dnpaymentprice4=value;}
			get{return _dnpaymentprice4;}
		}
		/// <summary>
		/// 状态(0未出票1已出票)
		/// </summary>
		public int dnStatus
		{
			set{ _dnstatus=value;}
			get{return _dnstatus;}
		}
		/// <summary>
		/// 奖金
		/// </summary>
		public int dnBonus
		{
			set{ _dnbonus=value;}
			get{return _dnbonus;}
		}
		/// <summary>
		/// 折扣
		/// </summary>
		public decimal dnDiscount
		{
			set{ _dndiscount=value;}
			get{return _dndiscount;}
		}
		/// <summary>
		/// 送票方式
		/// </summary>
		public string dcSendTicketType
		{
			set{ _dcsendtickettype=value;}
			get{return _dcsendtickettype;}
		}
		/// <summary>
		/// 送票员
		/// </summary>
		public string dcSendTicketerName
		{
			set{ _dcsendticketername=value;}
			get{return _dcsendticketername;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public string dcAddUser
		{
			set{ _dcadduser=value;}
			get{return _dcadduser;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime dtAddTime
		{
			set{ _dtaddtime=value;}
			get{return _dtaddtime;}
		}
		#endregion Model

	}
}

