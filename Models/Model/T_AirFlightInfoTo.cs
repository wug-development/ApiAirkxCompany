/**  版本信息模板在安装目录下，可自行修改。
* T_AirFlightInfoTo.cs
*
* 功 能： N/A
* 类 名： T_AirFlightInfoTo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/8/14 18:13:17   N/A    初版
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
	/// T_AirFlightInfoTo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_AirFlightInfoTo
	{
		public T_AirFlightInfoTo()
		{}
		#region Model
		private int _subairid;
		private string _aircode="";
		private string _sportname="";
		private string _eportname="";
		private string _scode="";
		private string _ecode="";
		private string _companycode="";
		private string _stime="";
		private string _etime="";
		private string _jixing="";
		private int _airid=0;
		/// <summary>
		/// 转机航班ID
		/// </summary>
		public int SubAirID
		{
			set{ _subairid=value;}
			get{return _subairid;}
		}
		/// <summary>
		/// 航班Code
		/// </summary>
		public string AirCode
		{
			set{ _aircode=value;}
			get{return _aircode;}
		}
		/// <summary>
		/// 起飞机场
		/// </summary>
		public string SPortName
		{
			set{ _sportname=value;}
			get{return _sportname;}
		}
		/// <summary>
		/// 降落机场
		/// </summary>
		public string EPortName
		{
			set{ _eportname=value;}
			get{return _eportname;}
		}
		/// <summary>
		/// 起飞机场Code
		/// </summary>
		public string SCode
		{
			set{ _scode=value;}
			get{return _scode;}
		}
		/// <summary>
		/// 降落机场Code
		/// </summary>
		public string ECode
		{
			set{ _ecode=value;}
			get{return _ecode;}
		}
		/// <summary>
		/// 航空公司Code
		/// </summary>
		public string CompanyCode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 起飞时间
		/// </summary>
		public string STime
		{
			set{ _stime=value;}
			get{return _stime;}
		}
		/// <summary>
		/// 降落时间
		/// </summary>
		public string ETime
		{
			set{ _etime=value;}
			get{return _etime;}
		}
		/// <summary>
		/// 机型
		/// </summary>
		public string Jixing
		{
			set{ _jixing=value;}
			get{return _jixing;}
		}
		/// <summary>
		/// 航班ID
		/// </summary>
		public int AirID
		{
			set{ _airid=value;}
			get{return _airid;}
		}
		#endregion Model

	}
}

