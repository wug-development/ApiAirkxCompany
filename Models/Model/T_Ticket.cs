/**  版本信息模板在安装目录下，可自行修改。
* T_Ticket.cs
*
* 功 能： N/A
* 类 名： T_Ticket
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
*/
using System;
namespace ApiAirkxCompany.Model
{
	/// <summary>
	/// T_Ticket:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Ticket
	{
		public T_Ticket()
		{}
		#region Model
		private int _ticketid=0;
		private string _aircompany="";
		private string _citycode="";
		private string _adduser="";
		private DateTime _addtime= DateTime.Now;
		private string _endcity;
		private string _guojia="";
		private int _dcs=0;
		private int _wfs=0;
		/// <summary>
		/// 机票ID
		/// </summary>
		public int TicketID
		{
			set{ _ticketid=value;}
			get{return _ticketid;}
		}
		/// <summary>
		/// 航空公司Code
		/// </summary>
		public string AirCompany
		{
			set{ _aircompany=value;}
			get{return _aircompany;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 负责人
		/// </summary>
		public string AddUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// ''
		/// </summary>
		public string EndCity
		{
			set{ _endcity=value;}
			get{return _endcity;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string Guojia
		{
			set{ _guojia=value;}
			get{return _guojia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DCS
		{
			set{ _dcs=value;}
			get{return _dcs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WFS
		{
			set{ _wfs=value;}
			get{return _wfs;}
		}
		#endregion Model

	}
}

