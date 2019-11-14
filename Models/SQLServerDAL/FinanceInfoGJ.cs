using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//FinanceInfo
		public partial class FinanceInfoGJ
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
		public int Add(ApiAirkxCompany.Model.FinanceInfoGJ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FinanceInfo(");			
            strSql.Append("Company,JLCode,DPrice,SJPrice,SHPrice,SSPrice,LRPrice,XSPrice,HXPrice,FDPrice,DPriceStr,SJPriceStr,SHPriceStr,SSPriceStr,LRPriceStr,XSPriceStr,CPD,AddTime,AddUser,SKState,CPY,XC,RS,PH,FPTT,FPJE,FKFS,Customer,BZ,SPY,SPFS,FDJE,FKSM,CPDSM,SubSKState,SJDZ,DLZH,FDOne,FDTwo,SubFK,GRYH,SYJJ,FXJE,YWF,YSJE,FKFS1,FKFS2,FKFS3,SubFK1,SubFK2,SubFK3,GRYH1,GRYH2,GRYH3,YSJE1,YSJE2,YSJE3,YWR,FKState,KPState,GNTPH,GNTPH1,GNTPH2,GNTPH3,StartDate,EndDate,YQ,PNRText,CJR,HBH,QLSJ,CWDJ,ZK,FWF");
			strSql.Append(") values (");
            strSql.Append("@Company,@JLCode,@DPrice,@SJPrice,@SHPrice,@SSPrice,@LRPrice,@XSPrice,@HXPrice,@FDPrice,@DPriceStr,@SJPriceStr,@SHPriceStr,@SSPriceStr,@LRPriceStr,@XSPriceStr,@CPD,@AddTime,@AddUser,@SKState,@CPY,@XC,@RS,@PH,@FPTT,@FPJE,@FKFS,@Customer,@BZ,@SPY,@SPFS,@FDJE,@FKSM,@CPDSM,@SubSKState,@SJDZ,@DLZH,@FDOne,@FDTwo,@SubFK,@GRYH,@SYJJ,@FXJE,@YWF,@YSJE,@FKFS1,@FKFS2,@FKFS3,@SubFK1,@SubFK2,@SubFK3,@GRYH1,@GRYH2,@GRYH3,@YSJE1,@YSJE2,@YSJE3,@YWR,@FKState,@KPState,@GNTPH,@GNTPH1,@GNTPH2,@GNTPH3,@StartDate,@EndDate,@YQ,@PNRText,@CJR,@HBH,@QLSJ,@CWDJ,@ZK,@FWF");            
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
                        new SqlParameter("@HXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SJPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SHPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LRPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@FPJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@BZ", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CPDSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("@DLZH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDOne", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDTwo", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@GRYH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SYJJ", SqlDbType.Float,8) ,            
                        new SqlParameter("@FXJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@YWF", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKFS2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKFS3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE2", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE3", SqlDbType.Float,8) ,            
                        new SqlParameter("@YWR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@KPState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StartDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@EndDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@YQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PNRText", SqlDbType.Text) ,            
                        new SqlParameter("@CJR", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@HBH", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@QLSJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CWDJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@ZK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@FWF", SqlDbType.NVarChar,-1)             
              
            };
			            
            parameters[0].Value = model.Company;                        
            parameters[1].Value = model.JLCode;                        
            parameters[2].Value = model.DPrice;                        
            parameters[3].Value = model.SJPrice;                        
            parameters[4].Value = model.SHPrice;                        
            parameters[5].Value = model.SSPrice;                        
            parameters[6].Value = model.LRPrice;                        
            parameters[7].Value = model.XSPrice;                        
            parameters[8].Value = model.HXPrice;                        
            parameters[9].Value = model.FDPrice;                        
            parameters[10].Value = model.DPriceStr;                        
            parameters[11].Value = model.SJPriceStr;                        
            parameters[12].Value = model.SHPriceStr;                        
            parameters[13].Value = model.SSPriceStr;                        
            parameters[14].Value = model.LRPriceStr;                        
            parameters[15].Value = model.XSPriceStr;                        
            parameters[16].Value = model.CPD;                        
            parameters[17].Value = model.AddTime;                        
            parameters[18].Value = model.AddUser;                        
            parameters[19].Value = model.SKState;                        
            parameters[20].Value = model.CPY;                        
            parameters[21].Value = model.XC;                        
            parameters[22].Value = model.RS;                        
            parameters[23].Value = model.PH;                        
            parameters[24].Value = model.FPTT;                        
            parameters[25].Value = model.FPJE;                        
            parameters[26].Value = model.FKFS;                        
            parameters[27].Value = model.Customer;                        
            parameters[28].Value = model.BZ;                        
            parameters[29].Value = model.SPY;                        
            parameters[30].Value = model.SPFS;                        
            parameters[31].Value = model.FDJE;                        
            parameters[32].Value = model.FKSM;                        
            parameters[33].Value = model.CPDSM;                        
            parameters[34].Value = model.SubSKState;                        
            parameters[35].Value = model.SJDZ;                        
            parameters[36].Value = model.DLZH;                        
            parameters[37].Value = model.FDOne;                        
            parameters[38].Value = model.FDTwo;                        
            parameters[39].Value = model.SubFK;                        
            parameters[40].Value = model.GRYH;                        
            parameters[41].Value = model.SYJJ;                        
            parameters[42].Value = model.FXJE;                        
            parameters[43].Value = model.YWF;                        
            parameters[44].Value = model.YSJE;                        
            parameters[45].Value = model.FKFS1;                        
            parameters[46].Value = model.FKFS2;                        
            parameters[47].Value = model.FKFS3;                        
            parameters[48].Value = model.SubFK1;                        
            parameters[49].Value = model.SubFK2;                        
            parameters[50].Value = model.SubFK3;                        
            parameters[51].Value = model.GRYH1;                        
            parameters[52].Value = model.GRYH2;                        
            parameters[53].Value = model.GRYH3;                        
            parameters[54].Value = model.YSJE1;                        
            parameters[55].Value = model.YSJE2;                        
            parameters[56].Value = model.YSJE3;                        
            parameters[57].Value = model.YWR;                           
            parameters[58].Value = model.FKState;                        
            parameters[59].Value = model.KPState;                        
            parameters[60].Value = model.GNTPH;                        
            parameters[61].Value = model.GNTPH1;                        
            parameters[62].Value = model.GNTPH2;                        
            parameters[63].Value = model.GNTPH3;                        
            parameters[64].Value = model.StartDate;                        
            parameters[65].Value = model.EndDate;                        
            parameters[66].Value = model.YQ;                        
            parameters[67].Value = model.PNRText;                        
            parameters[68].Value = model.CJR;                        
            parameters[69].Value = model.HBH;                        
            parameters[70].Value = model.QLSJ;                        
            parameters[71].Value = model.CWDJ;                        
            parameters[72].Value = model.ZK;                        
            parameters[73].Value = model.FWF;

            SqlHelperTool stool = new SqlHelperTool("gjcw");
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
		public bool Update(ApiAirkxCompany.Model.FinanceInfoGJ model)
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
            strSql.Append(" HXPrice = @HXPrice , ");                                    
            strSql.Append(" FDPrice = @FDPrice , ");                                    
            strSql.Append(" DPriceStr = @DPriceStr , ");                                    
            strSql.Append(" SJPriceStr = @SJPriceStr , ");                                    
            strSql.Append(" SHPriceStr = @SHPriceStr , ");                                    
            strSql.Append(" SSPriceStr = @SSPriceStr , ");                                    
            strSql.Append(" LRPriceStr = @LRPriceStr , ");                                    
            strSql.Append(" XSPriceStr = @XSPriceStr , ");                                    
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
            strSql.Append(" FDJE = @FDJE , ");                                    
            strSql.Append(" FKSM = @FKSM , ");                                    
            strSql.Append(" CPDSM = @CPDSM , ");                                    
            strSql.Append(" SubSKState = @SubSKState , ");                                    
            strSql.Append(" SJDZ = @SJDZ , ");                                    
            strSql.Append(" DLZH = @DLZH , ");                                    
            strSql.Append(" FDOne = @FDOne , ");                                    
            strSql.Append(" FDTwo = @FDTwo , ");                                    
            strSql.Append(" SubFK = @SubFK , ");                                    
            strSql.Append(" GRYH = @GRYH , ");                                    
            strSql.Append(" SYJJ = @SYJJ , ");                                    
            strSql.Append(" FXJE = @FXJE , ");                                    
            strSql.Append(" YWF = @YWF , ");                                    
            strSql.Append(" YSJE = @YSJE , ");                                    
            strSql.Append(" FKFS1 = @FKFS1 , ");                                    
            strSql.Append(" FKFS2 = @FKFS2 , ");                                    
            strSql.Append(" FKFS3 = @FKFS3 , ");                                    
            strSql.Append(" SubFK1 = @SubFK1 , ");                                    
            strSql.Append(" SubFK2 = @SubFK2 , ");                                    
            strSql.Append(" SubFK3 = @SubFK3 , ");                                    
            strSql.Append(" GRYH1 = @GRYH1 , ");                                    
            strSql.Append(" GRYH2 = @GRYH2 , ");                                    
            strSql.Append(" GRYH3 = @GRYH3 , ");                                    
            strSql.Append(" YSJE1 = @YSJE1 , ");                                    
            strSql.Append(" YSJE2 = @YSJE2 , ");                                    
            strSql.Append(" YSJE3 = @YSJE3 , ");                                    
            strSql.Append(" YWR = @YWR , ");                                    
            strSql.Append(" SKData = @SKData , ");                                    
            strSql.Append(" FKState = @FKState , ");                                    
            strSql.Append(" KPState = @KPState , ");                                    
            strSql.Append(" GNTPH = @GNTPH , ");                                    
            strSql.Append(" GNTPH1 = @GNTPH1 , ");                                    
            strSql.Append(" GNTPH2 = @GNTPH2 , ");                                    
            strSql.Append(" GNTPH3 = @GNTPH3 , ");                                    
            strSql.Append(" StartDate = @StartDate , ");                                    
            strSql.Append(" EndDate = @EndDate , ");                                    
            strSql.Append(" YQ = @YQ , ");                                    
            strSql.Append(" PNRText = @PNRText , ");                                    
            strSql.Append(" CJR = @CJR , ");                                    
            strSql.Append(" HBH = @HBH , ");                                    
            strSql.Append(" QLSJ = @QLSJ , ");                                    
            strSql.Append(" CWDJ = @CWDJ , ");                                    
            strSql.Append(" ZK = @ZK , ");                                    
            strSql.Append(" FWF = @FWF  ");            			
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
                        new SqlParameter("@HXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("@FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@DPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SJPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SHPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LRPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@FPTT", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@FPJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@BZ", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("@SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CPDSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("@DLZH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDOne", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FDTwo", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@GRYH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SYJJ", SqlDbType.Float,8) ,            
                        new SqlParameter("@FXJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@YWF", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("@FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKFS2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FKFS3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SubFK3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GRYH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE2", SqlDbType.Float,8) ,            
                        new SqlParameter("@YSJE3", SqlDbType.Float,8) ,            
                        new SqlParameter("@YWR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@SKData", SqlDbType.DateTime) ,            
                        new SqlParameter("@FKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@KPState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GNTPH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StartDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@EndDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@YQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PNRText", SqlDbType.Text) ,            
                        new SqlParameter("@CJR", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@HBH", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@QLSJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@CWDJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@ZK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@FWF", SqlDbType.NVarChar,-1)             
              
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
            parameters[9].Value = model.HXPrice;                        
            parameters[10].Value = model.FDPrice;                        
            parameters[11].Value = model.DPriceStr;                        
            parameters[12].Value = model.SJPriceStr;                        
            parameters[13].Value = model.SHPriceStr;                        
            parameters[14].Value = model.SSPriceStr;                        
            parameters[15].Value = model.LRPriceStr;                        
            parameters[16].Value = model.XSPriceStr;                        
            parameters[17].Value = model.CPD;                        
            parameters[18].Value = model.AddTime;                        
            parameters[19].Value = model.AddUser;                        
            parameters[20].Value = model.SKState;                        
            parameters[21].Value = model.CPY;                        
            parameters[22].Value = model.XC;                        
            parameters[23].Value = model.RS;                        
            parameters[24].Value = model.PH;                        
            parameters[25].Value = model.FPTT;                        
            parameters[26].Value = model.FPJE;                        
            parameters[27].Value = model.FKFS;                        
            parameters[28].Value = model.Customer;                        
            parameters[29].Value = model.BZ;                        
            parameters[30].Value = model.SPY;                        
            parameters[31].Value = model.SPFS;                        
            parameters[32].Value = model.FDJE;                        
            parameters[33].Value = model.FKSM;                        
            parameters[34].Value = model.CPDSM;                        
            parameters[35].Value = model.SubSKState;                        
            parameters[36].Value = model.SJDZ;                        
            parameters[37].Value = model.DLZH;                        
            parameters[38].Value = model.FDOne;                        
            parameters[39].Value = model.FDTwo;                        
            parameters[40].Value = model.SubFK;                        
            parameters[41].Value = model.GRYH;                        
            parameters[42].Value = model.SYJJ;                        
            parameters[43].Value = model.FXJE;                        
            parameters[44].Value = model.YWF;                        
            parameters[45].Value = model.YSJE;                        
            parameters[46].Value = model.FKFS1;                        
            parameters[47].Value = model.FKFS2;                        
            parameters[48].Value = model.FKFS3;                        
            parameters[49].Value = model.SubFK1;                        
            parameters[50].Value = model.SubFK2;                        
            parameters[51].Value = model.SubFK3;                        
            parameters[52].Value = model.GRYH1;                        
            parameters[53].Value = model.GRYH2;                        
            parameters[54].Value = model.GRYH3;                        
            parameters[55].Value = model.YSJE1;                        
            parameters[56].Value = model.YSJE2;                        
            parameters[57].Value = model.YSJE3;                        
            parameters[58].Value = model.YWR;                        
            parameters[59].Value = model.SKData;                        
            parameters[60].Value = model.FKState;                        
            parameters[61].Value = model.KPState;                        
            parameters[62].Value = model.GNTPH;                        
            parameters[63].Value = model.GNTPH1;                        
            parameters[64].Value = model.GNTPH2;                        
            parameters[65].Value = model.GNTPH3;                        
            parameters[66].Value = model.StartDate;                        
            parameters[67].Value = model.EndDate;                        
            parameters[68].Value = model.YQ;                        
            parameters[69].Value = model.PNRText;                        
            parameters[70].Value = model.CJR;                        
            parameters[71].Value = model.HBH;                        
            parameters[72].Value = model.QLSJ;                        
            parameters[73].Value = model.CWDJ;                        
            parameters[74].Value = model.ZK;                        
            parameters[75].Value = model.FWF;                        
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
		public ApiAirkxCompany.Model.FinanceInfoGJ GetModel(int FinanceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FinanceID, Company, JLCode, DPrice, SJPrice, SHPrice, SSPrice, LRPrice, XSPrice, HXPrice, FDPrice, DPriceStr, SJPriceStr, SHPriceStr, SSPriceStr, LRPriceStr, XSPriceStr, CPD, AddTime, AddUser, SKState, CPY, XC, RS, PH, FPTT, FPJE, FKFS, Customer, BZ, SPY, SPFS, FDJE, FKSM, CPDSM, SubSKState, SJDZ, DLZH, FDOne, FDTwo, SubFK, GRYH, SYJJ, FXJE, YWF, YSJE, FKFS1, FKFS2, FKFS3, SubFK1, SubFK2, SubFK3, GRYH1, GRYH2, GRYH3, YSJE1, YSJE2, YSJE3, YWR, SKData, FKState, KPState, GNTPH, GNTPH1, GNTPH2, GNTPH3, StartDate, EndDate, YQ, PNRText, CJR, HBH, QLSJ, CWDJ, ZK, FWF  ");			
			strSql.Append("  from FinanceInfo ");
			strSql.Append(" where FinanceID=@FinanceID");
						SqlParameter[] parameters = {
					new SqlParameter("@FinanceID", SqlDbType.Int,4)
			};
			parameters[0].Value = FinanceID;

			
			ApiAirkxCompany.Model.FinanceInfoGJ model=new ApiAirkxCompany.Model.FinanceInfoGJ();
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
																																if(ds.Tables[0].Rows[0]["HXPrice"].ToString()!="")
				{
					model.HXPrice=decimal.Parse(ds.Tables[0].Rows[0]["HXPrice"].ToString());
				}
																																				model.FDPrice= ds.Tables[0].Rows[0]["FDPrice"].ToString();
																																model.DPriceStr= ds.Tables[0].Rows[0]["DPriceStr"].ToString();
																																model.SJPriceStr= ds.Tables[0].Rows[0]["SJPriceStr"].ToString();
																																model.SHPriceStr= ds.Tables[0].Rows[0]["SHPriceStr"].ToString();
																																model.SSPriceStr= ds.Tables[0].Rows[0]["SSPriceStr"].ToString();
																																model.LRPriceStr= ds.Tables[0].Rows[0]["LRPriceStr"].ToString();
																																model.XSPriceStr= ds.Tables[0].Rows[0]["XSPriceStr"].ToString();
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
																												if(ds.Tables[0].Rows[0]["FPJE"].ToString()!="")
				{
					model.FPJE=decimal.Parse(ds.Tables[0].Rows[0]["FPJE"].ToString());
				}
																																				model.FKFS= ds.Tables[0].Rows[0]["FKFS"].ToString();
																																model.Customer= ds.Tables[0].Rows[0]["Customer"].ToString();
																																model.BZ= ds.Tables[0].Rows[0]["BZ"].ToString();
																																model.SPY= ds.Tables[0].Rows[0]["SPY"].ToString();
																																model.SPFS= ds.Tables[0].Rows[0]["SPFS"].ToString();
																												if(ds.Tables[0].Rows[0]["FDJE"].ToString()!="")
				{
					model.FDJE=decimal.Parse(ds.Tables[0].Rows[0]["FDJE"].ToString());
				}
																																				model.FKSM= ds.Tables[0].Rows[0]["FKSM"].ToString();
																																model.CPDSM= ds.Tables[0].Rows[0]["CPDSM"].ToString();
																																model.SubSKState= ds.Tables[0].Rows[0]["SubSKState"].ToString();
																												if(ds.Tables[0].Rows[0]["SJDZ"].ToString()!="")
				{
					model.SJDZ=decimal.Parse(ds.Tables[0].Rows[0]["SJDZ"].ToString());
				}
																																				model.DLZH= ds.Tables[0].Rows[0]["DLZH"].ToString();
																																model.FDOne= ds.Tables[0].Rows[0]["FDOne"].ToString();
																																model.FDTwo= ds.Tables[0].Rows[0]["FDTwo"].ToString();
																																model.SubFK= ds.Tables[0].Rows[0]["SubFK"].ToString();
																																model.GRYH= ds.Tables[0].Rows[0]["GRYH"].ToString();
																												if(ds.Tables[0].Rows[0]["SYJJ"].ToString()!="")
				{
					model.SYJJ=decimal.Parse(ds.Tables[0].Rows[0]["SYJJ"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["FXJE"].ToString()!="")
				{
					model.FXJE=decimal.Parse(ds.Tables[0].Rows[0]["FXJE"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["YWF"].ToString()!="")
				{
					model.YWF=decimal.Parse(ds.Tables[0].Rows[0]["YWF"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["YSJE"].ToString()!="")
				{
					model.YSJE=decimal.Parse(ds.Tables[0].Rows[0]["YSJE"].ToString());
				}
																																				model.FKFS1= ds.Tables[0].Rows[0]["FKFS1"].ToString();
																																model.FKFS2= ds.Tables[0].Rows[0]["FKFS2"].ToString();
																																model.FKFS3= ds.Tables[0].Rows[0]["FKFS3"].ToString();
																																model.SubFK1= ds.Tables[0].Rows[0]["SubFK1"].ToString();
																																model.SubFK2= ds.Tables[0].Rows[0]["SubFK2"].ToString();
																																model.SubFK3= ds.Tables[0].Rows[0]["SubFK3"].ToString();
																																model.GRYH1= ds.Tables[0].Rows[0]["GRYH1"].ToString();
																																model.GRYH2= ds.Tables[0].Rows[0]["GRYH2"].ToString();
																																model.GRYH3= ds.Tables[0].Rows[0]["GRYH3"].ToString();
																												if(ds.Tables[0].Rows[0]["YSJE1"].ToString()!="")
				{
					model.YSJE1=decimal.Parse(ds.Tables[0].Rows[0]["YSJE1"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["YSJE2"].ToString()!="")
				{
					model.YSJE2=decimal.Parse(ds.Tables[0].Rows[0]["YSJE2"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["YSJE3"].ToString()!="")
				{
					model.YSJE3=decimal.Parse(ds.Tables[0].Rows[0]["YSJE3"].ToString());
				}
																																				model.YWR= ds.Tables[0].Rows[0]["YWR"].ToString();
																												if(ds.Tables[0].Rows[0]["SKData"].ToString()!="")
				{
					model.SKData=DateTime.Parse(ds.Tables[0].Rows[0]["SKData"].ToString());
				}
																																				model.FKState= ds.Tables[0].Rows[0]["FKState"].ToString();
																																model.KPState= ds.Tables[0].Rows[0]["KPState"].ToString();
																																model.GNTPH= ds.Tables[0].Rows[0]["GNTPH"].ToString();
																																model.GNTPH1= ds.Tables[0].Rows[0]["GNTPH1"].ToString();
																																model.GNTPH2= ds.Tables[0].Rows[0]["GNTPH2"].ToString();
																																model.GNTPH3= ds.Tables[0].Rows[0]["GNTPH3"].ToString();
																												if(ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
																																				model.YQ= ds.Tables[0].Rows[0]["YQ"].ToString();
																																model.PNRText= ds.Tables[0].Rows[0]["PNRText"].ToString();
																																model.CJR= ds.Tables[0].Rows[0]["CJR"].ToString();
																																model.HBH= ds.Tables[0].Rows[0]["HBH"].ToString();
																																model.QLSJ= ds.Tables[0].Rows[0]["QLSJ"].ToString();
																																model.CWDJ= ds.Tables[0].Rows[0]["CWDJ"].ToString();
																																model.ZK= ds.Tables[0].Rows[0]["ZK"].ToString();
																																model.FWF= ds.Tables[0].Rows[0]["FWF"].ToString();
																										
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

