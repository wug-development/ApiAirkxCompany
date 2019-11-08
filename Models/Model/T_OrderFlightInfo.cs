/**  版本信息模板在安装目录下，可自行修改。
* T_OrderFlightInfo.cs
*
* 功 能： N/A
* 类 名： T_OrderFlightInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/4 11:37:28   N/A    初版
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
	/// T_OrderFlightInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_OrderFlightInfo
	{
		public T_OrderFlightInfo()
		{}
		#region Model
		private string _dcorderflightid="";
		private string _dcorderid="";
		private int _dnairtype=0;
		private int _dnflighttype=0;
		private int _dnairid;
		private string _dcaircode="";
		private string _dcsportname="";
		private string _dceportname="";
		private string _dcsjetquay="";
		private string _dcejetquay="";
		private string _dcscode="";
		private string _dcecode="";
		private string _dcstime="";
		private string _dcetime="";
		private string _dcjixing="";
		private int _dcaircompanyid;
		private string _dccompanyname="";
		private string _dcencompanyname="";
		private string _dccompanylogo="";
		private string _dccompanycode="";
		private string _dcseatmsg="";
		private string _dccontent="";
		/// <summary>
		/// 订单航班ID
		/// </summary>
		public string dcOrderFlightID
		{
			set{ _dcorderflightid=value;}
			get{return _dcorderflightid;}
		}
		/// <summary>
		/// 订单ID
		/// </summary>
		public string dcOrderID
		{
			set{ _dcorderid=value;}
			get{return _dcorderid;}
		}
		/// <summary>
		/// 航班类型(1往返0单程)
		/// </summary>
		public int dnAirType
		{
			set{ _dnairtype=value;}
			get{return _dnairtype;}
		}
		/// <summary>
		/// 航线类型(0去程1回程)
		/// </summary>
		public int dnFlightType
		{
			set{ _dnflighttype=value;}
			get{return _dnflighttype;}
		}
		/// <summary>
		/// 航班ID
		/// </summary>
		public int dnAirID
		{
			set{ _dnairid=value;}
			get{return _dnairid;}
		}
		/// <summary>
		/// 航班Code
		/// </summary>
		public string dcAirCode
		{
			set{ _dcaircode=value;}
			get{return _dcaircode;}
		}
		/// <summary>
		/// 起飞机场
		/// </summary>
		public string dcSPortName
		{
			set{ _dcsportname=value;}
			get{return _dcsportname;}
		}
		/// <summary>
		/// 降落机场
		/// </summary>
		public string dcEPortName
		{
			set{ _dceportname=value;}
			get{return _dceportname;}
		}
		/// <summary>
		/// 始发航站楼
		/// </summary>
		public string dcSJetquay
		{
			set{ _dcsjetquay=value;}
			get{return _dcsjetquay;}
		}
		/// <summary>
		/// 到达航站楼
		/// </summary>
		public string dcEJetquay
		{
			set{ _dcejetquay=value;}
			get{return _dcejetquay;}
		}
		/// <summary>
		/// 起飞机场Code
		/// </summary>
		public string dcSCode
		{
			set{ _dcscode=value;}
			get{return _dcscode;}
		}
		/// <summary>
		/// 降落机场Code
		/// </summary>
		public string dcECode
		{
			set{ _dcecode=value;}
			get{return _dcecode;}
		}
		/// <summary>
		/// 起飞时间
		/// </summary>
		public string dcSTime
		{
			set{ _dcstime=value;}
			get{return _dcstime;}
		}
		/// <summary>
		/// 降落时间
		/// </summary>
		public string dcETime
		{
			set{ _dcetime=value;}
			get{return _dcetime;}
		}
		/// <summary>
		/// 机型
		/// </summary>
		public string dcJixing
		{
			set{ _dcjixing=value;}
			get{return _dcjixing;}
		}
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
		/// 舱位
		/// </summary>
		public string dcSeatMsg
		{
			set{ _dcseatmsg=value;}
			get{return _dcseatmsg;}
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

