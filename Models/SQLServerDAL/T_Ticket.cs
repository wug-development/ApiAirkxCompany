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
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Ticket
	/// </summary>
	public partial class T_Ticket
	{
		public T_Ticket()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TicketID", "T_Ticket"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TicketID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Ticket");
			strSql.Append(" where TicketID=@TicketID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TicketID", SqlDbType.Int,4)			};
			parameters[0].Value = TicketID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_Ticket model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Ticket(");
			strSql.Append("TicketID,AirCompany,CityCode,AddUser,AddTime,EndCity,Guojia,DCS,WFS)");
			strSql.Append(" values (");
			strSql.Append("@TicketID,@AirCompany,@CityCode,@AddUser,@AddTime,@EndCity,@Guojia,@DCS,@WFS)");
			SqlParameter[] parameters = {
					new SqlParameter("@TicketID", SqlDbType.Int,4),
					new SqlParameter("@AirCompany", SqlDbType.VarChar,10),
					new SqlParameter("@CityCode", SqlDbType.Text),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,10),
					new SqlParameter("@AddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EndCity", SqlDbType.Text),
					new SqlParameter("@Guojia", SqlDbType.Text),
					new SqlParameter("@DCS", SqlDbType.Int,4),
					new SqlParameter("@WFS", SqlDbType.Int,4)};
			parameters[0].Value = model.TicketID;
			parameters[1].Value = model.AirCompany;
			parameters[2].Value = model.CityCode;
			parameters[3].Value = model.AddUser;
			parameters[4].Value = model.AddTime;
			parameters[5].Value = model.EndCity;
			parameters[6].Value = model.Guojia;
			parameters[7].Value = model.DCS;
			parameters[8].Value = model.WFS;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_Ticket model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Ticket set ");
			strSql.Append("AirCompany=@AirCompany,");
			strSql.Append("CityCode=@CityCode,");
			strSql.Append("AddUser=@AddUser,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("EndCity=@EndCity,");
			strSql.Append("Guojia=@Guojia,");
			strSql.Append("DCS=@DCS,");
			strSql.Append("WFS=@WFS");
			strSql.Append(" where TicketID=@TicketID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AirCompany", SqlDbType.VarChar,10),
					new SqlParameter("@CityCode", SqlDbType.Text),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,10),
					new SqlParameter("@AddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EndCity", SqlDbType.Text),
					new SqlParameter("@Guojia", SqlDbType.Text),
					new SqlParameter("@DCS", SqlDbType.Int,4),
					new SqlParameter("@WFS", SqlDbType.Int,4),
					new SqlParameter("@TicketID", SqlDbType.Int,4)};
			parameters[0].Value = model.AirCompany;
			parameters[1].Value = model.CityCode;
			parameters[2].Value = model.AddUser;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.EndCity;
			parameters[5].Value = model.Guojia;
			parameters[6].Value = model.DCS;
			parameters[7].Value = model.WFS;
			parameters[8].Value = model.TicketID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TicketID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Ticket ");
			strSql.Append(" where TicketID=@TicketID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TicketID", SqlDbType.Int,4)			};
			parameters[0].Value = TicketID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string TicketIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Ticket ");
			strSql.Append(" where TicketID in ("+TicketIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Ticket GetModel(int TicketID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TicketID,AirCompany,CityCode,AddUser,AddTime,EndCity,Guojia,DCS,WFS from T_Ticket ");
			strSql.Append(" where TicketID=@TicketID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TicketID", SqlDbType.Int,4)			};
			parameters[0].Value = TicketID;

			ApiAirkxCompany.Model.T_Ticket model=new ApiAirkxCompany.Model.T_Ticket();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Ticket DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_Ticket model=new ApiAirkxCompany.Model.T_Ticket();
			if (row != null)
			{
				if(row["TicketID"]!=null && row["TicketID"].ToString()!="")
				{
					model.TicketID=int.Parse(row["TicketID"].ToString());
				}
				if(row["AirCompany"]!=null)
				{
					model.AirCompany=row["AirCompany"].ToString();
				}
				if(row["CityCode"]!=null)
				{
					model.CityCode=row["CityCode"].ToString();
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["EndCity"]!=null)
				{
					model.EndCity=row["EndCity"].ToString();
				}
				if(row["Guojia"]!=null)
				{
					model.Guojia=row["Guojia"].ToString();
				}
				if(row["DCS"]!=null && row["DCS"].ToString()!="")
				{
					model.DCS=int.Parse(row["DCS"].ToString());
				}
				if(row["WFS"]!=null && row["WFS"].ToString()!="")
				{
					model.WFS=int.Parse(row["WFS"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TicketID,AirCompany,CityCode,AddUser,AddTime,EndCity,Guojia,DCS,WFS ");
			strSql.Append(" FROM T_Ticket ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" TicketID,AirCompany,CityCode,AddUser,AddTime,EndCity,Guojia,DCS,WFS ");
			strSql.Append(" FROM T_Ticket ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Ticket ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TicketID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Ticket T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Ticket";
			parameters[1].Value = "TicketID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

