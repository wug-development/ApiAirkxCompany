/**  版本信息模板在安装目录下，可自行修改。
* T_Order.cs
*
* 功 能： N/A
* 类 名： T_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/9/20 18:21:33   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ApiAirkxCompany.Model
{
	/// <summary>
	/// T_Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Order
	{
		public T_Order()
		{}
		#region Model
		private string _dcorderid="";
		private string _dcordercode="";
		private string _dcticketno="";
		private int _dnairtype=0;
		private string _dcstartdate="";
		private string _dcbackdate="";
		private string _dcstartcity="";
		private string _dcbackcity="";
		private string _dccompanyid="";
		private string _dclinkname="";
		private string _dcphone="";
		private decimal _dnprice=0M;
		private decimal _dntax=0M;
		private decimal _dnserviceprice=0M;
		private decimal _dnsafeprice=0M;
		private decimal _dntotalprice=0M;
		private string _dccontent="";
		private string _dcadminid="";
		private string _dcadminname="";
		private DateTime _dtaddtime= DateTime.Now;
		private int _dnticketid=0;
		private int _dndetailid=0;
		private int _dnstatus=0;
		private int _dnispay=0;
		/// <summary>
		/// 订单ID
		/// </summary>
		public string dcOrderID
		{
			set{ _dcorderid=value;}
			get{return _dcorderid;}
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
		/// 票号
		/// </summary>
		public string dcTicketNO
		{
			set{ _dcticketno=value;}
			get{return _dcticketno;}
		}
		/// <summary>
		/// 航班类型(1往返0单程)
		/// </summary>
		public int dnAirType
		{
			set{ _dnairtype=value;}
			get{return _dnairtype;}
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
		/// 返回日期
		/// </summary>
		public string dcBackDate
		{
			set{ _dcbackdate=value;}
			get{return _dcbackdate;}
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
		/// 企业ID
		/// </summary>
		public string dcCompanyID
		{
			set{ _dccompanyid=value;}
			get{return _dccompanyid;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string dcLinkName
		{
			set{ _dclinkname=value;}
			get{return _dclinkname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string dcPhone
		{
			set{ _dcphone=value;}
			get{return _dcphone;}
		}
		/// <summary>
		/// 票价
		/// </summary>
		public decimal dnPrice
		{
			set{ _dnprice=value;}
			get{return _dnprice;}
		}
		/// <summary>
		/// 税金
		/// </summary>
		public decimal dnTax
		{
			set{ _dntax=value;}
			get{return _dntax;}
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
		/// 订单总金额
		/// </summary>
		public decimal dnTotalPrice
		{
			set{ _dntotalprice=value;}
			get{return _dntotalprice;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string dcContent
		{
			set{ _dccontent=value;}
			get{return _dccontent;}
		}
		/// <summary>
		/// 管理员ID
		/// </summary>
		public string dcAdminID
		{
			set{ _dcadminid=value;}
			get{return _dcadminid;}
		}
		/// <summary>
		/// 管家
		/// </summary>
		public string dcAdminName
		{
			set{ _dcadminname=value;}
			get{return _dcadminname;}
		}
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime dtAddTime
		{
			set{ _dtaddtime=value;}
			get{return _dtaddtime;}
		}
		/// <summary>
		/// 机票ID
		/// </summary>
		public int dnTicketID
		{
			set{ _dnticketid=value;}
			get{return _dnticketid;}
		}
		/// <summary>
		/// 票价ID
		/// </summary>
		public int dnDetailID
		{
			set{ _dndetailid=value;}
			get{return _dndetailid;}
		}
		/// <summary>
		/// 订单状态(0未出票 1出票成功)
		/// </summary>
		public int dnStatus
		{
			set{ _dnstatus=value;}
			get{return _dnstatus;}
		}
		/// <summary>
		/// 支付状态(0未支付1已支付)
		/// </summary>
		public int dnIsPay
		{
			set{ _dnispay=value;}
			get{return _dnispay;}
		}
		#endregion Model

	}
}

