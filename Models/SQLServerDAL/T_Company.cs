using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_Company
		public partial class T_Company
	{
   		     
		public bool Exists(string dcCompanyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Company");
			strSql.Append(" where ");
			                                       strSql.Append(" dcCompanyID = @dcCompanyID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Company(");			
            strSql.Append("dcCompanyID,dcUserName,dcPassword,dcFullName,dcShortName,dcRegistrationNumber,dnRegisteredFunds,dcBusinessAddress,dcMainBusiness,dcShareholder,dcLegalRepresentative,dcLicenseRegistrationAddr,dcBankAccount,dcOpeningBank,dcParentCompanyID,dnCreditLine,dtCheckOutDate,dcAdminID,dcOther,dtAddDatetime,dnIsCheck");
			strSql.Append(") values (");
            strSql.Append("@dcCompanyID,@dcUserName,@dcPassword,@dcFullName,@dcShortName,@dcRegistrationNumber,@dnRegisteredFunds,@dcBusinessAddress,@dcMainBusiness,@dcShareholder,@dcLegalRepresentative,@dcLicenseRegistrationAddr,@dcBankAccount,@dcOpeningBank,@dcParentCompanyID,@dnCreditLine,@dtCheckOutDate,@dcAdminID,@dcOther,@dtAddDatetime,@dnIsCheck");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcUserName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcPassword", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcFullName", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@dcShortName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcRegistrationNumber", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@dnRegisteredFunds", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcBusinessAddress", SqlDbType.NVarChar,120) ,            
                        new SqlParameter("@dcMainBusiness", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dcShareholder", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dcLegalRepresentative", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcLicenseRegistrationAddr", SqlDbType.NVarChar,120) ,            
                        new SqlParameter("@dcBankAccount", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOpeningBank", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcParentCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnCreditLine", SqlDbType.Int,4) ,            
                        new SqlParameter("@dtCheckOutDate", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOther", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dnIsCheck", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.dcCompanyID;                        
            parameters[1].Value = model.dcUserName;                        
            parameters[2].Value = model.dcPassword;                        
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
            parameters[16].Value = model.dtCheckOutDate;                        
            parameters[17].Value = model.dcAdminID;                        
            parameters[18].Value = model.dcOther;                        
            parameters[19].Value = model.dtAddDatetime;                        
            parameters[20].Value = model.dnIsCheck;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Company set ");
			                        
            strSql.Append(" dcCompanyID = @dcCompanyID , ");                                    
            strSql.Append(" dcUserName = @dcUserName , ");                                    
            strSql.Append(" dcPassword = @dcPassword , ");                                    
            strSql.Append(" dcFullName = @dcFullName , ");                                    
            strSql.Append(" dcShortName = @dcShortName , ");                                    
            strSql.Append(" dcRegistrationNumber = @dcRegistrationNumber , ");                                    
            strSql.Append(" dnRegisteredFunds = @dnRegisteredFunds , ");                                    
            strSql.Append(" dcBusinessAddress = @dcBusinessAddress , ");                                    
            strSql.Append(" dcMainBusiness = @dcMainBusiness , ");                                    
            strSql.Append(" dcShareholder = @dcShareholder , ");                                    
            strSql.Append(" dcLegalRepresentative = @dcLegalRepresentative , ");                                    
            strSql.Append(" dcLicenseRegistrationAddr = @dcLicenseRegistrationAddr , ");                                    
            strSql.Append(" dcBankAccount = @dcBankAccount , ");                                    
            strSql.Append(" dcOpeningBank = @dcOpeningBank , ");                                    
            strSql.Append(" dcParentCompanyID = @dcParentCompanyID , ");                                    
            strSql.Append(" dnCreditLine = @dnCreditLine , ");                                    
            strSql.Append(" dtCheckOutDate = @dtCheckOutDate , ");                                    
            strSql.Append(" dcAdminID = @dcAdminID , ");                                    
            strSql.Append(" dcOther = @dcOther , ");                                    
            strSql.Append(" dtAddDatetime = @dtAddDatetime , ");                                    
            strSql.Append(" dnIsCheck = @dnIsCheck  ");            			
			strSql.Append(" where dcCompanyID=@dcCompanyID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcUserName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcPassword", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcFullName", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@dcShortName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcRegistrationNumber", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@dnRegisteredFunds", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcBusinessAddress", SqlDbType.NVarChar,120) ,            
                        new SqlParameter("@dcMainBusiness", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dcShareholder", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dcLegalRepresentative", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcLicenseRegistrationAddr", SqlDbType.NVarChar,120) ,            
                        new SqlParameter("@dcBankAccount", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOpeningBank", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcParentCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnCreditLine", SqlDbType.Int,4) ,            
                        new SqlParameter("@dtCheckOutDate", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOther", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dnIsCheck", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.dcCompanyID;                        
            parameters[1].Value = model.dcUserName;                        
            parameters[2].Value = model.dcPassword;                        
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
            parameters[16].Value = model.dtCheckOutDate;                        
            parameters[17].Value = model.dcAdminID;                        
            parameters[18].Value = model.dcOther;                        
            parameters[19].Value = model.dtAddDatetime;                        
            parameters[20].Value = model.dnIsCheck;                        
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
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Company GetModel(string dcCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcCompanyID, dcUserName, dcPassword, dcFullName, dcShortName, dcRegistrationNumber, dnRegisteredFunds, dcBusinessAddress, dcMainBusiness, dcShareholder, dcLegalRepresentative, dcLicenseRegistrationAddr, dcBankAccount, dcOpeningBank, dcParentCompanyID, dnCreditLine, dtCheckOutDate, dcAdminID, dcOther, dtAddDatetime, dnIsCheck  ");			
			strSql.Append("  from T_Company ");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

			
			ApiAirkxCompany.Model.T_Company model=new ApiAirkxCompany.Model.T_Company();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																																model.dcUserName= ds.Tables[0].Rows[0]["dcUserName"].ToString();
																																model.dcPassword= ds.Tables[0].Rows[0]["dcPassword"].ToString();
																																model.dcFullName= ds.Tables[0].Rows[0]["dcFullName"].ToString();
																																model.dcShortName= ds.Tables[0].Rows[0]["dcShortName"].ToString();
																																model.dcRegistrationNumber= ds.Tables[0].Rows[0]["dcRegistrationNumber"].ToString();
																												if(ds.Tables[0].Rows[0]["dnRegisteredFunds"].ToString()!="")
				{
					model.dnRegisteredFunds=decimal.Parse(ds.Tables[0].Rows[0]["dnRegisteredFunds"].ToString());
				}
																																				model.dcBusinessAddress= ds.Tables[0].Rows[0]["dcBusinessAddress"].ToString();
																																model.dcMainBusiness= ds.Tables[0].Rows[0]["dcMainBusiness"].ToString();
																																model.dcShareholder= ds.Tables[0].Rows[0]["dcShareholder"].ToString();
																																model.dcLegalRepresentative= ds.Tables[0].Rows[0]["dcLegalRepresentative"].ToString();
																																model.dcLicenseRegistrationAddr= ds.Tables[0].Rows[0]["dcLicenseRegistrationAddr"].ToString();
																																model.dcBankAccount= ds.Tables[0].Rows[0]["dcBankAccount"].ToString();
																																model.dcOpeningBank= ds.Tables[0].Rows[0]["dcOpeningBank"].ToString();
																																model.dcParentCompanyID= ds.Tables[0].Rows[0]["dcParentCompanyID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=int.Parse(ds.Tables[0].Rows[0]["dnCreditLine"].ToString());
				}
																																				model.dtCheckOutDate= ds.Tables[0].Rows[0]["dtCheckOutDate"].ToString();
																																model.dcAdminID= ds.Tables[0].Rows[0]["dcAdminID"].ToString();
																																model.dcOther= ds.Tables[0].Rows[0]["dcOther"].ToString();
																												if(ds.Tables[0].Rows[0]["dtAddDatetime"].ToString()!="")
				{
					model.dtAddDatetime=DateTime.Parse(ds.Tables[0].Rows[0]["dtAddDatetime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnIsCheck"].ToString()!="")
				{
					model.dnIsCheck=int.Parse(ds.Tables[0].Rows[0]["dnIsCheck"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM T_Company ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

