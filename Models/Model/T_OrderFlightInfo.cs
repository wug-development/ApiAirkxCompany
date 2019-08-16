using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_OrderFlightInfo
		public class T_OrderFlightInfo
	{
   		     
      	/// <summary>
		/// 订单航班ID
        /// </summary>		
		private string _dcorderflightid;
        public string dcOrderFlightID
        {
            get{ return _dcorderflightid; }
            set{ _dcorderflightid = value; }
        }        
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
		/// 航班类型(1往返0单程)
        /// </summary>		
		private int _dnairtype;
        public int dnAirType
        {
            get{ return _dnairtype; }
            set{ _dnairtype = value; }
        }        
		/// <summary>
		/// 航班ID
        /// </summary>		
		private int _dnairid;
        public int dnAirID
        {
            get{ return _dnairid; }
            set{ _dnairid = value; }
        }        
		/// <summary>
		/// 航班Code
        /// </summary>		
		private string _dcaircode;
        public string dcAirCode
        {
            get{ return _dcaircode; }
            set{ _dcaircode = value; }
        }        
		/// <summary>
		/// 起飞机场
        /// </summary>		
		private string _dcsportname;
        public string dcSPortName
        {
            get{ return _dcsportname; }
            set{ _dcsportname = value; }
        }        
		/// <summary>
		/// 降落机场
        /// </summary>		
		private string _dceportname;
        public string dcEPortName
        {
            get{ return _dceportname; }
            set{ _dceportname = value; }
        }        
		/// <summary>
		/// 起飞机场Code
        /// </summary>		
		private string _dcscode;
        public string dcSCode
        {
            get{ return _dcscode; }
            set{ _dcscode = value; }
        }        
		/// <summary>
		/// 降落机场Code
        /// </summary>		
		private string _dcecode;
        public string dcECode
        {
            get{ return _dcecode; }
            set{ _dcecode = value; }
        }        
		/// <summary>
		/// 起飞时间
        /// </summary>		
		private string _dcstime;
        public string dcSTime
        {
            get{ return _dcstime; }
            set{ _dcstime = value; }
        }        
		/// <summary>
		/// 降落时间
        /// </summary>		
		private string _dcetime;
        public string dcETime
        {
            get{ return _dcetime; }
            set{ _dcetime = value; }
        }        
		/// <summary>
		/// 机型
        /// </summary>		
		private string _dcjixing;
        public string dcJixing
        {
            get{ return _dcjixing; }
            set{ _dcjixing = value; }
        }        
		/// <summary>
		/// 航空公司ID
        /// </summary>		
		private int _dcaircompanyid;
        public int dcAirCompanyID
        {
            get{ return _dcaircompanyid; }
            set{ _dcaircompanyid = value; }
        }        
		/// <summary>
		/// 航空公司中文名称
        /// </summary>		
		private string _dccompanyname;
        public string dcCompanyName
        {
            get{ return _dccompanyname; }
            set{ _dccompanyname = value; }
        }        
		/// <summary>
		/// 航空公司英文名称
        /// </summary>		
		private string _dcencompanyname;
        public string dcEnCompanyName
        {
            get{ return _dcencompanyname; }
            set{ _dcencompanyname = value; }
        }        
		/// <summary>
		/// 航空公司LOGO
        /// </summary>		
		private string _dccompanylogo;
        public string dcCompanyLogo
        {
            get{ return _dccompanylogo; }
            set{ _dccompanylogo = value; }
        }        
		/// <summary>
		/// 航空公司code
        /// </summary>		
		private string _dccompanycode;
        public string dcCompanyCode
        {
            get{ return _dccompanycode; }
            set{ _dccompanycode = value; }
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
		   
	}
}

