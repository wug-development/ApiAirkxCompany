using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL  
{
	//T_AdminMenu
	public partial class T_AdminMenu
	{
   		     
		public bool Exists(string dcAMID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_AdminMenu");
			strSql.Append(" where ");
			                                       strSql.Append(" dcAMID = @dcAMID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcAMID", SqlDbType.VarChar,10)			};
			parameters[0].Value = dcAMID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_AdminMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_AdminMenu(");			
            strSql.Append("dcAMID,dcAdminID,dcMenuID");
			strSql.Append(") values (");
            strSql.Append("@dcAMID,@dcAdminID,@dcMenuID");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcAMID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcMenuID", SqlDbType.VarChar,10)             
              
            };
			            
            parameters[0].Value = model.dcAMID;                        
            parameters[1].Value = model.dcAdminID;                        
            parameters[2].Value = model.dcMenuID;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_AdminMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_AdminMenu set ");
			                        
            strSql.Append(" dcAMID = @dcAMID , ");                                    
            strSql.Append(" dcAdminID = @dcAdminID , ");                                    
            strSql.Append(" dcMenuID = @dcMenuID  ");            			
			strSql.Append(" where dcAMID=@dcAMID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcAMID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dcAdminID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcMenuID", SqlDbType.VarChar,10)             
              
            };
						            
            parameters[0].Value = model.dcAMID;                        
            parameters[1].Value = model.dcAdminID;                        
            parameters[2].Value = model.dcMenuID;                        
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
		public bool Delete(string dcAMID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AdminMenu ");
			strSql.Append(" where dcAMID=@dcAMID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcAMID", SqlDbType.VarChar,10)			};
			parameters[0].Value = dcAMID;


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
		public ApiAirkxCompany.Model.T_AdminMenu GetModel(string dcAMID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcAMID, dcAdminID, dcMenuID  ");			
			strSql.Append("  from T_AdminMenu ");
			strSql.Append(" where dcAMID=@dcAMID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcAMID", SqlDbType.VarChar,10)			};
			parameters[0].Value = dcAMID;

			
			ApiAirkxCompany.Model.T_AdminMenu model=new ApiAirkxCompany.Model.T_AdminMenu();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcAMID= ds.Tables[0].Rows[0]["dcAMID"].ToString();
																																model.dcAdminID= ds.Tables[0].Rows[0]["dcAdminID"].ToString();
																																model.dcMenuID= ds.Tables[0].Rows[0]["dcMenuID"].ToString();
																										
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
			strSql.Append(" FROM T_AdminMenu ");
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
			strSql.Append(" FROM T_AdminMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

