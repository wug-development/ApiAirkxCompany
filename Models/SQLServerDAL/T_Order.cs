﻿/**  版本信息模板在安装目录下，可自行修改。
* T_Order.cs
*
* 功 能： N/A
* 类 名： T_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/9/20 18:21:33   N/A    初版
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
	/// 数据访问类:T_Order
	/// </summary>
	public partial class T_Order
	{
		public T_Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcOrderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Order");
			strSql.Append(" where dcOrderID=@dcOrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Order(");
			strSql.Append("dcOrderID,dcOrderCode,dcTicketNO,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID,dnStatus,dnIsPay)");
			strSql.Append(" values (");
			strSql.Append("@dcOrderID,@dcOrderCode,@dcTicketNO,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnServicePrice,@dnSafePrice,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime,@dnTicketID,@dnDetailID,@dnStatus,@dnIsPay)");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40),
					new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40),
					new SqlParameter("@dcTicketNO", SqlDbType.VarChar,30),
					new SqlParameter("@dnAirType", SqlDbType.Int,4),
					new SqlParameter("@dcStartDate", SqlDbType.VarChar,20),
					new SqlParameter("@dcBackDate", SqlDbType.VarChar,20),
					new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30),
					new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30),
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
					new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dnPrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnTax", SqlDbType.Decimal,9),
					new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9),
					new SqlParameter("@dcContent", SqlDbType.Text),
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnTicketID", SqlDbType.Int,4),
					new SqlParameter("@dnDetailID", SqlDbType.Int,4),
					new SqlParameter("@dnStatus", SqlDbType.Int,4),
					new SqlParameter("@dnIsPay", SqlDbType.Int,4)};
			parameters[0].Value = model.dcOrderID;
			parameters[1].Value = model.dcOrderCode;
			parameters[2].Value = model.dcTicketNO;
			parameters[3].Value = model.dnAirType;
			parameters[4].Value = model.dcStartDate;
			parameters[5].Value = model.dcBackDate;
			parameters[6].Value = model.dcStartCity;
			parameters[7].Value = model.dcBackCity;
			parameters[8].Value = model.dcCompanyID;
			parameters[9].Value = model.dcLinkName;
			parameters[10].Value = model.dcPhone;
			parameters[11].Value = model.dnPrice;
			parameters[12].Value = model.dnTax;
			parameters[13].Value = model.dnServicePrice;
			parameters[14].Value = model.dnSafePrice;
			parameters[15].Value = model.dnTotalPrice;
			parameters[16].Value = model.dcContent;
			parameters[17].Value = model.dcAdminID;
			parameters[18].Value = model.dcAdminName;
			parameters[19].Value = model.dtAddTime;
			parameters[20].Value = model.dnTicketID;
			parameters[21].Value = model.dnDetailID;
			parameters[22].Value = model.dnStatus;
			parameters[23].Value = model.dnIsPay;

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
		public bool Update(ApiAirkxCompany.Model.T_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Order set ");
			strSql.Append("dcOrderCode=@dcOrderCode,");
			strSql.Append("dcTicketNO=@dcTicketNO,");
			strSql.Append("dnAirType=@dnAirType,");
			strSql.Append("dcStartDate=@dcStartDate,");
			strSql.Append("dcBackDate=@dcBackDate,");
			strSql.Append("dcStartCity=@dcStartCity,");
			strSql.Append("dcBackCity=@dcBackCity,");
			strSql.Append("dcCompanyID=@dcCompanyID,");
			strSql.Append("dcLinkName=@dcLinkName,");
			strSql.Append("dcPhone=@dcPhone,");
			strSql.Append("dnPrice=@dnPrice,");
			strSql.Append("dnTax=@dnTax,");
			strSql.Append("dnServicePrice=@dnServicePrice,");
			strSql.Append("dnSafePrice=@dnSafePrice,");
			strSql.Append("dnTotalPrice=@dnTotalPrice,");
			strSql.Append("dcContent=@dcContent,");
			strSql.Append("dcAdminID=@dcAdminID,");
			strSql.Append("dcAdminName=@dcAdminName,");
			strSql.Append("dtAddTime=@dtAddTime,");
			strSql.Append("dnTicketID=@dnTicketID,");
			strSql.Append("dnDetailID=@dnDetailID,");
			strSql.Append("dnStatus=@dnStatus,");
			strSql.Append("dnIsPay=@dnIsPay");
			strSql.Append(" where dcOrderID=@dcOrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40),
					new SqlParameter("@dcTicketNO", SqlDbType.VarChar,30),
					new SqlParameter("@dnAirType", SqlDbType.Int,4),
					new SqlParameter("@dcStartDate", SqlDbType.VarChar,20),
					new SqlParameter("@dcBackDate", SqlDbType.VarChar,20),
					new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30),
					new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30),
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
					new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dnPrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnTax", SqlDbType.Decimal,9),
					new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9),
					new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9),
					new SqlParameter("@dcContent", SqlDbType.Text),
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnTicketID", SqlDbType.Int,4),
					new SqlParameter("@dnDetailID", SqlDbType.Int,4),
					new SqlParameter("@dnStatus", SqlDbType.Int,4),
					new SqlParameter("@dnIsPay", SqlDbType.Int,4),
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)};
			parameters[0].Value = model.dcOrderCode;
			parameters[1].Value = model.dcTicketNO;
			parameters[2].Value = model.dnAirType;
			parameters[3].Value = model.dcStartDate;
			parameters[4].Value = model.dcBackDate;
			parameters[5].Value = model.dcStartCity;
			parameters[6].Value = model.dcBackCity;
			parameters[7].Value = model.dcCompanyID;
			parameters[8].Value = model.dcLinkName;
			parameters[9].Value = model.dcPhone;
			parameters[10].Value = model.dnPrice;
			parameters[11].Value = model.dnTax;
			parameters[12].Value = model.dnServicePrice;
			parameters[13].Value = model.dnSafePrice;
			parameters[14].Value = model.dnTotalPrice;
			parameters[15].Value = model.dcContent;
			parameters[16].Value = model.dcAdminID;
			parameters[17].Value = model.dcAdminName;
			parameters[18].Value = model.dtAddTime;
			parameters[19].Value = model.dnTicketID;
			parameters[20].Value = model.dnDetailID;
			parameters[21].Value = model.dnStatus;
			parameters[22].Value = model.dnIsPay;
			parameters[23].Value = model.dcOrderID;

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
		public bool Delete(string dcOrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Order ");
			strSql.Append(" where dcOrderID=@dcOrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderID;

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
		public bool DeleteList(string dcOrderIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Order ");
			strSql.Append(" where dcOrderID in ("+dcOrderIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_Order GetModel(string dcOrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 dcOrderID,dcOrderCode,dcTicketNO,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID,dnStatus,dnIsPay from T_Order ");
			strSql.Append(" where dcOrderID=@dcOrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderID;

			ApiAirkxCompany.Model.T_Order model=new ApiAirkxCompany.Model.T_Order();
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
		public ApiAirkxCompany.Model.T_Order DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_Order model=new ApiAirkxCompany.Model.T_Order();
			if (row != null)
			{
				if(row["dcOrderID"]!=null)
				{
					model.dcOrderID=row["dcOrderID"].ToString();
				}
				if(row["dcOrderCode"]!=null)
				{
					model.dcOrderCode=row["dcOrderCode"].ToString();
				}
				if(row["dcTicketNO"]!=null)
				{
					model.dcTicketNO=row["dcTicketNO"].ToString();
				}
				if(row["dnAirType"]!=null && row["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(row["dnAirType"].ToString());
				}
				if(row["dcStartDate"]!=null)
				{
					model.dcStartDate=row["dcStartDate"].ToString();
				}
				if(row["dcBackDate"]!=null)
				{
					model.dcBackDate=row["dcBackDate"].ToString();
				}
				if(row["dcStartCity"]!=null)
				{
					model.dcStartCity=row["dcStartCity"].ToString();
				}
				if(row["dcBackCity"]!=null)
				{
					model.dcBackCity=row["dcBackCity"].ToString();
				}
				if(row["dcCompanyID"]!=null)
				{
					model.dcCompanyID=row["dcCompanyID"].ToString();
				}
				if(row["dcLinkName"]!=null)
				{
					model.dcLinkName=row["dcLinkName"].ToString();
				}
				if(row["dcPhone"]!=null)
				{
					model.dcPhone=row["dcPhone"].ToString();
				}
				if(row["dnPrice"]!=null && row["dnPrice"].ToString()!="")
				{
					model.dnPrice=decimal.Parse(row["dnPrice"].ToString());
				}
				if(row["dnTax"]!=null && row["dnTax"].ToString()!="")
				{
					model.dnTax=decimal.Parse(row["dnTax"].ToString());
				}
				if(row["dnServicePrice"]!=null && row["dnServicePrice"].ToString()!="")
				{
					model.dnServicePrice=decimal.Parse(row["dnServicePrice"].ToString());
				}
				if(row["dnSafePrice"]!=null && row["dnSafePrice"].ToString()!="")
				{
					model.dnSafePrice=decimal.Parse(row["dnSafePrice"].ToString());
				}
				if(row["dnTotalPrice"]!=null && row["dnTotalPrice"].ToString()!="")
				{
					model.dnTotalPrice=decimal.Parse(row["dnTotalPrice"].ToString());
				}
				if(row["dcContent"]!=null)
				{
					model.dcContent=row["dcContent"].ToString();
				}
				if(row["dcAdminID"]!=null)
				{
					model.dcAdminID=row["dcAdminID"].ToString();
				}
				if(row["dcAdminName"]!=null)
				{
					model.dcAdminName=row["dcAdminName"].ToString();
				}
				if(row["dtAddTime"]!=null && row["dtAddTime"].ToString()!="")
				{
					model.dtAddTime=DateTime.Parse(row["dtAddTime"].ToString());
				}
				if(row["dnTicketID"]!=null && row["dnTicketID"].ToString()!="")
				{
					model.dnTicketID=int.Parse(row["dnTicketID"].ToString());
				}
				if(row["dnDetailID"]!=null && row["dnDetailID"].ToString()!="")
				{
					model.dnDetailID=int.Parse(row["dnDetailID"].ToString());
				}
				if(row["dnStatus"]!=null && row["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(row["dnStatus"].ToString());
				}
				if(row["dnIsPay"]!=null && row["dnIsPay"].ToString()!="")
				{
					model.dnIsPay=int.Parse(row["dnIsPay"].ToString());
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
			strSql.Append("select dcOrderID,dcOrderCode,dcTicketNO,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID,dnStatus,dnIsPay ");
			strSql.Append(" FROM T_Order ");
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
			strSql.Append(" dcOrderID,dcOrderCode,dcTicketNO,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnServicePrice,dnSafePrice,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID,dnStatus,dnIsPay ");
			strSql.Append(" FROM T_Order ");
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
			strSql.Append("select count(1) FROM T_Order ");
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
				strSql.Append("order by T.dcOrderID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Order T ");
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
			parameters[0].Value = "T_Order";
			parameters[1].Value = "dcOrderID";
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

