using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_Order
		public class T_Order
	{
   		     
      		
		private string _dcorderid;
		/// <summary>
		/// 订单ID
        /// </summary>	
        public string dcOrderID
        {
            get{ return _dcorderid; }
            set{ _dcorderid = value; }
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
			
		private string _dcticketno;
		/// <summary>
		/// 票号
        /// </summary>	
        public string dcTicketNO
        {
            get{ return _dcticketno; }
            set{ _dcticketno = value; }
        }        
			
		private int _dnordertype;
		/// <summary>
		/// 订单类型(0国内订单1国际订单)
        /// </summary>	
        public int dnOrderType
        {
            get{ return _dnordertype; }
            set{ _dnordertype = value; }
        }        
			
		private int _dnairtype;
		/// <summary>
		/// 航班类型(1往返0单程)
        /// </summary>	
        public int dnAirType
        {
            get{ return _dnairtype; }
            set{ _dnairtype = value; }
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
			
		private string _dcbackdate;
		/// <summary>
		/// 返回日期
        /// </summary>	
        public string dcBackDate
        {
            get{ return _dcbackdate; }
            set{ _dcbackdate = value; }
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
		/// 企业名词
        /// </summary>	
        public string dcCompanyName
        {
            get{ return _dccompanyname; }
            set{ _dccompanyname = value; }
        }        
			
		private string _dclinkname;
		/// <summary>
		/// 联系人
        /// </summary>	
        public string dcLinkName
        {
            get{ return _dclinkname; }
            set{ _dclinkname = value; }
        }        
			
		private string _dcphone;
		/// <summary>
		/// 联系电话
        /// </summary>	
        public string dcPhone
        {
            get{ return _dcphone; }
            set{ _dcphone = value; }
        }        
			
		private decimal _dnprice;
		/// <summary>
		/// 票价
        /// </summary>	
        public decimal dnPrice
        {
            get{ return _dnprice; }
            set{ _dnprice = value; }
        }        
			
		private decimal _dntax;
		/// <summary>
		/// 税金
        /// </summary>	
        public decimal dnTax
        {
            get{ return _dntax; }
            set{ _dntax = value; }
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
			
		private decimal _dntotalprice;
		/// <summary>
		/// 订单总金额
        /// </summary>	
        public decimal dnTotalPrice
        {
            get{ return _dntotalprice; }
            set{ _dntotalprice = value; }
        }        
			
		private decimal _dnchangeprice;
		/// <summary>
		/// 退票金额或改期金额
        /// </summary>	
        public decimal dnChangePrice
        {
            get{ return _dnchangeprice; }
            set{ _dnchangeprice = value; }
        }        
			
		private decimal _dnchangedateprice;
		/// <summary>
		/// 改期费
        /// </summary>	
        public decimal dnChangeDatePrice
        {
            get{ return _dnchangedateprice; }
            set{ _dnchangedateprice = value; }
        }        
			
		private decimal _dnchaprice;
		/// <summary>
		/// 差价
        /// </summary>	
        public decimal dnChaPrice
        {
            get{ return _dnchaprice; }
            set{ _dnchaprice = value; }
        }        
			
		private string _dccontent;
		/// <summary>
		/// 备注
        /// </summary>	
        public string dcContent
        {
            get{ return _dccontent; }
            set{ _dccontent = value; }
        }        
			
		private string _dcadminid;
		/// <summary>
		/// 管理员ID
        /// </summary>	
        public string dcAdminID
        {
            get{ return _dcadminid; }
            set{ _dcadminid = value; }
        }        
			
		private string _dcadminname;
		/// <summary>
		/// 管家
        /// </summary>	
        public string dcAdminName
        {
            get{ return _dcadminname; }
            set{ _dcadminname = value; }
        }        
			
		private int _dnticketid;
		/// <summary>
		/// 机票ID
        /// </summary>	
        public int dnTicketID
        {
            get{ return _dnticketid; }
            set{ _dnticketid = value; }
        }        
			
		private int _dndetailid;
		/// <summary>
		/// 票价ID
        /// </summary>	
        public int dnDetailID
        {
            get{ return _dndetailid; }
            set{ _dndetailid = value; }
        }        
			
		private int _dnstatus;
		/// <summary>
		/// 订单状态(0等待处理 1处理完成 2后补等待)
        /// </summary>	
        public int dnStatus
        {
            get{ return _dnstatus; }
            set{ _dnstatus = value; }
        }        
			
		private int _dnorderstatus;
		/// <summary>
		/// 订单状态(1正常2退票3改期)
        /// </summary>	
        public int dnOrderStatus
        {
            get{ return _dnorderstatus; }
            set{ _dnorderstatus = value; }
        }        
			
		private int _dnisticket;
		/// <summary>
		/// 支付状态(0未出票1已出票 2退票)
        /// </summary>	
        public int dnIsTicket
        {
            get{ return _dnisticket; }
            set{ _dnisticket = value; }
        }        
			
		private DateTime _dtaddtime;
		/// <summary>
		/// 下单时间
        /// </summary>	
        public DateTime dtAddTime
        {
            get{ return _dtaddtime; }
            set{ _dtaddtime = value; }
        }        
			
		private DateTime _dtedittime;
		/// <summary>
		/// 修改时间
        /// </summary>	
        public DateTime dtEditTime
        {
            get{ return _dtedittime; }
            set{ _dtedittime = value; }
        }        
		   
	}
}