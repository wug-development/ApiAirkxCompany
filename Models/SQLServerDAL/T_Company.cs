/** 
* T_Company.cs
* 类 名： T_Company
* V0.01  2019/11/16 12:03:24
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ApiAirkxCompany.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Company
	/// </summary>
	public partial class T_Company
	{
		public T_Company()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcCompanyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Company");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Company(");
			strSql.Append("dcCompanyID,dcUserName,dcPassword,dcFirstLetter,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dnServicePirce,dtCheckOutDate,dcLinkName,dcPhone,dcAdminID,dcAdminName,dcOther,dtAddDatetime,dnIsCheck)");
			strSql.Append(" values (");
			strSql.Append("@dcCompanyID,@dcUserName,@dcPassword,@dcFirstLetter,@dcFullName,@dcShortName,@dcRegistrationNumber,@dnRegisteredFunds,@dcBusinessAddress,@dcMainBusiness,@dcShareholder,@dcLegalRepresentative,@dcLicenseRegistrationAddr,@dcBankAccount,@dcOpeningBank,@dcParentCompanyID,@dnCreditLine,@dnServicePirce,@dtCheckOutDate,@dcLinkName,@dcPhone,@dcAdminID,@dcAdminName,@dcOther,@dtAddDatetime,@dnIsCheck)");
			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40),
					new SqlParameter("@dcUserName", SqlDbType.NVarChar,40),
					new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
					new SqlParameter("@dcFirstLetter", SqlDbType.VarChar,2),
					new SqlParameter("@dcFullName", SqlDbType.NVarChar,60),
					new SqlParameter("@dcShortName", SqlDbType.NVarChar,30),
					new SqlParameter("@dcRegistrationNumber", SqlDbType.VarChar,32),
					new SqlParameter("@dnRegisteredFunds", SqlDbType.Decimal,9),
					new SqlParameter("@dcBusinessAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@dcMainBusiness", SqlDbType.NVarChar,200),
					new SqlParameter("@dcShareholder", SqlDbType.NVarChar,200),
					new SqlParameter("@dcLegalRepresentative", SqlDbType.NVarChar,20),
					new SqlParameter("@dcLicenseRegistrationAddr", SqlDbType.NVarChar,120),
					new SqlParameter("@dcBankAccount", SqlDbType.VarChar,40),
					new SqlParameter("@dcOpeningBank", SqlDbType.NVarChar,50),
					new SqlParameter("@dcParentCompanyID", SqlDbType.VarChar,40),
					new SqlParameter("@dnCreditLine", SqlDbType.Int,4),
					new SqlParameter("@dnServicePirce", SqlDbType.Decimal,9),
					new SqlParameter("@dtCheckOutDate", SqlDbType.NVarChar,20),
					new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcOther", SqlDbType.NVarChar,200),
					new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnIsCheck", SqlDbType.Int,4)};
			parameters[0].Value = model.dcCompanyID;
			parameters[1].Value = model.dcUserName;
			parameters[2].Value = model.dcPassword;
			parameters[3].Value = model.dcFirstLetter;
			parameters[4].Value = model.dcFullName;
			parameters[5].Value = model.dcShortName;
			parameters[6].Value = model.dcRegistrationNumber;
			parameters[7].Value = model.dnRegisteredFunds;
			parameters[8].Value = model.dcBusinessAddress;
			parameters[9].Value = model.dcMainBusiness;
			parameters[10].Value = model.dcShareholder;
			parameters[11].Value = model.dcLegalRepresentative;
			parameters[12].Value = model.dcLicenseRegistrationAddr;
			parameters[13].Value = model.dcBankAccount;
			parameters[14].Value = model.dcOpeningBank;
			parameters[15].Value = model.dcParentCompanyID;
			parameters[16].Value = model.dnCreditLine;
			parameters[17].Value = model.dnServicePirce;
			parameters[18].Value = model.dtCheckOutDate;
			parameters[19].Value = model.dcLinkName;
			parameters[20].Value = model.dcPhone;
			parameters[21].Value = model.dcAdminID;
			parameters[22].Value = model.dcAdminName;
			parameters[23].Value = model.dcOther;
			parameters[24].Value = model.dtAddDatetime;
			parameters[25].Value = 1;

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
		public bool Update(ApiAirkxCompany.Model.T_Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Company set ");
			strSql.Append("dcUserName=@dcUserName,");
			strSql.Append("dcPassword=@dcPassword,");
			strSql.Append("dcFirstLetter=@dcFirstLetter,");
			strSql.Append("dcFullName=@dcFullName,");
			strSql.Append("dcShortName=@dcShortName,");
			strSql.Append("dcRegistrationNumber=@dcRegistrationNumber,");
			strSql.Append("dnRegisteredFunds=@dnRegisteredFunds,");
			strSql.Append("dcBusinessAddress=@dcBusinessAddress,");
			strSql.Append("dcMainBusiness=@dcMainBusiness,");
			strSql.Append("dcShareholder=@dcShareholder,");
			strSql.Append("dcLegalRepresentative=@dcLegalRepresentative,");
			strSql.Append("dcLicenseRegistrationAddr=@dcLicenseRegistrationAddr,");
			strSql.Append("dcBankAccount=@dcBankAccount,");
			strSql.Append("dcOpeningBank=@dcOpeningBank,");
			strSql.Append("dcParentCompanyID=@dcParentCompanyID,");
			strSql.Append("dnCreditLine=@dnCreditLine,");
			strSql.Append("dnServicePirce=@dnServicePirce,");
			strSql.Append("dtCheckOutDate=@dtCheckOutDate,");
			strSql.Append("dcLinkName=@dcLinkName,");
			strSql.Append("dcPhone=@dcPhone,");
			strSql.Append("dcAdminID=@dcAdminID,");
			strSql.Append("dcAdminName=@dcAdminName,");
			strSql.Append("dcOther=@dcOther,");
			strSql.Append("dtAddDatetime=@dtAddDatetime,");
			strSql.Append("dnIsCheck=@dnIsCheck");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcUserName", SqlDbType.NVarChar,40),
					new SqlParameter("@dcPassword", SqlDbType.VarChar,50),
					new SqlParameter("@dcFirstLetter", SqlDbType.VarChar,2),
					new SqlParameter("@dcFullName", SqlDbType.NVarChar,60),
					new SqlParameter("@dcShortName", SqlDbType.NVarChar,30),
					new SqlParameter("@dcRegistrationNumber", SqlDbType.VarChar,32),
					new SqlParameter("@dnRegisteredFunds", SqlDbType.Decimal,9),
					new SqlParameter("@dcBusinessAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@dcMainBusiness", SqlDbType.NVarChar,200),
					new SqlParameter("@dcShareholder", SqlDbType.NVarChar,200),
					new SqlParameter("@dcLegalRepresentative", SqlDbType.NVarChar,20),
					new SqlParameter("@dcLicenseRegistrationAddr", SqlDbType.NVarChar,120),
					new SqlParameter("@dcBankAccount", SqlDbType.VarChar,40),
					new SqlParameter("@dcOpeningBank", SqlDbType.NVarChar,50),
					new SqlParameter("@dcParentCompanyID", SqlDbType.VarChar,40),
					new SqlParameter("@dnCreditLine", SqlDbType.Int,4),
					new SqlParameter("@dnServicePirce", SqlDbType.Decimal,9),
					new SqlParameter("@dtCheckOutDate", SqlDbType.NVarChar,20),
					new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcPhone", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminID", SqlDbType.VarChar,40),
					new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20),
					new SqlParameter("@dcOther", SqlDbType.NVarChar,200),
					new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime),
					new SqlParameter("@dnIsCheck", SqlDbType.Int,4),
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)};
			parameters[0].Value = model.dcUserName;
			parameters[1].Value = model.dcPassword;
			parameters[2].Value = model.dcFirstLetter;
			parameters[3].Value = model.dcFullName;
			parameters[4].Value = model.dcShortName;
			parameters[5].Value = model.dcRegistrationNumber;
			parameters[6].Value = model.dnRegisteredFunds;
			parameters[7].Value = model.dcBusinessAddress;
			parameters[8].Value = model.dcMainBusiness;
			parameters[9].Value = model.dcShareholder;
			parameters[10].Value = model.dcLegalRepresentative;
			parameters[11].Value = model.dcLicenseRegistrationAddr;
			parameters[12].Value = model.dcBankAccount;
			parameters[13].Value = model.dcOpeningBank;
			parameters[14].Value = model.dcParentCompanyID;
			parameters[15].Value = model.dnCreditLine;
			parameters[16].Value = model.dnServicePirce;
			parameters[17].Value = model.dtCheckOutDate;
			parameters[18].Value = model.dcLinkName;
			parameters[19].Value = model.dcPhone;
			parameters[20].Value = model.dcAdminID;
			parameters[21].Value = model.dcAdminName;
			parameters[22].Value = model.dcOther;
			parameters[23].Value = model.dtAddDatetime;
			parameters[24].Value = model.dnIsCheck;
			parameters[25].Value = model.dcCompanyID;

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
		public bool Delete(string dcCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Company ");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

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
		public bool DeleteList(string dcCompanyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Company ");
			strSql.Append(" where dcCompanyID in ("+dcCompanyIDlist + ")  ");
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
		public ApiAirkxCompany.Model.T_Company GetModel(string dcCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 dcCompanyID,dcUserName,dcPassword,dcFirstLetter,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dnServicePirce,dtCheckOutDate,dcLinkName,dcPhone,dcAdminID,dcAdminName,dcOther,dtAddDatetime,dnIsCheck from T_Company ");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

			ApiAirkxCompany.Model.T_Company model=new ApiAirkxCompany.Model.T_Company();
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
		public ApiAirkxCompany.Model.T_Company DataRowToModel(DataRow row)
		{
			ApiAirkxCompany.Model.T_Company model=new ApiAirkxCompany.Model.T_Company();
			if (row != null)
			{
				if(row["dcCompanyID"]!=null)
				{
					model.dcCompanyID=row["dcCompanyID"].ToString();
				}
				if(row["dcUserName"]!=null)
				{
					model.dcUserName=row["dcUserName"].ToString();
				}
				if(row["dcPassword"]!=null)
				{
					model.dcPassword=row["dcPassword"].ToString();
				}
				if(row["dcFirstLetter"]!=null)
				{
					model.dcFirstLetter=row["dcFirstLetter"].ToString();
				}
				if(row["dcFullName"]!=null)
				{
					model.dcFullName=row["dcFullName"].ToString();
				}
				if(row["dcShortName"]!=null)
				{
					model.dcShortName=row["dcShortName"].ToString();
				}
				if(row["dcRegistrationNumber"]!=null)
				{
					model.dcRegistrationNumber=row["dcRegistrationNumber"].ToString();
				}
				if(row["dnRegisteredFunds"]!=null && row["dnRegisteredFunds"].ToString()!="")
				{
					model.dnRegisteredFunds=decimal.Parse(row["dnRegisteredFunds"].ToString());
				}
				if(row["dcBusinessAddress"]!=null)
				{
					model.dcBusinessAddress=row["dcBusinessAddress"].ToString();
				}
				if(row["dcMainBusiness"]!=null)
				{
					model.dcMainBusiness=row["dcMainBusiness"].ToString();
				}
				if(row["dcShareholder"]!=null)
				{
					model.dcShareholder=row["dcShareholder"].ToString();
				}
				if(row["dcLegalRepresentative"]!=null)
				{
					model.dcLegalRepresentative=row["dcLegalRepresentative"].ToString();
				}
				if(row["dcLicenseRegistrationAddr"]!=null)
				{
					model.dcLicenseRegistrationAddr=row["dcLicenseRegistrationAddr"].ToString();
				}
				if(row["dcBankAccount"]!=null)
				{
					model.dcBankAccount=row["dcBankAccount"].ToString();
				}
				if(row["dcOpeningBank"]!=null)
				{
					model.dcOpeningBank=row["dcOpeningBank"].ToString();
				}
				if(row["dcParentCompanyID"]!=null)
				{
					model.dcParentCompanyID=row["dcParentCompanyID"].ToString();
				}
				if(row["dnCreditLine"]!=null && row["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=int.Parse(row["dnCreditLine"].ToString());
				}
				if(row["dnServicePirce"]!=null && row["dnServicePirce"].ToString()!="")
				{
					model.dnServicePirce=decimal.Parse(row["dnServicePirce"].ToString());
				}
				if(row["dtCheckOutDate"]!=null)
				{
					model.dtCheckOutDate=row["dtCheckOutDate"].ToString();
				}
				if(row["dcLinkName"]!=null)
				{
					model.dcLinkName=row["dcLinkName"].ToString();
				}
				if(row["dcPhone"]!=null)
				{
					model.dcPhone=row["dcPhone"].ToString();
				}
				if(row["dcAdminID"]!=null)
				{
					model.dcAdminID=row["dcAdminID"].ToString();
				}
				if(row["dcAdminName"]!=null)
				{
					model.dcAdminName=row["dcAdminName"].ToString();
				}
				if(row["dcOther"]!=null)
				{
					model.dcOther=row["dcOther"].ToString();
				}
				if(row["dtAddDatetime"]!=null && row["dtAddDatetime"].ToString()!="")
				{
					model.dtAddDatetime=DateTime.Parse(row["dtAddDatetime"].ToString());
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
			strSql.Append("select dcCompanyID,dcUserName,dcPassword,dcFirstLetter,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dnServicePirce,dtCheckOutDate,dcLinkName,dcPhone,dcAdminID,dcAdminName,dcOther,dtAddDatetime,dnIsCheck ");
			strSql.Append(" FROM T_Company ");
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
			strSql.Append(" dcCompanyID,dcUserName,dcPassword,dcFirstLetter,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dnServicePirce,dtCheckOutDate,dcLinkName,dcPhone,dcAdminID,dcAdminName,dcOther,dtAddDatetime,dnIsCheck ");
			strSql.Append(" FROM T_Company ");
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
			strSql.Append("select count(1) FROM T_Company ");
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
				strSql.Append("order by T.dcCompanyID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Company T ");
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
			parameters[0].Value = "T_Company";
			parameters[1].Value = "dcCompanyID";
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

