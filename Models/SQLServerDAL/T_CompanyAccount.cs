using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_CompanyAccount
		public partial class T_CompanyAccount
	{
   		     
		public bool Exists(string dcCAID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CompanyAccount");
			strSql.Append(" where ");
			                                       strSql.Append(" dcCAID = @dcCAID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcCAID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCAID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_CompanyAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CompanyAccount(");			
            strSql.Append("dcCAID,dcCompanyID,dnCreditLine,dnDebt,dnPayCount,dnUrgentMoney,dcLastOrderDate,dnTotalTicketPrice");
			strSql.Append(") values (");
            strSql.Append("@dcCAID,@dcCompanyID,@dnCreditLine,@dnDebt,@dnPayCount,@dnUrgentMoney,@dcLastOrderDate,@dnTotalTicketPrice");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcCAID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnCreditLine", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnDebt", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnPayCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnUrgentMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcLastOrderDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dnTotalTicketPrice", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.dcCAID;                        
            parameters[1].Value = model.dcCompanyID;                        
            parameters[2].Value = model.dnCreditLine;                        
            parameters[3].Value = model.dnDebt;                        
            parameters[4].Value = model.dnPayCount;                        
            parameters[5].Value = model.dnUrgentMoney;                        
            parameters[6].Value = model.dcLastOrderDate;                        
            parameters[7].Value = model.dnTotalTicketPrice;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_CompanyAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CompanyAccount set ");
			                        
            strSql.Append(" dcCAID = @dcCAID , ");                                    
            strSql.Append(" dcCompanyID = @dcCompanyID , ");                                    
            strSql.Append(" dnCreditLine = @dnCreditLine , ");                                    
            strSql.Append(" dnDebt = @dnDebt , ");                                    
            strSql.Append(" dnPayCount = @dnPayCount , ");                                    
            strSql.Append(" dnUrgentMoney = @dnUrgentMoney , ");                                    
            strSql.Append(" dcLastOrderDate = @dcLastOrderDate , ");                                    
            strSql.Append(" dnTotalTicketPrice = @dnTotalTicketPrice  ");            			
			strSql.Append(" where dcCAID=@dcCAID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcCAID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnCreditLine", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnDebt", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnPayCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnUrgentMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcLastOrderDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dnTotalTicketPrice", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.dcCAID;                        
            parameters[1].Value = model.dcCompanyID;                        
            parameters[2].Value = model.dnCreditLine;                        
            parameters[3].Value = model.dnDebt;                        
            parameters[4].Value = model.dnPayCount;                        
            parameters[5].Value = model.dnUrgentMoney;                        
            parameters[6].Value = model.dcLastOrderDate;                        
            parameters[7].Value = model.dnTotalTicketPrice;                        
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
		public bool Delete(string dcCAID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CompanyAccount ");
			strSql.Append(" where dcCAID=@dcCAID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcCAID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCAID;


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
		public ApiAirkxCompany.Model.T_CompanyAccount GetModel(string dcCAID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcCAID, dcCompanyID, dnCreditLine, dnDebt, dnPayCount, dnUrgentMoney, dcLastOrderDate, dnTotalTicketPrice  ");			
			strSql.Append("  from T_CompanyAccount ");
			strSql.Append(" where dcCAID=@dcCAID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcCAID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCAID;

			
			ApiAirkxCompany.Model.T_CompanyAccount model=new ApiAirkxCompany.Model.T_CompanyAccount();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcCAID= ds.Tables[0].Rows[0]["dcCAID"].ToString();
																																model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=decimal.Parse(ds.Tables[0].Rows[0]["dnCreditLine"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnDebt"].ToString()!="")
				{
					model.dnDebt=decimal.Parse(ds.Tables[0].Rows[0]["dnDebt"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnPayCount"].ToString()!="")
				{
					model.dnPayCount=decimal.Parse(ds.Tables[0].Rows[0]["dnPayCount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnUrgentMoney"].ToString()!="")
				{
					model.dnUrgentMoney=decimal.Parse(ds.Tables[0].Rows[0]["dnUrgentMoney"].ToString());
				}
																																				model.dcLastOrderDate= ds.Tables[0].Rows[0]["dcLastOrderDate"].ToString();
																												if(ds.Tables[0].Rows[0]["dnTotalTicketPrice"].ToString()!="")
				{
					model.dnTotalTicketPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnTotalTicketPrice"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_CompanyAccount GetCModel(string dcCompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcCAID, dcCompanyID, dnCreditLine, dnDebt, dnPayCount, dnUrgentMoney, dcLastOrderDate, dnTotalTicketPrice  ");			
			strSql.Append("  from T_CompanyAccount ");
			strSql.Append(" where dcCompanyID=@dcCompanyID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcCompanyID;

			
			ApiAirkxCompany.Model.T_CompanyAccount model=new ApiAirkxCompany.Model.T_CompanyAccount();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcCAID= ds.Tables[0].Rows[0]["dcCAID"].ToString();
																																model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=decimal.Parse(ds.Tables[0].Rows[0]["dnCreditLine"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnDebt"].ToString()!="")
				{
					model.dnDebt=decimal.Parse(ds.Tables[0].Rows[0]["dnDebt"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnPayCount"].ToString()!="")
				{
					model.dnPayCount=decimal.Parse(ds.Tables[0].Rows[0]["dnPayCount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnUrgentMoney"].ToString()!="")
				{
					model.dnUrgentMoney=decimal.Parse(ds.Tables[0].Rows[0]["dnUrgentMoney"].ToString());
				}
																																				model.dcLastOrderDate= ds.Tables[0].Rows[0]["dcLastOrderDate"].ToString();
																												if(ds.Tables[0].Rows[0]["dnTotalTicketPrice"].ToString()!="")
				{
					model.dnTotalTicketPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnTotalTicketPrice"].ToString());
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
			strSql.Append(" FROM T_CompanyAccount ");
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
			strSql.Append(" FROM T_CompanyAccount ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

