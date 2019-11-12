using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_CompanyAccount
		public class T_CompanyAccount
	{
   		     
      		
		private string _dccaid;
		/// <summary>
		/// dcCAID
        /// </summary>	
        public string dcCAID
        {
            get{ return _dccaid; }
            set{ _dccaid = value; }
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
			
		private decimal _dncreditline;
		/// <summary>
		/// 信用额度可用
        /// </summary>	
        public decimal dnCreditLine
        {
            get{ return _dncreditline; }
            set{ _dncreditline = value; }
        }        
			
		private decimal _dndebt;
		/// <summary>
		/// 欠款金额
        /// </summary>	
        public decimal dnDebt
        {
            get{ return _dndebt; }
            set{ _dndebt = value; }
        }        
			
		private decimal _dnpaycount;
		/// <summary>
		/// 付款总额
        /// </summary>	
        public decimal dnPayCount
        {
            get{ return _dnpaycount; }
            set{ _dnpaycount = value; }
        }        
			
		private decimal _dnurgentmoney;
		/// <summary>
		/// 急需结算金额
        /// </summary>	
        public decimal dnUrgentMoney
        {
            get{ return _dnurgentmoney; }
            set{ _dnurgentmoney = value; }
        }        
			
		private string _dclastorderdate;
		/// <summary>
		/// 上次订单时间
        /// </summary>	
        public string dcLastOrderDate
        {
            get{ return _dclastorderdate; }
            set{ _dclastorderdate = value; }
        }        
			
		private decimal _dntotalticketprice;
		/// <summary>
		/// 出票总金额
        /// </summary>	
        public decimal dnTotalTicketPrice
        {
            get{ return _dntotalticketprice; }
            set{ _dntotalticketprice = value; }
        }        
		   
	}
}