using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_Company
		public class T_Company
	{
   		     
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
		/// 账号
        /// </summary>		
		private string _dcusername;
        public string dcUserName
        {
            get{ return _dcusername; }
            set{ _dcusername = value; }
        }        
		/// <summary>
		/// 密码
        /// </summary>		
		private string _dcpassword;
        public string dcPassword
        {
            get{ return _dcpassword; }
            set{ _dcpassword = value; }
        }        
		/// <summary>
		/// 公司全称
        /// </summary>		
		private string _dcfullname;
        public string dcFullName
        {
            get{ return _dcfullname; }
            set{ _dcfullname = value; }
        }        
		/// <summary>
		/// 简称
        /// </summary>		
		private string _dcshortname;
        public string dcShortName
        {
            get{ return _dcshortname; }
            set{ _dcshortname = value; }
        }        
		/// <summary>
		/// 注册号
        /// </summary>		
		private string _dcregistrationnumber;
        public string dcRegistrationNumber
        {
            get{ return _dcregistrationnumber; }
            set{ _dcregistrationnumber = value; }
        }        
		/// <summary>
		/// 注册资金
        /// </summary>		
		private decimal _dnregisteredfunds;
        public decimal dnRegisteredFunds
        {
            get{ return _dnregisteredfunds; }
            set{ _dnregisteredfunds = value; }
        }        
		/// <summary>
		/// 经营地址
        /// </summary>		
		private string _dcbusinessaddress;
        public string dcBusinessAddress
        {
            get{ return _dcbusinessaddress; }
            set{ _dcbusinessaddress = value; }
        }        
		/// <summary>
		/// 主营业务
        /// </summary>		
		private string _dcmainbusiness;
        public string dcMainBusiness
        {
            get{ return _dcmainbusiness; }
            set{ _dcmainbusiness = value; }
        }        
		/// <summary>
		/// 股东明细
        /// </summary>		
		private string _dcshareholder;
        public string dcShareholder
        {
            get{ return _dcshareholder; }
            set{ _dcshareholder = value; }
        }        
		/// <summary>
		/// 法人代表
        /// </summary>		
		private string _dclegalrepresentative;
        public string dcLegalRepresentative
        {
            get{ return _dclegalrepresentative; }
            set{ _dclegalrepresentative = value; }
        }        
		/// <summary>
		/// 执照注册地址
        /// </summary>		
		private string _dclicenseregistrationaddr;
        public string dcLicenseRegistrationAddr
        {
            get{ return _dclicenseregistrationaddr; }
            set{ _dclicenseregistrationaddr = value; }
        }        
		/// <summary>
		/// 银行账号
        /// </summary>		
		private string _dcbankaccount;
        public string dcBankAccount
        {
            get{ return _dcbankaccount; }
            set{ _dcbankaccount = value; }
        }        
		/// <summary>
		/// 开户行
        /// </summary>		
		private string _dcopeningbank;
        public string dcOpeningBank
        {
            get{ return _dcopeningbank; }
            set{ _dcopeningbank = value; }
        }        
		/// <summary>
		/// 母公司ID
        /// </summary>		
		private string _dcparentcompanyid;
        public string dcParentCompanyID
        {
            get{ return _dcparentcompanyid; }
            set{ _dcparentcompanyid = value; }
        }        
		/// <summary>
		/// 信用额度
        /// </summary>		
		private int _dncreditline;
        public int dnCreditLine
        {
            get{ return _dncreditline; }
            set{ _dncreditline = value; }
        }        
		/// <summary>
		/// 结账日期
        /// </summary>		
		private string _dtcheckoutdate;
        public string dtCheckOutDate
        {
            get{ return _dtcheckoutdate; }
            set{ _dtcheckoutdate = value; }
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
		/// 联系电话
        /// </summary>		
		private string _dcphone;
        public string dcPhone
        {
            get{ return _dcphone; }
            set{ _dcphone = value; }
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
		/// 管理员名称
        /// </summary>		
		private string _dcadminname;
        public string dcAdminName
        {
            get{ return _dcadminname; }
            set{ _dcadminname = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _dcother;
        public string dcOther
        {
            get{ return _dcother; }
            set{ _dcother = value; }
        }        
		/// <summary>
		/// 注册时间
        /// </summary>		
		private DateTime _dtadddatetime;
        public DateTime dtAddDatetime
        {
            get{ return _dtadddatetime; }
            set{ _dtadddatetime = value; }
        }        
		/// <summary>
		/// 用户状态(0停用1正常2删除)
        /// </summary>		
		private int _dnischeck;
        public int dnIsCheck
        {
            get{ return _dnischeck; }
            set{ _dnischeck = value; }
        }        
		   
	}
}

