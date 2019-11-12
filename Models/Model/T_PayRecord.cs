using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_PayRecord
		public class T_PayRecord
	{
   		     
      		
		private string _dcprid;
		/// <summary>
		/// 支付报表ID
        /// </summary>	
        public string dcPRID
        {
            get{ return _dcprid; }
            set{ _dcprid = value; }
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
			
		private decimal _dnmoney;
		/// <summary>
		/// 充值金额
        /// </summary>	
        public decimal dnMoney
        {
            get{ return _dnmoney; }
            set{ _dnmoney = value; }
        }        
			
		private string _dcpaytype;
		/// <summary>
		/// 付款方式
        /// </summary>	
        public string dcPayType
        {
            get{ return _dcpaytype; }
            set{ _dcpaytype = value; }
        }        
			
		private string _dcpaydate;
		/// <summary>
		/// 汇款日期
        /// </summary>	
        public string dcPayDate
        {
            get{ return _dcpaydate; }
            set{ _dcpaydate = value; }
        }        
			
		private string _dcremarks;
		/// <summary>
		/// 备注
        /// </summary>	
        public string dcRemarks
        {
            get{ return _dcremarks; }
            set{ _dcremarks = value; }
        }        
			
		private int _dnstatus;
		/// <summary>
		/// 状态(0审核中,1已确认)
        /// </summary>	
        public int dnStatus
        {
            get{ return _dnstatus; }
            set{ _dnstatus = value; }
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
		/// 管理员账号
        /// </summary>	
        public string dcAdminName
        {
            get{ return _dcadminname; }
            set{ _dcadminname = value; }
        }        
			
		private DateTime _dtadddatetime;
		/// <summary>
		/// 充值时间
        /// </summary>	
        public DateTime dtAddDatetime
        {
            get{ return _dtadddatetime; }
            set{ _dtadddatetime = value; }
        }        
			
		private string _dccomfirmadminid;
		/// <summary>
		/// 确认收款人
        /// </summary>	
        public string dcComfirmAdminID
        {
            get{ return _dccomfirmadminid; }
            set{ _dccomfirmadminid = value; }
        }        
			
		private string _dccomfirmdate;
		/// <summary>
		/// 确认收款时间
        /// </summary>	
        public string dcComfirmDate
        {
            get{ return _dccomfirmdate; }
            set{ _dccomfirmdate = value; }
        }        
		   
	}
}