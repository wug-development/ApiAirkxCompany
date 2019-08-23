using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_Order
		public partial class T_Order
	{
   		     
		public bool Exists(string dcOrderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Order");
			strSql.Append(" where ");
			                                       strSql.Append(" dcOrderID = @dcOrderID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Order(");			
            strSql.Append("dcOrderID,dcOrderCode,dnAirType,dcStartDate,dcBackDate,dcStartCity,dcBackCity,dcCompanyID,dcLinkName,dcPhone,dnPrice,dnTax,dnTotalPrice,dcContent,dcAdminID,dcAdminName,dtAddTime,dnTicketID,dnDetailID");
			strSql.Append(") values (");
            strSql.Append("@dcOrderID,@dcOrderCode,@dnAirType,@dcStartDate,@dcBackDate,@dcStartCity,@dcBackCity,@dcCompanyID,@dcLinkName,@dcPhone,@dnPrice,@dnTax,@dnTotalPrice,@dcContent,@dcAdminID,@dcAdminName,@dtAddTime,@dnTicketID,@dnDetailID");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcBackDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcContent", SqlDbType.Text) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.dcOrderID;                        
            parameters[1].Value = model.dcOrderCode;                        
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
            parameters[12].Value = model.dnTotalPrice;                        
            parameters[13].Value = model.dcContent;                        
            parameters[14].Value = model.dcAdminID;                        
            parameters[15].Value = model.dcAdminName;                        
            parameters[16].Value = model.dtAddTime;                        
            parameters[17].Value = model.dnTicketID;                        
            parameters[18].Value = model.dnDetailID;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Order set ");
			                        
            strSql.Append(" dcOrderID = @dcOrderID , ");                                    
            strSql.Append(" dcOrderCode = @dcOrderCode , ");                                    
            strSql.Append(" dnAirType = @dnAirType , ");                                    
            strSql.Append(" dcStartDate = @dcStartDate , ");                                    
            strSql.Append(" dcBackDate = @dcBackDate , ");                                    
            strSql.Append(" dcStartCity = @dcStartCity , ");                                    
            strSql.Append(" dcBackCity = @dcBackCity , ");                                    
            strSql.Append(" dcCompanyID = @dcCompanyID , ");                                    
            strSql.Append(" dcLinkName = @dcLinkName , ");                                    
            strSql.Append(" dcPhone = @dcPhone , ");                                    
            strSql.Append(" dnPrice = @dnPrice , ");                                    
            strSql.Append(" dnTax = @dnTax , ");                                    
            strSql.Append(" dnTotalPrice = @dnTotalPrice , ");                                    
            strSql.Append(" dcContent = @dcContent , ");                                    
            strSql.Append(" dcAdminID = @dcAdminID , ");                                    
            strSql.Append(" dcAdminName = @dcAdminName , ");                                    
            strSql.Append(" dtAddTime = @dtAddTime , ");                                    
            strSql.Append(" dnTicketID = @dnTicketID , ");                                    
            strSql.Append(" dnDetailID = @dnDetailID  ");            			
			strSql.Append(" where dcOrderID=@dcOrderID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcBackDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcContent", SqlDbType.Text) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dnTicketID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnDetailID", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.dcOrderID;                        
            parameters[1].Value = model.dcOrderCode;                        
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
            parameters[12].Value = model.dnTotalPrice;                        
            parameters[13].Value = model.dcContent;                        
            parameters[14].Value = model.dcAdminID;                        
            parameters[15].Value = model.dcAdminName;                        
            parameters[16].Value = model.dtAddTime;                        
            parameters[17].Value = model.dnTicketID;                        
            parameters[18].Value = model.dnDetailID;                        
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
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Order GetModel(string dcOrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcOrderID, dcOrderCode, dnAirType, dcStartDate, dcBackDate, dcStartCity, dcBackCity, dcCompanyID, dcLinkName, dcPhone, dnPrice, dnTax, dnTotalPrice, dcContent, dcAdminID, dcAdminName, dtAddTime, dnTicketID, dnDetailID  ");			
			strSql.Append("  from T_Order ");
			strSql.Append(" where dcOrderID=@dcOrderID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcOrderID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderID;

			
			ApiAirkxCompany.Model.T_Order model=new ApiAirkxCompany.Model.T_Order();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcOrderID= ds.Tables[0].Rows[0]["dcOrderID"].ToString();
																																model.dcOrderCode= ds.Tables[0].Rows[0]["dcOrderCode"].ToString();
																												if(ds.Tables[0].Rows[0]["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(ds.Tables[0].Rows[0]["dnAirType"].ToString());
				}
																																				model.dcStartDate= ds.Tables[0].Rows[0]["dcStartDate"].ToString();
																																model.dcBackDate= ds.Tables[0].Rows[0]["dcBackDate"].ToString();
																																model.dcStartCity= ds.Tables[0].Rows[0]["dcStartCity"].ToString();
																																model.dcBackCity= ds.Tables[0].Rows[0]["dcBackCity"].ToString();
																																model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																																model.dcLinkName= ds.Tables[0].Rows[0]["dcLinkName"].ToString();
																																model.dcPhone= ds.Tables[0].Rows[0]["dcPhone"].ToString();
																												if(ds.Tables[0].Rows[0]["dnPrice"].ToString()!="")
				{
					model.dnPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnTax"].ToString()!="")
				{
					model.dnTax=decimal.Parse(ds.Tables[0].Rows[0]["dnTax"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnTotalPrice"].ToString()!="")
				{
					model.dnTotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnTotalPrice"].ToString());
				}
																																				model.dcContent= ds.Tables[0].Rows[0]["dcContent"].ToString();
																																model.dcAdminID= ds.Tables[0].Rows[0]["dcAdminID"].ToString();
																																model.dcAdminName= ds.Tables[0].Rows[0]["dcAdminName"].ToString();
																												if(ds.Tables[0].Rows[0]["dtAddTime"].ToString()!="")
				{
					model.dtAddTime=DateTime.Parse(ds.Tables[0].Rows[0]["dtAddTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnTicketID"].ToString()!="")
				{
					model.dnTicketID=int.Parse(ds.Tables[0].Rows[0]["dnTicketID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnDetailID"].ToString()!="")
				{
					model.dnDetailID=int.Parse(ds.Tables[0].Rows[0]["dnDetailID"].ToString());
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
			strSql.Append(" * ");
			strSql.Append(" FROM T_Order ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

