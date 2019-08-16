/**  版本信息模板在安装目录下，可自行修改。
* T_AirCompany.cs
*
* 功 能： N/A
* 类 名： T_AirCompany
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/8/14 18:13:18   N/A    初版
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
	/// T_AirCompany:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_AirCompany
	{
		public T_AirCompany()
		{}
		#region Model
		private int _dcaircompanyid;
		private string _dccompanyname="";
		private string _dcencompanyname="";
		private string _dccompanylogo="";
		private string _dccompanycode="";
		private string _dccontent="";
		/// <summary>
		/// 航空公司ID
		/// </summary>
		public int dcAirCompanyID
		{
			set{ _dcaircompanyid=value;}
			get{return _dcaircompanyid;}
		}
		/// <summary>
		/// 航空公司中文名称
		/// </summary>
		public string dcCompanyName
		{
			set{ _dccompanyname=value;}
			get{return _dccompanyname;}
		}
		/// <summary>
		/// 航空公司英文名称
		/// </summary>
		public string dcEnCompanyName
		{
			set{ _dcencompanyname=value;}
			get{return _dcencompanyname;}
		}
		/// <summary>
		/// 航空公司LOGO
		/// </summary>
		public string dcCompanyLogo
		{
			set{ _dccompanylogo=value;}
			get{return _dccompanylogo;}
		}
		/// <summary>
		/// 航空公司code
		/// </summary>
		public string dcCompanyCode
		{
			set{ _dccompanycode=value;}
			get{return _dccompanycode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string dcContent
		{
			set{ _dccontent=value;}
			get{return _dccontent;}
		}
		#endregion Model

	}
}

