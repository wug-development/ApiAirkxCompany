using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//FinanceInfo
		public partial class FinanceInfo
	{
   		     
		public bool Exists(int FinanceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FinanceInfo");
			strSql.Append(" where ");
			                                       strSql.Append(" FinanceID = @FinanceID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@FinanceID", SqlDbType.Int,4)
			};
			parameters[0].Value = FinanceID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ApiAirkxCompany.Model.FinanceInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FinanceInfo(");			
            strSql.Append("Company,JLCode,DPrice,SJPrice,SHPrice,SSPrice,LRPrice,XSPrice,FDPrice,CPD,AddTime,AddUser,SKState,CPY,XC,RS,PH,FPTT,FPJE,FKFS,Customer,BZ,SPY,SPFS,ZK,SubFKFS,YSJE,YSJE1,FKFS1,SubFKFS1,SubSKState,GRYH,GRYH1,FDPrice1,YSPrice,FXPrice,SJDZ,JPQJ,CW,OrderCode,Jiangjin,JJRY,GPR,HBH,DPRQ,NewFXPrice,SKData,CPDXX,BXXX,FKState");
			strSql.Append(") values (");
            strSql.Append("@Company,@JLCode,@DPrice,@SJPrice,@SHPrice,@SSPrice,@LRPrice,@XSPrice,@FDPrice,@CPD,@AddTime,@AddUser,@SKState,@CPY,@XC,@RS,@PH,@FPTT,@FPJE,@FKFS,@Customer,@BZ,@SPY,@SPFS,@ZK,@SubFKFS,@YSJE,@YSJE1,@FKFS1,@SubFKFS1,@SubSKState,@GRYH,@GRYH1,@FDPrice1,@YSPrice,@FXPrice,@SJDZ,@JPQJ,@CW,@OrderCode,@Jiangjin,@JJRY,@GPR,@HBH,@DPRQ,@NewFXPrice,@SKData,@CPDXX,@BXXX,@FKState");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Company", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SJPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SHPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@LRPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@XSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPJE", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@BZ", SqlDbType.NText) ,            
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ZK", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFKFS", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFKFS1", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GRYH", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GRYH1", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FDPrice1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@YSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("@JPQJ", SqlDbType.Float,8) ,            
                        new SqlParameter("@CW", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@OrderCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Jiangjin", SqlDbType.Float,8) ,            
                        new SqlParameter("@JJRY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GPR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@HBH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPRQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@NewFXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SKData", SqlDbType.DateTime) ,            
                        new SqlParameter("@CPDXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@BXXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKState", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.Company;                        
            parameters[1].Value = model.JLCode;                        
            parameters[2].Value = model.DPrice;                        
            parameters[3].Value = model.SJPrice;                        
            parameters[4].Value = model.SHPrice;                        
            parameters[5].Value = model.SSPrice;                        
            parameters[6].Value = model.LRPrice;                        
            parameters[7].Value = model.XSPrice;                        
            parameters[8].Value = model.FDPrice;                        
            parameters[9].Value = model.CPD;                        
            parameters[10].Value = model.AddTime;                        
            parameters[11].Value = model.AddUser;                        
            parameters[12].Value = model.SKState;                        
            parameters[13].Value = model.CPY;                        
            parameters[14].Value = model.XC;                        
            parameters[15].Value = model.RS;                        
            parameters[16].Value = model.PH;                        
            parameters[17].Value = model.FPTT;                        
            parameters[18].Value = model.FPJE;                        
            parameters[19].Value = model.FKFS;                        
            parameters[20].Value = model.Customer;                        
            parameters[21].Value = model.BZ;                        
            parameters[22].Value = model.SPY;                        
            parameters[23].Value = model.SPFS;                        
            parameters[24].Value = model.ZK;                        
            parameters[25].Value = model.SubFKFS;                        
            parameters[26].Value = model.YSJE;                        
            parameters[27].Value = model.YSJE1;                        
            parameters[28].Value = model.FKFS1;                        
            parameters[29].Value = model.SubFKFS1;                        
            parameters[30].Value = model.SubSKState;                        
            parameters[31].Value = model.GRYH;                        
            parameters[32].Value = model.GRYH1;                        
            parameters[33].Value = model.FDPrice1;                        
            parameters[34].Value = model.YSPrice;                        
            parameters[35].Value = model.FXPrice;                        
            parameters[36].Value = model.SJDZ;                        
            parameters[37].Value = model.JPQJ;                        
            parameters[38].Value = model.CW;                        
            parameters[39].Value = model.OrderCode;                        
            parameters[40].Value = model.Jiangjin;                        
            parameters[41].Value = model.JJRY;                        
            parameters[42].Value = model.GPR;                        
            parameters[43].Value = model.HBH;                        
            parameters[44].Value = model.DPRQ;                        
            parameters[45].Value = model.NewFXPrice;                        
            parameters[46].Value = model.SKData;                        
            parameters[47].Value = model.CPDXX;                        
            parameters[48].Value = model.BXXX;                        
            parameters[49].Value = model.FKState;

            SqlHelperTool stool = new SqlHelperTool("gncw");
			object obj = stool.GetSingle(strSql.ToString(),parameters);			
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
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.FinanceInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FinanceInfo set ");
			                                                
            strSql.Append(" Company = @Company , ");                                    
            strSql.Append(" JLCode = @JLCode , ");                                    
            strSql.Append(" DPrice = @DPrice , ");                                    
            strSql.Append(" SJPrice = @SJPrice , ");                                    
            strSql.Append(" SHPrice = @SHPrice , ");                                    
            strSql.Append(" SSPrice = @SSPrice , ");                                    
            strSql.Append(" LRPrice = @LRPrice , ");                                    
            strSql.Append(" XSPrice = @XSPrice , ");                                    
            strSql.Append(" FDPrice = @FDPrice , ");                                    
            strSql.Append(" CPD = @CPD , ");                                    
            strSql.Append(" AddTime = @AddTime , ");                                    
            strSql.Append(" AddUser = @AddUser , ");                                    
            strSql.Append(" SKState = @SKState , ");                                    
            strSql.Append(" CPY = @CPY , ");                                    
            strSql.Append(" XC = @XC , ");                                    
            strSql.Append(" RS = @RS , ");                                    
            strSql.Append(" PH = @PH , ");                                    
            strSql.Append(" FPTT = @FPTT , ");                                    
            strSql.Append(" FPJE = @FPJE , ");                                    
            strSql.Append(" FKFS = @FKFS , ");                                    
            strSql.Append(" Customer = @Customer , ");                                    
            strSql.Append(" BZ = @BZ , ");                                    
            strSql.Append(" SPY = @SPY , ");                                    
            strSql.Append(" SPFS = @SPFS , ");                                    
            strSql.Append(" ZK = @ZK , ");                                    
            strSql.Append(" SubFKFS = @SubFKFS , ");                                    
            strSql.Append(" YSJE = @YSJE , ");                                    
            strSql.Append(" YSJE1 = @YSJE1 , ");                                    
            strSql.Append(" FKFS1 = @FKFS1 , ");                                    
            strSql.Append(" SubFKFS1 = @SubFKFS1 , ");                                    
            strSql.Append(" SubSKState = @SubSKState , ");                                    
            strSql.Append(" GRYH = @GRYH , ");                                    
            strSql.Append(" GRYH1 = @GRYH1 , ");                                    
            strSql.Append(" FDPrice1 = @FDPrice1 , ");                                    
            strSql.Append(" YSPrice = @YSPrice , ");                                    
            strSql.Append(" FXPrice = @FXPrice , ");                                    
            strSql.Append(" SJDZ = @SJDZ , ");                                    
            strSql.Append(" JPQJ = @JPQJ , ");                                    
            strSql.Append(" CW = @CW , ");                                    
            strSql.Append(" OrderCode = @OrderCode , ");                                    
            strSql.Append(" Jiangjin = @Jiangjin , ");                                    
            strSql.Append(" JJRY = @JJRY , ");                                    
            strSql.Append(" GPR = @GPR , ");                                    
            strSql.Append(" HBH = @HBH , ");                                    
            strSql.Append(" DPRQ = @DPRQ , ");                                    
            strSql.Append(" NewFXPrice = @NewFXPrice , ");                                    
            strSql.Append(" SKData = @SKData , ");                                    
            strSql.Append(" CPDXX = @CPDXX , ");                                    
            strSql.Append(" BXXX = @BXXX , ");                                    
            strSql.Append(" FKState = @FKState  ");            			
			strSql.Append(" where FinanceID=@FinanceID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@FinanceID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Company", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SJPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SHPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@LRPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@XSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPJE", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@BZ", SqlDbType.NText) ,            
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ZK", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFKFS", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFKFS1", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GRYH", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GRYH1", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FDPrice1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@YSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("@JPQJ", SqlDbType.Float,8) ,            
                        new SqlParameter("@CW", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@OrderCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Jiangjin", SqlDbType.Float,8) ,            
                        new SqlParameter("@JJRY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GPR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@HBH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPRQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@NewFXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@SKData", SqlDbType.DateTime) ,            
                        new SqlParameter("@CPDXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@BXXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKState", SqlDbType.NVarChar,50)             
              
            };
						            
            parameters[0].Value = model.FinanceID;                        
            parameters[1].Value = model.Company;                        
            parameters[2].Value = model.JLCode;                        
            parameters[3].Value = model.DPrice;                        
            parameters[4].Value = model.SJPrice;                        
            parameters[5].Value = model.SHPrice;                        
            parameters[6].Value = model.SSPrice;                        
            parameters[7].Value = model.LRPrice;                        
            parameters[8].Value = model.XSPrice;                        
            parameters[9].Value = model.FDPrice;                        
            parameters[10].Value = model.CPD;                        
            parameters[11].Value = model.AddTime;                        
            parameters[12].Value = model.AddUser;                        
            parameters[13].Value = model.SKState;                        
            parameters[14].Value = model.CPY;                        
            parameters[15].Value = model.XC;                        
            parameters[16].Value = model.RS;                        
            parameters[17].Value = model.PH;                        
            parameters[18].Value = model.FPTT;                        
            parameters[19].Value = model.FPJE;                        
            parameters[20].Value = model.FKFS;                        
            parameters[21].Value = model.Customer;                        
            parameters[22].Value = model.BZ;                        
            parameters[23].Value = model.SPY;                        
            parameters[24].Value = model.SPFS;                        
            parameters[25].Value = model.ZK;                        
            parameters[26].Value = model.SubFKFS;                        
            parameters[27].Value = model.YSJE;                        
            parameters[28].Value = model.YSJE1;                        
            parameters[29].Value = model.FKFS1;                        
            parameters[30].Value = model.SubFKFS1;                        
            parameters[31].Value = model.SubSKState;                        
            parameters[32].Value = model.GRYH;                        
            parameters[33].Value = model.GRYH1;                        
            parameters[34].Value = model.FDPrice1;                        
            parameters[35].Value = model.YSPrice;                        
            parameters[36].Value = model.FXPrice;                        
            parameters[37].Value = model.SJDZ;                        
            parameters[38].Value = model.JPQJ;                        
            parameters[39].Value = model.CW;                        
            parameters[40].Value = model.OrderCode;                        
            parameters[41].Value = model.Jiangjin;                        
            parameters[42].Value = model.JJRY;                        
            parameters[43].Value = model.GPR;                        
            parameters[44].Value = model.HBH;                        
            parameters[45].Value = model.DPRQ;                        
            parameters[46].Value = model.NewFXPrice;                        
            parameters[47].Value = model.SKData;                        
            parameters[48].Value = model.CPDXX;                        
            parameters[49].Value = model.BXXX;                        
            parameters[50].Value = model.FKState;                        
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
		public bool Delete(int FinanceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FinanceInfo ");
			strSql.Append(" where FinanceID=@FinanceID");
						SqlParameter[] parameters = {
					new SqlParameter("@FinanceID", SqlDbType.Int,4)
			};
			parameters[0].Value = FinanceID;


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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string FinanceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FinanceInfo ");
			strSql.Append(" where ID in ("+FinanceIDlist + ")  ");
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
		public ApiAirkxCompany.Model.FinanceInfo GetModel(int FinanceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FinanceID, Company, JLCode, DPrice, SJPrice, SHPrice, SSPrice, LRPrice, XSPrice, FDPrice, CPD, AddTime, AddUser, SKState, CPY, XC, RS, PH, FPTT, FPJE, FKFS, Customer, BZ, SPY, SPFS, ZK, SubFKFS, YSJE, YSJE1, FKFS1, SubFKFS1, SubSKState, GRYH, GRYH1, FDPrice1, YSPrice, FXPrice, SJDZ, JPQJ, CW, OrderCode, Jiangjin, JJRY, GPR, HBH, DPRQ, NewFXPrice, SKData, CPDXX, BXXX, FKState  ");			
			strSql.Append("  from FinanceInfo ");
			strSql.Append(" where FinanceID=@FinanceID");
						SqlParameter[] parameters = {
					new SqlParameter("@FinanceID", SqlDbType.Int,4)
			};
			parameters[0].Value = FinanceID;

			
			ApiAirkxCompany.Model.FinanceInfo model=new ApiAirkxCompany.Model.FinanceInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["FinanceID"].ToString()!="")
				{
					model.FinanceID=int.Parse(ds.Tables[0].Rows[0]["FinanceID"].ToString());
				}
																																				model.Company= ds.Tables[0].Rows[0]["Company"].ToString();
																																model.JLCode= ds.Tables[0].Rows[0]["JLCode"].ToString();
																												if(ds.Tables[0].Rows[0]["DPrice"].ToString()!="")
				{
					model.DPrice=decimal.Parse(ds.Tables[0].Rows[0]["DPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SJPrice"].ToString()!="")
				{
					model.SJPrice=decimal.Parse(ds.Tables[0].Rows[0]["SJPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SHPrice"].ToString()!="")
				{
					model.SHPrice=decimal.Parse(ds.Tables[0].Rows[0]["SHPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SSPrice"].ToString()!="")
				{
					model.SSPrice=decimal.Parse(ds.Tables[0].Rows[0]["SSPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LRPrice"].ToString()!="")
				{
					model.LRPrice=decimal.Parse(ds.Tables[0].Rows[0]["LRPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["XSPrice"].ToString()!="")
				{
					model.XSPrice=decimal.Parse(ds.Tables[0].Rows[0]["XSPrice"].ToString());
				}
																																				model.FDPrice= ds.Tables[0].Rows[0]["FDPrice"].ToString();
																																model.CPD= ds.Tables[0].Rows[0]["CPD"].ToString();
																												if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
																																				model.AddUser= ds.Tables[0].Rows[0]["AddUser"].ToString();
																																model.SKState= ds.Tables[0].Rows[0]["SKState"].ToString();
																																model.CPY= ds.Tables[0].Rows[0]["CPY"].ToString();
																																model.XC= ds.Tables[0].Rows[0]["XC"].ToString();
																																model.RS= ds.Tables[0].Rows[0]["RS"].ToString();
																																model.PH= ds.Tables[0].Rows[0]["PH"].ToString();
																																model.FPTT= ds.Tables[0].Rows[0]["FPTT"].ToString();
																																model.FPJE= ds.Tables[0].Rows[0]["FPJE"].ToString();
																																model.FKFS= ds.Tables[0].Rows[0]["FKFS"].ToString();
																																model.Customer= ds.Tables[0].Rows[0]["Customer"].ToString();
																																model.BZ= ds.Tables[0].Rows[0]["BZ"].ToString();
																																model.SPY= ds.Tables[0].Rows[0]["SPY"].ToString();
																																model.SPFS= ds.Tables[0].Rows[0]["SPFS"].ToString();
																																model.ZK= ds.Tables[0].Rows[0]["ZK"].ToString();
																																model.SubFKFS= ds.Tables[0].Rows[0]["SubFKFS"].ToString();
																												if(ds.Tables[0].Rows[0]["YSJE"].ToString()!="")
				{
					model.YSJE=decimal.Parse(ds.Tables[0].Rows[0]["YSJE"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["YSJE1"].ToString()!="")
				{
					model.YSJE1=decimal.Parse(ds.Tables[0].Rows[0]["YSJE1"].ToString());
				}
																																				model.FKFS1= ds.Tables[0].Rows[0]["FKFS1"].ToString();
																																model.SubFKFS1= ds.Tables[0].Rows[0]["SubFKFS1"].ToString();
																																model.SubSKState= ds.Tables[0].Rows[0]["SubSKState"].ToString();
																																model.GRYH= ds.Tables[0].Rows[0]["GRYH"].ToString();
																																model.GRYH1= ds.Tables[0].Rows[0]["GRYH1"].ToString();
																																model.FDPrice1= ds.Tables[0].Rows[0]["FDPrice1"].ToString();
																												if(ds.Tables[0].Rows[0]["YSPrice"].ToString()!="")
				{
					model.YSPrice=decimal.Parse(ds.Tables[0].Rows[0]["YSPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["FXPrice"].ToString()!="")
				{
					model.FXPrice=decimal.Parse(ds.Tables[0].Rows[0]["FXPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SJDZ"].ToString()!="")
				{
					model.SJDZ=decimal.Parse(ds.Tables[0].Rows[0]["SJDZ"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["JPQJ"].ToString()!="")
				{
					model.JPQJ=decimal.Parse(ds.Tables[0].Rows[0]["JPQJ"].ToString());
				}
																																				model.CW= ds.Tables[0].Rows[0]["CW"].ToString();
																																model.OrderCode= ds.Tables[0].Rows[0]["OrderCode"].ToString();
																												if(ds.Tables[0].Rows[0]["Jiangjin"].ToString()!="")
				{
					model.Jiangjin=decimal.Parse(ds.Tables[0].Rows[0]["Jiangjin"].ToString());
				}
																																				model.JJRY= ds.Tables[0].Rows[0]["JJRY"].ToString();
																																model.GPR= ds.Tables[0].Rows[0]["GPR"].ToString();
																																model.HBH= ds.Tables[0].Rows[0]["HBH"].ToString();
																																model.DPRQ= ds.Tables[0].Rows[0]["DPRQ"].ToString();
																												if(ds.Tables[0].Rows[0]["NewFXPrice"].ToString()!="")
				{
					model.NewFXPrice=decimal.Parse(ds.Tables[0].Rows[0]["NewFXPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SKData"].ToString()!="")
				{
					model.SKData=DateTime.Parse(ds.Tables[0].Rows[0]["SKData"].ToString());
				}
																																				model.CPDXX= ds.Tables[0].Rows[0]["CPDXX"].ToString();
																																model.BXXX= ds.Tables[0].Rows[0]["BXXX"].ToString();
																																model.FKState= ds.Tables[0].Rows[0]["FKState"].ToString();
																										
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
			strSql.Append(" FROM FinanceInfo ");
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
			strSql.Append(" FROM FinanceInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

