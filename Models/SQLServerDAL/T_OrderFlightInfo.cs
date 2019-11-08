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
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_OrderFlightInfo
	/// </summary>
	public partial class T_OrderFlightInfo
	{
		public T_OrderFlightInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcOrderFlightID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_OrderFlightInfo");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_OrderFlightInfo(");
			strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent)");
			strSql.Append(" values (");
			strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSJetquay,@dcEJetquay,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcSeatMsg,@dcContent)");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40),
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40),
					new SqlParameter("@dnAirType", SqlDbType.Int,4),
					new SqlParameter("@dnFlightType", SqlDbType.Int,4),
					new SqlParameter("@dnAirID", SqlDbType.Int,4),
					new SqlParameter("@dcAirCode", SqlDbType.VarChar,20),
					new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@dcSJetquay", SqlDbType.VarChar,10),
					new SqlParameter("@dcEJetquay", SqlDbType.VarChar,10),
					new SqlParameter("@dcSCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcECode", SqlDbType.VarChar,10),
					new SqlParameter("@dcSTime", SqlDbType.VarChar,20),
					new SqlParameter("@dcETime", SqlDbType.VarChar,20),
					new SqlParameter("@dcJixing", SqlDbType.VarChar,10),
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4),
					new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@dcCompanyLogo", SqlDbType.Text),
					new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcSeatMsg", SqlDbType.NVarChar,20),
					new SqlParameter("@dcContent", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.dcOrderFlightID;
			parameters[1].Value = model.dcOrderID;
			parameters[2].Value = model.dnAirType;
			parameters[3].Value = model.dnFlightType;
			parameters[4].Value = model.dnAirID;
			parameters[5].Value = model.dcAirCode;
			parameters[6].Value = model.dcSPortName;
			parameters[7].Value = model.dcEPortName;
			parameters[8].Value = model.dcSJetquay;
			parameters[9].Value = model.dcEJetquay;
			parameters[10].Value = model.dcSCode;
			parameters[11].Value = model.dcECode;
			parameters[12].Value = model.dcSTime;
			parameters[13].Value = model.dcETime;
			parameters[14].Value = model.dcJixing;
			parameters[15].Value = model.dcAirCompanyID;
			parameters[16].Value = model.dcCompanyName;
			parameters[17].Value = model.dcEnCompanyName;
			parameters[18].Value = model.dcCompanyLogo;
			parameters[19].Value = model.dcCompanyCode;
			parameters[20].Value = model.dcSeatMsg;
			parameters[21].Value = model.dcContent;

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
		public bool Update(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_OrderFlightInfo set ");
			strSql.Append("dcOrderID=@dcOrderID,");
			strSql.Append("dnAirType=@dnAirType,");
			strSql.Append("dnFlightType=@dnFlightType,");
			strSql.Append("dnAirID=@dnAirID,");
			strSql.Append("dcAirCode=@dcAirCode,");
			strSql.Append("dcSPortName=@dcSPortName,");
			strSql.Append("dcEPortName=@dcEPortName,");
			strSql.Append("dcSJetquay=@dcSJetquay,");
			strSql.Append("dcEJetquay=@dcEJetquay,");
			strSql.Append("dcSCode=@dcSCode,");
			strSql.Append("dcECode=@dcECode,");
			strSql.Append("dcSTime=@dcSTime,");
			strSql.Append("dcETime=@dcETime,");
			strSql.Append("dcJixing=@dcJixing,");
			strSql.Append("dcAirCompanyID=@dcAirCompanyID,");
			strSql.Append("dcCompanyName=@dcCompanyName,");
			strSql.Append("dcEnCompanyName=@dcEnCompanyName,");
			strSql.Append("dcCompanyLogo=@dcCompanyLogo,");
			strSql.Append("dcCompanyCode=@dcCompanyCode,");
			strSql.Append("dcSeatMsg=@dcSeatMsg,");
			strSql.Append("dcContent=@dcContent");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40),
					new SqlParameter("@dnAirType", SqlDbType.Int,4),
					new SqlParameter("@dnFlightType", SqlDbType.Int,4),
					new SqlParameter("@dnAirID", SqlDbType.Int,4),
					new SqlParameter("@dcAirCode", SqlDbType.VarChar,20),
					new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@dcSJetquay", SqlDbType.VarChar,10),
					new SqlParameter("@dcEJetquay", SqlDbType.VarChar,10),
					new SqlParameter("@dcSCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcECode", SqlDbType.VarChar,10),
					new SqlParameter("@dcSTime", SqlDbType.VarChar,20),
					new SqlParameter("@dcETime", SqlDbType.VarChar,20),
					new SqlParameter("@dcJixing", SqlDbType.VarChar,10),
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4),
					new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@dcCompanyLogo", SqlDbType.Text),
					new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcSeatMsg", SqlDbType.NVarChar,20),
					new SqlParameter("@dcContent", SqlDbType.NVarChar,200),
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)};
			parameters[0].Value = model.dcOrderID;
			parameters[1].Value = model.dnAirType;
			parameters[2].Value = model.dnFlightType;
			parameters[3].Value = model.dnAirID;
			parameters[4].Value = model.dcAirCode;
			parameters[5].Value = model.dcSPortName;
			parameters[6].Value = model.dcEPortName;
			parameters[7].Value = model.dcSJetquay;
			parameters[8].Value = model.dcEJetquay;
			parameters[9].Value = model.dcSCode;
			parameters[10].Value = model.dcECode;
			parameters[11].Value = model.dcSTime;
			parameters[12].Value = model.dcETime;
			parameters[13].Value = model.dcJixing;
			parameters[14].Value = model.dcAirCompanyID;
			parameters[15].Value = model.dcCompanyName;
			parameters[16].Value = model.dcEnCompanyName;
			parameters[17].Value = model.dcCompanyLogo;
			parameters[18].Value = model.dcCompanyCode;
			parameters[19].Value = model.dcSeatMsg;
			parameters[20].Value = model.dcContent;
			parameters[21].Value = model.dcOrderFlightID;

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
		public bool Delete(string dcOrderFlightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OrderFlightInfo ");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;

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
		public bool DeleteList(string dcOrderFlightIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OrderFlightInfo ");
			strSql.Append(" where dcOrderFlightID in ("+dcOrderFlightIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_OrderFlightInfo GetModel(string dcOrderFlightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent from T_OrderFlightInfo ");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;

			ApiAirkxCompany.Model.T_OrderFlightInfo model=new ApiAirkxCompany.Model.T_OrderFlightInfo();
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
		public ApiAirkxCompany.Model.T_OrderFlightInfo DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_OrderFlightInfo model=new ApiAirkxCompany.Model.T_OrderFlightInfo();
			if (row != null)
			{
				if(row["dcOrderFlightID"]!=null)
				{
					model.dcOrderFlightID=row["dcOrderFlightID"].ToString();
				}
				if(row["dcOrderID"]!=null)
				{
					model.dcOrderID=row["dcOrderID"].ToString();
				}
				if(row["dnAirType"]!=null && row["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(row["dnAirType"].ToString());
				}
				if(row["dnFlightType"]!=null && row["dnFlightType"].ToString()!="")
				{
					model.dnFlightType=int.Parse(row["dnFlightType"].ToString());
				}
				if(row["dnAirID"]!=null && row["dnAirID"].ToString()!="")
				{
					model.dnAirID=int.Parse(row["dnAirID"].ToString());
				}
				if(row["dcAirCode"]!=null)
				{
					model.dcAirCode=row["dcAirCode"].ToString();
				}
				if(row["dcSPortName"]!=null)
				{
					model.dcSPortName=row["dcSPortName"].ToString();
				}
				if(row["dcEPortName"]!=null)
				{
					model.dcEPortName=row["dcEPortName"].ToString();
				}
				if(row["dcSJetquay"]!=null)
				{
					model.dcSJetquay=row["dcSJetquay"].ToString();
				}
				if(row["dcEJetquay"]!=null)
				{
					model.dcEJetquay=row["dcEJetquay"].ToString();
				}
				if(row["dcSCode"]!=null)
				{
					model.dcSCode=row["dcSCode"].ToString();
				}
				if(row["dcECode"]!=null)
				{
					model.dcECode=row["dcECode"].ToString();
				}
				if(row["dcSTime"]!=null)
				{
					model.dcSTime=row["dcSTime"].ToString();
				}
				if(row["dcETime"]!=null)
				{
					model.dcETime=row["dcETime"].ToString();
				}
				if(row["dcJixing"]!=null)
				{
					model.dcJixing=row["dcJixing"].ToString();
				}
				if(row["dcAirCompanyID"]!=null && row["dcAirCompanyID"].ToString()!="")
				{
					model.dcAirCompanyID=int.Parse(row["dcAirCompanyID"].ToString());
				}
				if(row["dcCompanyName"]!=null)
				{
					model.dcCompanyName=row["dcCompanyName"].ToString();
				}
				if(row["dcEnCompanyName"]!=null)
				{
					model.dcEnCompanyName=row["dcEnCompanyName"].ToString();
				}
				if(row["dcCompanyLogo"]!=null)
				{
					model.dcCompanyLogo=row["dcCompanyLogo"].ToString();
				}
				if(row["dcCompanyCode"]!=null)
				{
					model.dcCompanyCode=row["dcCompanyCode"].ToString();
				}
				if(row["dcSeatMsg"]!=null)
				{
					model.dcSeatMsg=row["dcSeatMsg"].ToString();
				}
				if(row["dcContent"]!=null)
				{
					model.dcContent=row["dcContent"].ToString();
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
			strSql.Append("select dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent ");
			strSql.Append(" FROM T_OrderFlightInfo ");
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
			strSql.Append(" dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSJetquay,dcEJetquay,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcSeatMsg,dcContent ");
			strSql.Append(" FROM T_OrderFlightInfo ");
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
			strSql.Append("select count(1) FROM T_OrderFlightInfo ");
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
				strSql.Append("order by T.dcOrderFlightID desc");
			}
			strSql.Append(")AS Row, T.*  from T_OrderFlightInfo T ");
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
			parameters[0].Value = "T_OrderFlightInfo";
			parameters[1].Value = "dcOrderFlightID";
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

