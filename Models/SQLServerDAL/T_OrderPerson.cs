using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_OrderPerson
		public partial class T_OrderPerson
	{
   		     
		public bool Exists(string dcOPID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_OrderPerson");
			strSql.Append(" where ");
			                                       strSql.Append(" dcOPID = @dcOPID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcOPID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOPID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_OrderPerson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_OrderPerson(");			
            strSql.Append("dcOPID,dcOrderID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType");
			strSql.Append(") values (");
            strSql.Append("@dcOPID,@dcOrderID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcOPID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,            
                        new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcType", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.dcOPID;                        
            parameters[1].Value = model.dcOrderID;                        
            parameters[2].Value = model.dcPerName;                        
            parameters[3].Value = model.dcBirthday;                        
            parameters[4].Value = model.dcPassportNo;                        
            parameters[5].Value = model.dcPassportDate;                        
            parameters[6].Value = model.dcSex;                        
            parameters[7].Value = model.dcIDNumber;                        
            parameters[8].Value = model.dcPhone;                        
            parameters[9].Value = model.dcUrgentPhone;                        
            parameters[10].Value = model.dcType;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_OrderPerson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_OrderPerson set ");
			                        
            strSql.Append(" dcOPID = @dcOPID , ");                                    
            strSql.Append(" dcOrderID = @dcOrderID , ");                                    
            strSql.Append(" dcPerName = @dcPerName , ");                                    
            strSql.Append(" dcBirthday = @dcBirthday , ");                                    
            strSql.Append(" dcPassportNo = @dcPassportNo , ");                                    
            strSql.Append(" dcPassportDate = @dcPassportDate , ");                                    
            strSql.Append(" dcSex = @dcSex , ");                                    
            strSql.Append(" dcIDNumber = @dcIDNumber , ");                                    
            strSql.Append(" dcPhone = @dcPhone , ");                                    
            strSql.Append(" dcUrgentPhone = @dcUrgentPhone , ");                                    
            strSql.Append(" dcType = @dcType  ");            			
			strSql.Append(" where dcOPID=@dcOPID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcOPID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,            
                        new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcType", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.dcOPID;                        
            parameters[1].Value = model.dcOrderID;                        
            parameters[2].Value = model.dcPerName;                        
            parameters[3].Value = model.dcBirthday;                        
            parameters[4].Value = model.dcPassportNo;                        
            parameters[5].Value = model.dcPassportDate;                        
            parameters[6].Value = model.dcSex;                        
            parameters[7].Value = model.dcIDNumber;                        
            parameters[8].Value = model.dcPhone;                        
            parameters[9].Value = model.dcUrgentPhone;                        
            parameters[10].Value = model.dcType;                        
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
		public bool Delete(string dcOPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OrderPerson ");
			strSql.Append(" where dcOPID=@dcOPID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcOPID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOPID;


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
		public ApiAirkxCompany.Model.T_OrderPerson GetModel(string dcOPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcOPID, dcOrderID, dcPerName, dcBirthday, dcPassportNo, dcPassportDate, dcSex, dcIDNumber, dcPhone, dcUrgentPhone, dcType  ");			
			strSql.Append("  from T_OrderPerson ");
			strSql.Append(" where dcOPID=@dcOPID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcOPID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOPID;

			
			ApiAirkxCompany.Model.T_OrderPerson model=new ApiAirkxCompany.Model.T_OrderPerson();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcOPID= ds.Tables[0].Rows[0]["dcOPID"].ToString();
																																model.dcOrderID= ds.Tables[0].Rows[0]["dcOrderID"].ToString();
																																model.dcPerName= ds.Tables[0].Rows[0]["dcPerName"].ToString();
																																model.dcBirthday= ds.Tables[0].Rows[0]["dcBirthday"].ToString();
																																model.dcPassportNo= ds.Tables[0].Rows[0]["dcPassportNo"].ToString();
																																model.dcPassportDate= ds.Tables[0].Rows[0]["dcPassportDate"].ToString();
																																model.dcSex= ds.Tables[0].Rows[0]["dcSex"].ToString();
																																model.dcIDNumber= ds.Tables[0].Rows[0]["dcIDNumber"].ToString();
																																model.dcPhone= ds.Tables[0].Rows[0]["dcPhone"].ToString();
																																model.dcUrgentPhone= ds.Tables[0].Rows[0]["dcUrgentPhone"].ToString();
																												if(ds.Tables[0].Rows[0]["dcType"].ToString()!="")
				{
					model.dcType=int.Parse(ds.Tables[0].Rows[0]["dcType"].ToString());
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
			strSql.Append(" FROM T_OrderPerson ");
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
			strSql.Append(" FROM T_OrderPerson ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

