/**  版本信息模板在安装目录下，可自行修改。
* T_AirFlightInfo.cs
*
* 功 能： N/A
* 类 名： T_AirFlightInfo
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
	/// 数据访问类:T_AirFlightInfo
	/// </summary>
	public partial class T_AirFlightInfo
	{
		public T_AirFlightInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AirID", "T_AirFlightInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AirID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_AirFlightInfo");
			strSql.Append(" where AirID=@AirID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AirID", SqlDbType.Int,4)			};
			parameters[0].Value = AirID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_AirFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_AirFlightInfo(");
			strSql.Append("AirID,AirCode,SPortName,EPortName,SCode,ECode,CompanyCode,STime,ETime,Jixing,AddUser)");
			strSql.Append(" values (");
			strSql.Append("@AirID,@AirCode,@SPortName,@EPortName,@SCode,@ECode,@CompanyCode,@STime,@ETime,@Jixing,@AddUser)");
			SqlParameter[] parameters = {
					new SqlParameter("@AirID", SqlDbType.Int,4),
					new SqlParameter("@AirCode", SqlDbType.VarChar,20),
					new SqlParameter("@SPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@EPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@SCode", SqlDbType.VarChar,10),
					new SqlParameter("@ECode", SqlDbType.VarChar,10),
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@STime", SqlDbType.VarChar,20),
					new SqlParameter("@ETime", SqlDbType.VarChar,20),
					new SqlParameter("@Jixing", SqlDbType.VarChar,10),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.AirID;
			parameters[1].Value = model.AirCode;
			parameters[2].Value = model.SPortName;
			parameters[3].Value = model.EPortName;
			parameters[4].Value = model.SCode;
			parameters[5].Value = model.ECode;
			parameters[6].Value = model.CompanyCode;
			parameters[7].Value = model.STime;
			parameters[8].Value = model.ETime;
			parameters[9].Value = model.Jixing;
			parameters[10].Value = model.AddUser;

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
		public bool Update(ApiAirkxCompany.Model.T_AirFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_AirFlightInfo set ");
			strSql.Append("AirCode=@AirCode,");
			strSql.Append("SPortName=@SPortName,");
			strSql.Append("EPortName=@EPortName,");
			strSql.Append("SCode=@SCode,");
			strSql.Append("ECode=@ECode,");
			strSql.Append("CompanyCode=@CompanyCode,");
			strSql.Append("STime=@STime,");
			strSql.Append("ETime=@ETime,");
			strSql.Append("Jixing=@Jixing,");
			strSql.Append("AddUser=@AddUser");
			strSql.Append(" where AirID=@AirID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AirCode", SqlDbType.VarChar,20),
					new SqlParameter("@SPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@EPortName", SqlDbType.NVarChar,50),
					new SqlParameter("@SCode", SqlDbType.VarChar,10),
					new SqlParameter("@ECode", SqlDbType.VarChar,10),
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@STime", SqlDbType.VarChar,20),
					new SqlParameter("@ETime", SqlDbType.VarChar,20),
					new SqlParameter("@Jixing", SqlDbType.VarChar,10),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,10),
					new SqlParameter("@AirID", SqlDbType.Int,4)};
			parameters[0].Value = model.AirCode;
			parameters[1].Value = model.SPortName;
			parameters[2].Value = model.EPortName;
			parameters[3].Value = model.SCode;
			parameters[4].Value = model.ECode;
			parameters[5].Value = model.CompanyCode;
			parameters[6].Value = model.STime;
			parameters[7].Value = model.ETime;
			parameters[8].Value = model.Jixing;
			parameters[9].Value = model.AddUser;
			parameters[10].Value = model.AirID;

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
		public bool Delete(int AirID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AirFlightInfo ");
			strSql.Append(" where AirID=@AirID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AirID", SqlDbType.Int,4)			};
			parameters[0].Value = AirID;

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
		public bool DeleteList(string AirIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AirFlightInfo ");
			strSql.Append(" where AirID in ("+AirIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_AirFlightInfo GetModel(int AirID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AirID,AirCode,SPortName,EPortName,SCode,ECode,CompanyCode,STime,ETime,Jixing,AddUser from T_AirFlightInfo ");
			strSql.Append(" where AirID=@AirID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AirID", SqlDbType.Int,4)			};
			parameters[0].Value = AirID;

			ApiAirkxCompany.Model.T_AirFlightInfo model=new ApiAirkxCompany.Model.T_AirFlightInfo();
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
		public ApiAirkxCompany.Model.T_AirFlightInfo DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_AirFlightInfo model=new ApiAirkxCompany.Model.T_AirFlightInfo();
			if (row != null)
			{
				if(row["AirID"]!=null && row["AirID"].ToString()!="")
				{
					model.AirID=int.Parse(row["AirID"].ToString());
				}
				if(row["AirCode"]!=null)
				{
					model.AirCode=row["AirCode"].ToString();
				}
				if(row["SPortName"]!=null)
				{
					model.SPortName=row["SPortName"].ToString();
				}
				if(row["EPortName"]!=null)
				{
					model.EPortName=row["EPortName"].ToString();
				}
				if(row["SCode"]!=null)
				{
					model.SCode=row["SCode"].ToString();
				}
				if(row["ECode"]!=null)
				{
					model.ECode=row["ECode"].ToString();
				}
				if(row["CompanyCode"]!=null)
				{
					model.CompanyCode=row["CompanyCode"].ToString();
				}
				if(row["STime"]!=null)
				{
					model.STime=row["STime"].ToString();
				}
				if(row["ETime"]!=null)
				{
					model.ETime=row["ETime"].ToString();
				}
				if(row["Jixing"]!=null)
				{
					model.Jixing=row["Jixing"].ToString();
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
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
			strSql.Append("select AirID,AirCode,SPortName,EPortName,SCode,ECode,CompanyCode,STime,ETime,Jixing,AddUser ");
			strSql.Append(" FROM T_AirFlightInfo ");
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
			strSql.Append(" AirID,AirCode,SPortName,EPortName,SCode,ECode,CompanyCode,STime,ETime,Jixing,AddUser ");
			strSql.Append(" FROM T_AirFlightInfo ");
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
			strSql.Append("select count(1) FROM T_AirFlightInfo ");
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
				strSql.Append("order by T.AirID desc");
			}
			strSql.Append(")AS Row, T.*  from T_AirFlightInfo T ");
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
			parameters[0].Value = "T_AirFlightInfo";
			parameters[1].Value = "AirID";
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

