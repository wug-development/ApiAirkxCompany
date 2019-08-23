using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_OrderFlightInfo
		public partial class T_OrderFlightInfo
	{
   		     
		public bool Exists(string dcOrderFlightID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_OrderFlightInfo");
			strSql.Append(" where ");
			                                       strSql.Append(" dcOrderFlightID = @dcOrderFlightID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_OrderFlightInfo(");			
            strSql.Append("dcOrderFlightID,dcOrderID,dnAirType,dnFlightType,dnAirID,dcAirCode,dcSPortName,dcEPortName,dcSCode,dcECode,dcSTime,dcETime,dcJixing,dcAirCompanyID,dcCompanyName,dcEnCompanyName,dcCompanyLogo,dcCompanyCode,dcContent");
			strSql.Append(") values (");
            strSql.Append("@dcOrderFlightID,@dcOrderID,@dnAirType,@dnFlightType,@dnAirID,@dcAirCode,@dcSPortName,@dcEPortName,@dcSCode,@dcECode,@dcSTime,@dcETime,@dcJixing,@dcAirCompanyID,@dcCompanyName,@dcEnCompanyName,@dcCompanyLogo,@dcCompanyCode,@dcContent");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnFlightType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnAirID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAirCode", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcSCode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcECode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcSTime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcETime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcJixing", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcCompanyLogo", SqlDbType.Text) ,            
                        new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcContent", SqlDbType.NVarChar,200)             
              
            };
			            
            parameters[0].Value = model.dcOrderFlightID;                        
            parameters[1].Value = model.dcOrderID;                        
            parameters[2].Value = model.dnAirType;                        
            parameters[3].Value = model.dnFlightType;                        
            parameters[4].Value = model.dnAirID;                        
            parameters[5].Value = model.dcAirCode;                        
            parameters[6].Value = model.dcSPortName;                        
            parameters[7].Value = model.dcEPortName;                        
            parameters[8].Value = model.dcSCode;                        
            parameters[9].Value = model.dcECode;                        
            parameters[10].Value = model.dcSTime;                        
            parameters[11].Value = model.dcETime;                        
            parameters[12].Value = model.dcJixing;                        
            parameters[13].Value = model.dcAirCompanyID;                        
            parameters[14].Value = model.dcCompanyName;                        
            parameters[15].Value = model.dcEnCompanyName;                        
            parameters[16].Value = model.dcCompanyLogo;                        
            parameters[17].Value = model.dcCompanyCode;                        
            parameters[18].Value = model.dcContent;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_OrderFlightInfo set ");
			                        
            strSql.Append(" dcOrderFlightID = @dcOrderFlightID , ");                                    
            strSql.Append(" dcOrderID = @dcOrderID , ");                                    
            strSql.Append(" dnAirType = @dnAirType , ");                                    
            strSql.Append(" dnFlightType = @dnFlightType , ");                                    
            strSql.Append(" dnAirID = @dnAirID , ");                                    
            strSql.Append(" dcAirCode = @dcAirCode , ");                                    
            strSql.Append(" dcSPortName = @dcSPortName , ");                                    
            strSql.Append(" dcEPortName = @dcEPortName , ");                                    
            strSql.Append(" dcSCode = @dcSCode , ");                                    
            strSql.Append(" dcECode = @dcECode , ");                                    
            strSql.Append(" dcSTime = @dcSTime , ");                                    
            strSql.Append(" dcETime = @dcETime , ");                                    
            strSql.Append(" dcJixing = @dcJixing , ");                                    
            strSql.Append(" dcAirCompanyID = @dcAirCompanyID , ");                                    
            strSql.Append(" dcCompanyName = @dcCompanyName , ");                                    
            strSql.Append(" dcEnCompanyName = @dcEnCompanyName , ");                                    
            strSql.Append(" dcCompanyLogo = @dcCompanyLogo , ");                                    
            strSql.Append(" dcCompanyCode = @dcCompanyCode , ");                                    
            strSql.Append(" dcContent = @dcContent  ");            			
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnAirType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnFlightType", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnAirID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAirCode", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcSPortName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcEPortName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dcSCode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcECode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcSTime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcETime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcJixing", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcAirCompanyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcEnCompanyName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@dcCompanyLogo", SqlDbType.Text) ,            
                        new SqlParameter("@dcCompanyCode", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcContent", SqlDbType.NVarChar,200)             
              
            };
						            
            parameters[0].Value = model.dcOrderFlightID;                        
            parameters[1].Value = model.dcOrderID;                        
            parameters[2].Value = model.dnAirType;                        
            parameters[3].Value = model.dnFlightType;                        
            parameters[4].Value = model.dnAirID;                        
            parameters[5].Value = model.dcAirCode;                        
            parameters[6].Value = model.dcSPortName;                        
            parameters[7].Value = model.dcEPortName;                        
            parameters[8].Value = model.dcSCode;                        
            parameters[9].Value = model.dcECode;                        
            parameters[10].Value = model.dcSTime;                        
            parameters[11].Value = model.dcETime;                        
            parameters[12].Value = model.dcJixing;                        
            parameters[13].Value = model.dcAirCompanyID;                        
            parameters[14].Value = model.dcCompanyName;                        
            parameters[15].Value = model.dcEnCompanyName;                        
            parameters[16].Value = model.dcCompanyLogo;                        
            parameters[17].Value = model.dcCompanyCode;                        
            parameters[18].Value = model.dcContent;                        
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
		public bool Delete(string dcOrderFlightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OrderFlightInfo ");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;


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
		public ApiAirkxCompany.Model.T_OrderFlightInfo GetModel(string dcOrderFlightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcOrderFlightID, dcOrderID, dnAirType, dnFlightType, dnAirID, dcAirCode, dcSPortName, dcEPortName, dcSCode, dcECode, dcSTime, dcETime, dcJixing, dcAirCompanyID, dcCompanyName, dcEnCompanyName, dcCompanyLogo, dcCompanyCode, dcContent  ");			
			strSql.Append("  from T_OrderFlightInfo ");
			strSql.Append(" where dcOrderFlightID=@dcOrderFlightID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcOrderFlightID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcOrderFlightID;

			
			ApiAirkxCompany.Model.T_OrderFlightInfo model=new ApiAirkxCompany.Model.T_OrderFlightInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcOrderFlightID= ds.Tables[0].Rows[0]["dcOrderFlightID"].ToString();
																																model.dcOrderID= ds.Tables[0].Rows[0]["dcOrderID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(ds.Tables[0].Rows[0]["dnAirType"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnFlightType"].ToString()!="")
				{
					model.dnFlightType=int.Parse(ds.Tables[0].Rows[0]["dnFlightType"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnAirID"].ToString()!="")
				{
					model.dnAirID=int.Parse(ds.Tables[0].Rows[0]["dnAirID"].ToString());
				}
																																				model.dcAirCode= ds.Tables[0].Rows[0]["dcAirCode"].ToString();
																																model.dcSPortName= ds.Tables[0].Rows[0]["dcSPortName"].ToString();
																																model.dcEPortName= ds.Tables[0].Rows[0]["dcEPortName"].ToString();
																																model.dcSCode= ds.Tables[0].Rows[0]["dcSCode"].ToString();
																																model.dcECode= ds.Tables[0].Rows[0]["dcECode"].ToString();
																																model.dcSTime= ds.Tables[0].Rows[0]["dcSTime"].ToString();
																																model.dcETime= ds.Tables[0].Rows[0]["dcETime"].ToString();
																																model.dcJixing= ds.Tables[0].Rows[0]["dcJixing"].ToString();
																												if(ds.Tables[0].Rows[0]["dcAirCompanyID"].ToString()!="")
				{
					model.dcAirCompanyID=int.Parse(ds.Tables[0].Rows[0]["dcAirCompanyID"].ToString());
				}
																																				model.dcCompanyName= ds.Tables[0].Rows[0]["dcCompanyName"].ToString();
																																model.dcEnCompanyName= ds.Tables[0].Rows[0]["dcEnCompanyName"].ToString();
																																model.dcCompanyLogo= ds.Tables[0].Rows[0]["dcCompanyLogo"].ToString();
																																model.dcCompanyCode= ds.Tables[0].Rows[0]["dcCompanyCode"].ToString();
																																model.dcContent= ds.Tables[0].Rows[0]["dcContent"].ToString();
																										
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
			strSql.Append(" FROM T_OrderFlightInfo ");
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
			strSql.Append(" FROM T_OrderFlightInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

