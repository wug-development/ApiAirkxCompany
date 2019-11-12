using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_PayRecord
		public partial class T_PayRecord
	{
   		     
		public bool Exists(string dcPRID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_PayRecord");
			strSql.Append(" where ");
			                                       strSql.Append(" dcPRID = @dcPRID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcPRID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcPRID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_PayRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_PayRecord(");			
            strSql.Append("dcPRID,dcCompanyID,dnMoney,dcPayType,dcPayDate,dcRemarks,dnStatus,dcAdminID,dcAdminName,dtAddDatetime,dcComfirmAdminID,dcComfirmDate");
			strSql.Append(") values (");
            strSql.Append("@dcPRID,@dcCompanyID,@dnMoney,@dcPayType,@dcPayDate,@dcRemarks,@dnStatus,@dcAdminID,@dcAdminName,@dtAddDatetime,@dcComfirmAdminID,@dcComfirmDate");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcPRID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPayType", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPayDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcRemarks", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dnStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dcComfirmAdminID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcComfirmDate", SqlDbType.VarChar,50)             
              
            };
			            
            parameters[0].Value = model.dcPRID;                        
            parameters[1].Value = model.dcCompanyID;                        
            parameters[2].Value = model.dnMoney;                        
            parameters[3].Value = model.dcPayType;                        
            parameters[4].Value = model.dcPayDate;                        
            parameters[5].Value = model.dcRemarks;                        
            parameters[6].Value = model.dnStatus;                        
            parameters[7].Value = model.dcAdminID;                        
            parameters[8].Value = model.dcAdminName;                        
            parameters[9].Value = model.dtAddDatetime;                        
            parameters[10].Value = model.dcComfirmAdminID;                        
            parameters[11].Value = model.dcComfirmDate;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_PayRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_PayRecord set ");
			                        
            strSql.Append(" dcPRID = @dcPRID , ");                                    
            strSql.Append(" dcCompanyID = @dcCompanyID , ");                                    
            strSql.Append(" dnMoney = @dnMoney , ");                                    
            strSql.Append(" dcPayType = @dcPayType , ");                                    
            strSql.Append(" dcPayDate = @dcPayDate , ");                                    
            strSql.Append(" dcRemarks = @dcRemarks , ");                                    
            strSql.Append(" dnStatus = @dnStatus , ");                                    
            strSql.Append(" dcAdminID = @dcAdminID , ");                                    
            strSql.Append(" dcAdminName = @dcAdminName , ");                                    
            strSql.Append(" dtAddDatetime = @dtAddDatetime , ");                                    
            strSql.Append(" dcComfirmAdminID = @dcComfirmAdminID , ");                                    
            strSql.Append(" dcComfirmDate = @dcComfirmDate  ");            			
			strSql.Append(" where dcPRID=@dcPRID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcPRID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPayType", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPayDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcRemarks", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dnStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcAdminName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddDatetime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@dcComfirmAdminID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcComfirmDate", SqlDbType.VarChar,50)             
              
            };
						            
            parameters[0].Value = model.dcPRID;                        
            parameters[1].Value = model.dcCompanyID;                        
            parameters[2].Value = model.dnMoney;                        
            parameters[3].Value = model.dcPayType;                        
            parameters[4].Value = model.dcPayDate;                        
            parameters[5].Value = model.dcRemarks;                        
            parameters[6].Value = model.dnStatus;                        
            parameters[7].Value = model.dcAdminID;                        
            parameters[8].Value = model.dcAdminName;                        
            parameters[9].Value = model.dtAddDatetime;                        
            parameters[10].Value = model.dcComfirmAdminID;                        
            parameters[11].Value = model.dcComfirmDate;                        
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
		public bool Delete(string dcPRID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_PayRecord ");
			strSql.Append(" where dcPRID=@dcPRID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcPRID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcPRID;


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
		public ApiAirkxCompany.Model.T_PayRecord GetModel(string dcPRID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcPRID, dcCompanyID, dnMoney, dcPayType, dcPayDate, dcRemarks, dnStatus, dcAdminID, dcAdminName, dtAddDatetime, dcComfirmAdminID, dcComfirmDate  ");			
			strSql.Append("  from T_PayRecord ");
			strSql.Append(" where dcPRID=@dcPRID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcPRID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcPRID;

			
			ApiAirkxCompany.Model.T_PayRecord model=new ApiAirkxCompany.Model.T_PayRecord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcPRID= ds.Tables[0].Rows[0]["dcPRID"].ToString();
																																model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnMoney"].ToString()!="")
				{
					model.dnMoney=decimal.Parse(ds.Tables[0].Rows[0]["dnMoney"].ToString());
				}
																																				model.dcPayType= ds.Tables[0].Rows[0]["dcPayType"].ToString();
																																model.dcPayDate= ds.Tables[0].Rows[0]["dcPayDate"].ToString();
																																model.dcRemarks= ds.Tables[0].Rows[0]["dcRemarks"].ToString();
																												if(ds.Tables[0].Rows[0]["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(ds.Tables[0].Rows[0]["dnStatus"].ToString());
				}
																																				model.dcAdminID= ds.Tables[0].Rows[0]["dcAdminID"].ToString();
																																model.dcAdminName= ds.Tables[0].Rows[0]["dcAdminName"].ToString();
																												if(ds.Tables[0].Rows[0]["dtAddDatetime"].ToString()!="")
				{
					model.dtAddDatetime=DateTime.Parse(ds.Tables[0].Rows[0]["dtAddDatetime"].ToString());
				}
																																				model.dcComfirmAdminID= ds.Tables[0].Rows[0]["dcComfirmAdminID"].ToString();
																																model.dcComfirmDate= ds.Tables[0].Rows[0]["dcComfirmDate"].ToString();
																										
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
			strSql.Append(" FROM T_PayRecord ");
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
			strSql.Append(" FROM T_PayRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

