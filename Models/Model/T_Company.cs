/**  版本信息模板在安装目录下，可自行修改。
* T_Company.cs
*
* 功 能： N/A
* 类 名： T_Company
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
*/
using System;
namespace ApiAirkxCompany.Model
{
	/// <summary>
	/// T_Company:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Company
	{
		public T_Company()
		{}
		#region Model
		private string _dccompanyid;
		private string _dcusername="";
		private string _dcpassword="";
        private string _dcfirstletter = "";
        private string _dcfullname="";
		private string _dcshortname="";
		private string _dcregistrationnumber="";
		private decimal _dnregisteredfunds=0M;
		private string _dcbusinessaddress="";
		private string _dcmainbusiness="";
		private string _dcshareholder="";
		private string _dclegalrepresentative="";
		private string _dclicenseregistrationaddr="";
		private string _dcbankaccount="";
		private string _dcopeningbank="";
		private string _dcparentcompanyid="";
		private int _dncreditline=0;
		private decimal _dnservicepirce=0M;
		private string _dtcheckoutdate="";
		private string _dclinkname="";
		private string _dcphone="";
		private string _dcadminid="";
		private string _dcadminname="";
		private string _dcother="";
		private DateTime _dtadddatetime= DateTime.Now;
		private int _dnischeck=1;
		/// <summary>
		/// 企业ID
		/// </summary>
		public string dcCompanyID
		{
			set{ _dccompanyid=value;}
			get{return _dccompanyid;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string dcUserName
		{
			set{ _dcusername=value;}
			get{return _dcusername;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string dcPassword
		{
			set{ _dcpassword=value;}
			get{return _dcpassword;}
        }
        /// <summary>
        /// 首字母
        /// </summary>
        public string dcFirstLetter { get => _dcfirstletter; set => _dcfirstletter = value; }
        /// <summary>
        /// 公司全称
        /// </summary>
        public string dcFullName
		{
			set{ _dcfullname=value;}
			get{return _dcfullname;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string dcShortName
		{
			set{ _dcshortname=value;}
			get{return _dcshortname;}
		}
		/// <summary>
		/// 注册号
		/// </summary>
		public string dcRegistrationNumber
		{
			set{ _dcregistrationnumber=value;}
			get{return _dcregistrationnumber;}
		}
		/// <summary>
		/// 注册资金
		/// </summary>
		public decimal dnRegisteredFunds
		{
			set{ _dnregisteredfunds=value;}
			get{return _dnregisteredfunds;}
		}
		/// <summary>
		/// 经营地址
		/// </summary>
		public string dcBusinessAddress
		{
			set{ _dcbusinessaddress=value;}
			get{return _dcbusinessaddress;}
		}
		/// <summary>
		/// 主营业务
		/// </summary>
		public string dcMainBusiness
		{
			set{ _dcmainbusiness=value;}
			get{return _dcmainbusiness;}
		}
		/// <summary>
		/// 股东明细
		/// </summary>
		public string dcShareholder
		{
			set{ _dcshareholder=value;}
			get{return _dcshareholder;}
		}
		/// <summary>
		/// 法人代表
		/// </summary>
		public string dcLegalRepresentative
		{
			set{ _dclegalrepresentative=value;}
			get{return _dclegalrepresentative;}
		}
		/// <summary>
		/// 执照注册地址
		/// </summary>
		public string dcLicenseRegistrationAddr
		{
			set{ _dclicenseregistrationaddr=value;}
			get{return _dclicenseregistrationaddr;}
		}
		/// <summary>
		/// 银行账号
		/// </summary>
		public string dcBankAccount
		{
			set{ _dcbankaccount=value;}
			get{return _dcbankaccount;}
		}
		/// <summary>
		/// 开户行
		/// </summary>
		public string dcOpeningBank
		{
			set{ _dcopeningbank=value;}
			get{return _dcopeningbank;}
		}
		/// <summary>
		/// 母公司ID
		/// </summary>
		public string dcParentCompanyID
		{
			set{ _dcparentcompanyid=value;}
			get{return _dcparentcompanyid;}
		}
		/// <summary>
		/// 信用额度
		/// </summary>
		public int dnCreditLine
		{
			set{ _dncreditline=value;}
			get{return _dncreditline;}
		}
		/// <summary>
		/// 服务费
		/// </summary>
		public decimal dnServicePirce
		{
			set{ _dnservicepirce=value;}
			get{return _dnservicepirce;}
		}
		/// <summary>
		/// 结账日期
		/// </summary>
		public string dtCheckOutDate
		{
			set{ _dtcheckoutdate=value;}
			get{return _dtcheckoutdate;}
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
		/// 管理员ID
		/// </summary>
		public string dcAdminID
		{
			set{ _dcadminid=value;}
			get{return _dcadminid;}
		}
		/// <summary>
		/// 管理员名称
		/// </summary>
		public string dcAdminName
		{
			set{ _dcadminname=value;}
			get{return _dcadminname;}
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
		/// 注册时间
		/// </summary>
		public DateTime dtAddDatetime
		{
			set{ _dtadddatetime=value;}
			get{return _dtadddatetime;}
		}
		/// <summary>
		/// 用户状态(0停用1正常2删除)
		/// </summary>
		public int dnIsCheck
		{
			set{ _dnischeck=value;}
			get{return _dnischeck;}
		}
        #endregion Model

    }
}

