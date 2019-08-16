/**  版本信息模板在安装目录下，可自行修改。
* T_TicketPrice.cs
*
* 功 能： N/A
* 类 名： T_TicketPrice
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
	/// T_TicketPrice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_TicketPrice
	{
		public T_TicketPrice()
		{}
		#region Model
		private int _detailid=0;
		private string _tickettype="";
		private decimal _ticketprice=0M;
		private string _beizhu="";
		private int _ticketid=0;
		private string _wfts= "0";
		private decimal _sandyprice=0M;
		private int _startm=0;
		private int _endm=0;
		/// <summary>
		/// 机票价格ID
		/// </summary>
		public int DetailID
		{
			set{ _detailid=value;}
			get{return _detailid;}
		}
		/// <summary>
		/// 机票类型
		/// </summary>
		public string TicketType
		{
			set{ _tickettype=value;}
			get{return _tickettype;}
		}
		/// <summary>
		/// 机票价格
		/// </summary>
		public decimal TicketPrice
		{
			set{ _ticketprice=value;}
			get{return _ticketprice;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string beizhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		/// <summary>
		/// 机票ID
		/// </summary>
		public int TicketID
		{
			set{ _ticketid=value;}
			get{return _ticketid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WFTS
		{
			set{ _wfts=value;}
			get{return _wfts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SandyPrice
		{
			set{ _sandyprice=value;}
			get{return _sandyprice;}
		}
		/// <summary>
		/// 开始月份
		/// </summary>
		public int startM
		{
			set{ _startm=value;}
			get{return _startm;}
		}
		/// <summary>
		/// 截止月份
		/// </summary>
		public int endM
		{
			set{ _endm=value;}
			get{return _endm;}
		}
		#endregion Model

	}
}

