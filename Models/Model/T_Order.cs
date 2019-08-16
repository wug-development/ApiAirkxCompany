using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_Order
		public class T_Order
	{
   		     
      	/// <summary>
		/// 订单ID
        /// </summary>		
		private string _dcorderid;
        public string dcOrderID
        {
            get{ return _dcorderid; }
            set{ _dcorderid = value; }
        }        
		/// <summary>
		/// 记录编号
        /// </summary>		
		private string _dcordercode;
        public string dcOrderCode
        {
            get{ return _dcordercode; }
            set{ _dcordercode = value; }
        }        
		/// <summary>
		/// 航班类型(1往返0单程)
        /// </summary>		
		private int _dnairtype;
        public int dnAirType
        {
            get{ return _dnairtype; }
            set{ _dnairtype = value; }
        }        
		/// <summary>
		/// 出发日期
        /// </summary>		
		private string _dcstartdate;
        public string dcStartDate
        {
            get{ return _dcstartdate; }
            set{ _dcstartdate = value; }
        }        
		/// <summary>
		/// 返回日期
        /// </summary>		
		private string _dcbackdata;
        public string dcBackData
        {
            get{ return _dcbackdata; }
            set{ _dcbackdata = value; }
        }        
		/// <summary>
		/// 出发城市
        /// </summary>		
		private string _dcstartcity;
        public string dcStartCity
        {
            get{ return _dcstartcity; }
            set{ _dcstartcity = value; }
        }        
		/// <summary>
		/// 目的地
        /// </summary>		
		private string _dcbackcity;
        public string dcBackCity
        {
            get{ return _dcbackcity; }
            set{ _dcbackcity = value; }
        }        
		/// <summary>
		/// 企业ID
        /// </summary>		
		private string _dccompanyid;
        public string dcCompanyID
        {
            get{ return _dccompanyid; }
            set{ _dccompanyid = value; }
        }        
		/// <summary>
		/// 联系人
        /// </summary>		
		private string _dclinkname;
        public string dcLinkName
        {
            get{ return _dclinkname; }
            set{ _dclinkname = value; }
        }        
		/// <summary>
		/// 票价
        /// </summary>		
		private decimal _dnprice;
        public decimal dnPrice
        {
            get{ return _dnprice; }
            set{ _dnprice = value; }
        }        
		/// <summary>
		/// 税金
        /// </summary>		
		private decimal _dntax;
        public decimal dnTax
        {
            get{ return _dntax; }
            set{ _dntax = value; }
        }        
		/// <summary>
		/// 订单总金额
        /// </summary>		
		private decimal _dntotalprice;
        public decimal dnTotalPrice
        {
            get{ return _dntotalprice; }
            set{ _dntotalprice = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _dccontent;
        public string dcContent
        {
            get{ return _dccontent; }
            set{ _dccontent = value; }
        }        
		/// <summary>
		/// 管理员ID
        /// </summary>		
		private string _dcadminid;
        public string dcAdminID
        {
            get{ return _dcadminid; }
            set{ _dcadminid = value; }
        }        
		/// <summary>
		/// 管家
        /// </summary>		
		private string _dcadminname;
        public string dcAdminName
        {
            get{ return _dcadminname; }
            set{ _dcadminname = value; }
        }        
		/// <summary>
		/// 下单时间
        /// </summary>		
		private DateTime _dtaddtime;
        public DateTime dtAddTime
        {
            get{ return _dtaddtime; }
            set{ _dtaddtime = value; }
        }        
		/// <summary>
		/// 机票ID
        /// </summary>		
		private int _dnticketid;
        public int dnTicketID
        {
            get{ return _dnticketid; }
            set{ _dnticketid = value; }
        }        
		/// <summary>
		/// 票价ID
        /// </summary>		
		private int _dndetailid;
        public int dnDetailID
        {
            get{ return _dndetailid; }
            set{ _dndetailid = value; }
        }        
		   
	}
}

