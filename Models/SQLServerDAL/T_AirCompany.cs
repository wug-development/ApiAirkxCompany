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
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_AirCompany
	/// </summary>
	public partial class T_AirCompany
	{
		public T_AirCompany()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("dcAirCompanyID", "T_AirCompany"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int dcAirCompanyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_AirCompany");
			strSql.Append(" where dcAirCompanyID=@dcAirCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4)			};
			parameters[0].Value = dcAirCompanyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_AirCompany model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_AirCompany(");
			strSql.Append("dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent)");
			strSql.Append(" values (");
			strSql.Append("@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcContent)");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4),
					new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@dcCompanyLogo", SqlDbType.Text),
					new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcContent", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.dcAirCompanyID;
			parameters[1].Value = model.dcCompanyName;
			parameters[2].Value = model.dcEnCompanyName;
			parameters[3].Value = model.dcCompanyLogo;
			parameters[4].Value = model.dcCompanyCode;
			parameters[5].Value = model.dcContent;

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
		public bool Update(ApiAirkxCompany.Model.T_AirCompany model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_AirCompany set ");
			strSql.Append("dcCompanyName=@dcCompanyName,");
			strSql.Append("dcEnCompanyName=@dcEnCompanyName,");
			strSql.Append("dcCompanyLogo=@dcCompanyLogo,");
			strSql.Append("dcCompanyCode=@dcCompanyCode,");
			strSql.Append("dcContent=@dcContent");
			strSql.Append(" where dcAirCompanyID=@dcAirCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@dcCompanyLogo", SqlDbType.Text),
					new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10),
					new SqlParameter("@dcContent", SqlDbType.NVarChar,200),
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.dcCompanyName;
			parameters[1].Value = model.dcEnCompanyName;
			parameters[2].Value = model.dcCompanyLogo;
			parameters[3].Value = model.dcCompanyCode;
			parameters[4].Value = model.dcContent;
			parameters[5].Value = model.dcAirCompanyID;

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
		public bool Delete(int dcAirCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AirCompany ");
			strSql.Append(" where dcAirCompanyID=@dcAirCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4)			};
			parameters[0].Value = dcAirCompanyID;

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
		public bool DeleteList(string dcAirCompanyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AirCompany ");
			strSql.Append(" where dcAirCompanyID in ("+dcAirCompanyIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_AirCompany GetModel(int dcAirCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent from T_AirCompany ");
			strSql.Append(" where dcAirCompanyID=@dcAirCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4)			};
			parameters[0].Value = dcAirCompanyID;

			ApiAirkxCompany.Model.T_AirCompany model=new ApiAirkxCompany.Model.T_AirCompany();
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
        public ApiAirkxCompany.Model.T_AirCompany GetModel(string dcCompanyCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent from T_AirCompany ");
            strSql.Append(" where dcCompanyCode=@dcCompanyCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10)            };
            parameters[0].Value = dcCompanyCode;

            ApiAirkxCompany.Model.T_AirCompany model = new ApiAirkxCompany.Model.T_AirCompany();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public ApiAirkxCompany.Model.T_AirCompany DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_AirCompany model=new ApiAirkxCompany.Model.T_AirCompany();
			if (row != null)
			{
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
			strSql.Append("select dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent ");
			strSql.Append(" FROM T_AirCompany ");
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
			strSql.Append(" dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent ");
			strSql.Append(" FROM T_AirCompany ");
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
			strSql.Append("select count(1) FROM T_AirCompany ");
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
				strSql.Append("order by T.dcAirCompanyID desc");
			}
			strSql.Append(")AS Row, T.*  from T_AirCompany T ");
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
			parameters[0].Value = "T_AirCompany";
			parameters[1].Value = "dcAirCompanyID";
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

