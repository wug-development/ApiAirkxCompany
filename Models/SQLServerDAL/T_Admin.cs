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
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Admin
	/// </summary>
	public partial class T_Admin
	{
		public T_Admin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcAdminID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Admin");
			strSql.Append(" where dcAdminID=@dcAdminID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcAdminID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Admin(");
			strSql.Append("dcAdminID,dcAdminName,dcPassword,dcRealName,dcPhone,dcQQ,dtAddDate,dtLoginTime,dnIsCheck)");
			strSql.Append(" values (");
			strSql.Append("@dcAdminID,@dcAdminName,@dcPassword,@dcRealName,@dcPhone,@dcQQ,@dtAddDate,@dtLoginTime,@dnIsCheck)");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
					new SqlParameter("@dcRealName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dcQQ", SqlDbType.VarChar,20),
					new SqlParameter("@dtAddDate", SqlDbType.SmallDateTime),
					new SqlParameter("@dtLoginTime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnIsCheck", SqlDbType.Int,4)};
			parameters[0].Value = model.dcAdminID;
			parameters[1].Value = model.dcAdminName;
			parameters[2].Value = model.dcPassword;
			parameters[3].Value = model.dcRealName;
			parameters[4].Value = model.dcPhone;
			parameters[5].Value = model.dcQQ;
			parameters[6].Value = model.dtAddDate;
			parameters[7].Value = model.dtLoginTime;
			parameters[8].Value = model.dnIsCheck;

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
		public bool Update(ApiAirkxCompany.Model.T_Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Admin set ");
			strSql.Append("dcAdminName=@dcAdminName,");
			strSql.Append("dcPassword=@dcPassword,");
			strSql.Append("dcRealName=@dcRealName,");
			strSql.Append("dcPhone=@dcPhone,");
			strSql.Append("dcQQ=@dcQQ,");
			strSql.Append("dtAddDate=@dtAddDate,");
			strSql.Append("dtLoginTime=@dtLoginTime,");
			strSql.Append("dnIsCheck=@dnIsCheck");
			strSql.Append(" where dcAdminID=@dcAdminID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
					new SqlParameter("@dcRealName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dcQQ", SqlDbType.VarChar,20),
					new SqlParameter("@dtAddDate", SqlDbType.SmallDateTime),
					new SqlParameter("@dtLoginTime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnIsCheck", SqlDbType.Int,4),
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40)};
			parameters[0].Value = model.dcAdminName;
			parameters[1].Value = model.dcPassword;
			parameters[2].Value = model.dcRealName;
			parameters[3].Value = model.dcPhone;
			parameters[4].Value = model.dcQQ;
			parameters[5].Value = model.dtAddDate;
			parameters[6].Value = model.dtLoginTime;
			parameters[7].Value = model.dnIsCheck;
			parameters[8].Value = model.dcAdminID;

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
		public bool Delete(string dcAdminID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Admin ");
			strSql.Append(" where dcAdminID=@dcAdminID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcAdminID;

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
		public bool DeleteList(string dcAdminIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Admin ");
			strSql.Append(" where dcAdminID in ("+dcAdminIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_Admin GetModel(string dcAdminID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 dcAdminID,dcAdminName,dcPassword,dcRealName,dcPhone,dcQQ,dtAddDate,dtLoginTime,dnIsCheck from T_Admin ");
			strSql.Append(" where dcAdminID=@dcAdminID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcAdminID;

			ApiAirkxCompany.Model.T_Admin model=new ApiAirkxCompany.Model.T_Admin();
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
		public ApiAirkxCompany.Model.T_Admin DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_Admin model=new ApiAirkxCompany.Model.T_Admin();
			if (row != null)
			{
				if(row["dcAdminID"]!=null)
				{
					model.dcAdminID=row["dcAdminID"].ToString();
				}
				if(row["dcAdminName"]!=null)
				{
					model.dcAdminName=row["dcAdminName"].ToString();
				}
				if(row["dcPassword"]!=null)
				{
					model.dcPassword=row["dcPassword"].ToString();
				}
				if(row["dcRealName"]!=null)
				{
					model.dcRealName=row["dcRealName"].ToString();
				}
				if(row["dcPhone"]!=null)
				{
					model.dcPhone=row["dcPhone"].ToString();
				}
				if(row["dcQQ"]!=null)
				{
					model.dcQQ=row["dcQQ"].ToString();
				}
				if(row["dtAddDate"]!=null && row["dtAddDate"].ToString()!="")
				{
					model.dtAddDate=DateTime.Parse(row["dtAddDate"].ToString());
				}
				if(row["dtLoginTime"]!=null && row["dtLoginTime"].ToString()!="")
				{
					model.dtLoginTime=DateTime.Parse(row["dtLoginTime"].ToString());
				}
				if(row["dnIsCheck"]!=null && row["dnIsCheck"].ToString()!="")
				{
					model.dnIsCheck=int.Parse(row["dnIsCheck"].ToString());
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
			strSql.Append("select dcAdminID,dcAdminName,dcPassword,dcRealName,dcPhone,dcQQ,dtAddDate,dtLoginTime,dnIsCheck ");
			strSql.Append(" FROM T_Admin ");
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
			strSql.Append(" dcAdminID,dcAdminName,dcPassword,dcRealName,dcPhone,dcQQ,dtAddDate,dtLoginTime,dnIsCheck ");
			strSql.Append(" FROM T_Admin ");
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
			strSql.Append("select count(1) FROM T_Admin ");
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
				strSql.Append("order by T.dcAdminID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Admin T ");
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
			parameters[0].Value = "T_Admin";
			parameters[1].Value = "dcAdminID";
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

