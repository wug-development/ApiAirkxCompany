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
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_TicketPrice
	/// </summary>
	public partial class T_TicketPrice
	{
		public T_TicketPrice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DetailID", "T_TicketPrice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DetailID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_TicketPrice");
			strSql.Append(" where DetailID=@DetailID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DetailID", SqlDbType.Int,4)			};
			parameters[0].Value = DetailID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_TicketPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_TicketPrice(");
			strSql.Append("DetailID,TicketType,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM)");
			strSql.Append(" values (");
			strSql.Append("@DetailID,@TicketType,@TicketPrice,@beizhu,@TicketID,@WFTS,@SandyPrice,@startM,@endM)");
			SqlParameter[] parameters = {
					new SqlParameter("@DetailID", SqlDbType.Int,4),
					new SqlParameter("@TicketType", SqlDbType.NVarChar,10),
					new SqlParameter("@TicketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@beizhu", SqlDbType.Text),
					new SqlParameter("@TicketID", SqlDbType.Int,4),
					new SqlParameter("@WFTS", SqlDbType.NVarChar,50),
					new SqlParameter("@SandyPrice", SqlDbType.Decimal,9),
					new SqlParameter("@startM", SqlDbType.Int,4),
					new SqlParameter("@endM", SqlDbType.Int,4)};
			parameters[0].Value = model.DetailID;
			parameters[1].Value = model.TicketType;
			parameters[2].Value = model.TicketPrice;
			parameters[3].Value = model.beizhu;
			parameters[4].Value = model.TicketID;
			parameters[5].Value = model.WFTS;
			parameters[6].Value = model.SandyPrice;
			parameters[7].Value = model.startM;
			parameters[8].Value = model.endM;

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
		public bool Update(ApiAirkxCompany.Model.T_TicketPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_TicketPrice set ");
			strSql.Append("TicketType=@TicketType,");
			strSql.Append("TicketPrice=@TicketPrice,");
			strSql.Append("beizhu=@beizhu,");
			strSql.Append("TicketID=@TicketID,");
			strSql.Append("WFTS=@WFTS,");
			strSql.Append("SandyPrice=@SandyPrice,");
			strSql.Append("startM=@startM,");
			strSql.Append("endM=@endM");
			strSql.Append(" where DetailID=@DetailID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TicketType", SqlDbType.NVarChar,10),
					new SqlParameter("@TicketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@beizhu", SqlDbType.Text),
					new SqlParameter("@TicketID", SqlDbType.Int,4),
					new SqlParameter("@WFTS", SqlDbType.NVarChar,50),
					new SqlParameter("@SandyPrice", SqlDbType.Decimal,9),
					new SqlParameter("@startM", SqlDbType.Int,4),
					new SqlParameter("@endM", SqlDbType.Int,4),
					new SqlParameter("@DetailID", SqlDbType.Int,4)};
			parameters[0].Value = model.TicketType;
			parameters[1].Value = model.TicketPrice;
			parameters[2].Value = model.beizhu;
			parameters[3].Value = model.TicketID;
			parameters[4].Value = model.WFTS;
			parameters[5].Value = model.SandyPrice;
			parameters[6].Value = model.startM;
			parameters[7].Value = model.endM;
			parameters[8].Value = model.DetailID;

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
		public bool Delete(int DetailID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_TicketPrice ");
			strSql.Append(" where DetailID=@DetailID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DetailID", SqlDbType.Int,4)			};
			parameters[0].Value = DetailID;

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
		public bool DeleteList(string DetailIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_TicketPrice ");
			strSql.Append(" where DetailID in ("+DetailIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_TicketPrice GetModel(int DetailID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DetailID,TicketType,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM from T_TicketPrice ");
			strSql.Append(" where DetailID=@DetailID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DetailID", SqlDbType.Int,4)			};
			parameters[0].Value = DetailID;

			ApiAirkxCompany.Model.T_TicketPrice model=new ApiAirkxCompany.Model.T_TicketPrice();
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
		public ApiAirkxCompany.Model.T_TicketPrice DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_TicketPrice model=new ApiAirkxCompany.Model.T_TicketPrice();
			if (row != null)
			{
				if(row["DetailID"]!=null && row["DetailID"].ToString()!="")
				{
					model.DetailID=int.Parse(row["DetailID"].ToString());
				}
				if(row["TicketType"]!=null)
				{
					model.TicketType=row["TicketType"].ToString();
				}
				if(row["TicketPrice"]!=null && row["TicketPrice"].ToString()!="")
				{
					model.TicketPrice=decimal.Parse(row["TicketPrice"].ToString());
				}
				if(row["beizhu"]!=null)
				{
					model.beizhu=row["beizhu"].ToString();
				}
				if(row["TicketID"]!=null && row["TicketID"].ToString()!="")
				{
					model.TicketID=int.Parse(row["TicketID"].ToString());
				}
				if(row["WFTS"]!=null)
				{
					model.WFTS=row["WFTS"].ToString();
				}
				if(row["SandyPrice"]!=null && row["SandyPrice"].ToString()!="")
				{
					model.SandyPrice=decimal.Parse(row["SandyPrice"].ToString());
				}
				if(row["startM"]!=null && row["startM"].ToString()!="")
				{
					model.startM=int.Parse(row["startM"].ToString());
				}
				if(row["endM"]!=null && row["endM"].ToString()!="")
				{
					model.endM=int.Parse(row["endM"].ToString());
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
			strSql.Append("select DetailID,TicketType,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM ");
			strSql.Append(" FROM T_TicketPrice ");
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
			strSql.Append(" DetailID,TicketType,TicketPrice,beizhu,TicketID,WFTS,SandyPrice,startM,endM ");
			strSql.Append(" FROM T_TicketPrice ");
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
			strSql.Append("select count(1) FROM T_TicketPrice ");
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
				strSql.Append("order by T.DetailID desc");
			}
			strSql.Append(")AS Row, T.*  from T_TicketPrice T ");
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
			parameters[0].Value = "T_TicketPrice";
			parameters[1].Value = "DetailID";
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

