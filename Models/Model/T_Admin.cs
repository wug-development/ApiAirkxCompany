/**  版本信息模板在安装目录下，可自行修改。
* T_Admin.cs
*
* 功 能： N/A
* 类 名： T_Admin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
*/
using System;
namespace ApiAirkxCompany.Model
{
	/// <summary>
	/// T_Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Admin
	{
		public T_Admin()
		{}
		#region Model
		private string _dcadminid;
		private string _dcadminname="";
		private string _dcpassword="";
		private string _dcrealname="";
		private string _dcphone="";
		private string _dcqq="";
		private DateTime _dtadddate= DateTime.Now;
		private DateTime _dtlogintime= DateTime.Now;
		private int _dnischeck=1;
		/// <summary>
		/// 管理员ID
		/// </summary>
		public string dcAdminID
		{
			set{ _dcadminid=value;}
			get{return _dcadminid;}
		}
		/// <summary>
		/// 管理员账号
		/// </summary>
		public string dcAdminName
		{
			set{ _dcadminname=value;}
			get{return _dcadminname;}
		}
		/// <summary>
		/// 管理员密码
		/// </summary>
		public string dcPassword
		{
			set{ _dcpassword=value;}
			get{return _dcpassword;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string dcRealName
		{
			set{ _dcrealname=value;}
			get{return _dcrealname;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string dcPhone
		{
			set{ _dcphone=value;}
			get{return _dcphone;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public string dcQQ
		{
			set{ _dcqq=value;}
			get{return _dcqq;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime dtAddDate
		{
			set{ _dtadddate=value;}
			get{return _dtadddate;}
		}
		/// <summary>
		/// 登录时间
		/// </summary>
		public DateTime dtLoginTime
		{
			set{ _dtlogintime=value;}
			get{return _dtlogintime;}
		}
		/// <summary>
		/// 用户状态(1正常 0停用 2删除 )
		/// </summary>
		public int dnIsCheck
		{
			set{ _dnischeck=value;}
			get{return _dnischeck;}
		}
		#endregion Model

	}
}

