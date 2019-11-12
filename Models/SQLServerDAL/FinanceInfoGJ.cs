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
			                                       strSql.Append(" FinanceID = SQL2012FinanceID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("SQL2012FinanceID", SqlDbType.Int,4)
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
            strSql.Append("Company,JLCode,DPrice,SJPrice,SHPrice,SSPrice,LRPrice,XSPrice,HXPrice,FDPrice,DPriceStr,SJPriceStr,SHPriceStr,SSPriceStr,LRPriceStr,XSPriceStr,CPD,AddTime,AddUser,SKState,CPY,XC,RS,PH,FPTT,FPJE,FKFS,Customer,BZ,SPY,SPFS,FDJE,FKSM,CPDSM,SubSKState,SJDZ,DLZH,FDOne,FDTwo,SubFK,GRYH,SYJJ,FXJE,YWF,YSJE,FKFS1,FKFS2,FKFS3,SubFK1,SubFK2,SubFK3,GRYH1,GRYH2,GRYH3,YSJE1,YSJE2,YSJE3,YWR,SKData,FKState,KPState,GNTPH,GNTPH1,GNTPH2,GNTPH3,StartDate,EndDate,YQ,PNRText,CJR,HBH,QLSJ,CWDJ,ZK,FWF");
			strSql.Append(") values (");
            strSql.Append("SQL2012Company,SQL2012JLCode,SQL2012DPrice,SQL2012SJPrice,SQL2012SHPrice,SQL2012SSPrice,SQL2012LRPrice,SQL2012XSPrice,SQL2012HXPrice,SQL2012FDPrice,SQL2012DPriceStr,SQL2012SJPriceStr,SQL2012SHPriceStr,SQL2012SSPriceStr,SQL2012LRPriceStr,SQL2012XSPriceStr,SQL2012CPD,SQL2012AddTime,SQL2012AddUser,SQL2012SKState,SQL2012CPY,SQL2012XC,SQL2012RS,SQL2012PH,SQL2012FPTT,SQL2012FPJE,SQL2012FKFS,SQL2012Customer,SQL2012BZ,SQL2012SPY,SQL2012SPFS,SQL2012FDJE,SQL2012FKSM,SQL2012CPDSM,SQL2012SubSKState,SQL2012SJDZ,SQL2012DLZH,SQL2012FDOne,SQL2012FDTwo,SQL2012SubFK,SQL2012GRYH,SQL2012SYJJ,SQL2012FXJE,SQL2012YWF,SQL2012YSJE,SQL2012FKFS1,SQL2012FKFS2,SQL2012FKFS3,SQL2012SubFK1,SQL2012SubFK2,SQL2012SubFK3,SQL2012GRYH1,SQL2012GRYH2,SQL2012GRYH3,SQL2012YSJE1,SQL2012YSJE2,SQL2012YSJE3,SQL2012YWR,SQL2012SKData,SQL2012FKState,SQL2012KPState,SQL2012GNTPH,SQL2012GNTPH1,SQL2012GNTPH2,SQL2012GNTPH3,SQL2012StartDate,SQL2012EndDate,SQL2012YQ,SQL2012PNRText,SQL2012CJR,SQL2012HBH,SQL2012QLSJ,SQL2012CWDJ,SQL2012ZK,SQL2012FWF");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Company", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012JLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012DPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SJPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SHPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012LRPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012XSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012HXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012DPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SJPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SHPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012LRPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012XSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("SQL2012RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("SQL2012FPTT", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("SQL2012FPJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("SQL2012BZ", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("SQL2012SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012CPDSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("SQL2012SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012DLZH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDOne", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDTwo", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012GRYH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SYJJ", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FXJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YWF", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FKFS2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FKFS3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE2", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE3", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YWR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SKData", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012FKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("SQL2012KPState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012StartDate", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012EndDate", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012YQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012PNRText", SqlDbType.Text) ,            
                        new SqlParameter("SQL2012CJR", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012HBH", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012QLSJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012CWDJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012ZK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012FWF", SqlDbType.NVarChar,-1)             
              
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
            parameters[58].Value = model.SKData;                        
            parameters[59].Value = model.FKState;                        
            parameters[60].Value = model.KPState;                        
            parameters[61].Value = model.GNTPH;                        
            parameters[62].Value = model.GNTPH1;                        
            parameters[63].Value = model.GNTPH2;                        
            parameters[64].Value = model.GNTPH3;                        
            parameters[65].Value = model.StartDate;                        
            parameters[66].Value = model.EndDate;                        
            parameters[67].Value = model.YQ;                        
            parameters[68].Value = model.PNRText;                        
            parameters[69].Value = model.CJR;                        
            parameters[70].Value = model.HBH;                        
            parameters[71].Value = model.QLSJ;                        
            parameters[72].Value = model.CWDJ;                        
            parameters[73].Value = model.ZK;                        
            parameters[74].Value = model.FWF;

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
			                                                
            strSql.Append(" Company = SQL2012Company , ");                                    
            strSql.Append(" JLCode = SQL2012JLCode , ");                                    
            strSql.Append(" DPrice = SQL2012DPrice , ");                                    
            strSql.Append(" SJPrice = SQL2012SJPrice , ");                                    
            strSql.Append(" SHPrice = SQL2012SHPrice , ");                                    
            strSql.Append(" SSPrice = SQL2012SSPrice , ");                                    
            strSql.Append(" LRPrice = SQL2012LRPrice , ");                                    
            strSql.Append(" XSPrice = SQL2012XSPrice , ");                                    
            strSql.Append(" HXPrice = SQL2012HXPrice , ");                                    
            strSql.Append(" FDPrice = SQL2012FDPrice , ");                                    
            strSql.Append(" DPriceStr = SQL2012DPriceStr , ");                                    
            strSql.Append(" SJPriceStr = SQL2012SJPriceStr , ");                                    
            strSql.Append(" SHPriceStr = SQL2012SHPriceStr , ");                                    
            strSql.Append(" SSPriceStr = SQL2012SSPriceStr , ");                                    
            strSql.Append(" LRPriceStr = SQL2012LRPriceStr , ");                                    
            strSql.Append(" XSPriceStr = SQL2012XSPriceStr , ");                                    
            strSql.Append(" CPD = SQL2012CPD , ");                                    
            strSql.Append(" AddTime = SQL2012AddTime , ");                                    
            strSql.Append(" AddUser = SQL2012AddUser , ");                                    
            strSql.Append(" SKState = SQL2012SKState , ");                                    
            strSql.Append(" CPY = SQL2012CPY , ");                                    
            strSql.Append(" XC = SQL2012XC , ");                                    
            strSql.Append(" RS = SQL2012RS , ");                                    
            strSql.Append(" PH = SQL2012PH , ");                                    
            strSql.Append(" FPTT = SQL2012FPTT , ");                                    
            strSql.Append(" FPJE = SQL2012FPJE , ");                                    
            strSql.Append(" FKFS = SQL2012FKFS , ");                                    
            strSql.Append(" Customer = SQL2012Customer , ");                                    
            strSql.Append(" BZ = SQL2012BZ , ");                                    
            strSql.Append(" SPY = SQL2012SPY , ");                                    
            strSql.Append(" SPFS = SQL2012SPFS , ");                                    
            strSql.Append(" FDJE = SQL2012FDJE , ");                                    
            strSql.Append(" FKSM = SQL2012FKSM , ");                                    
            strSql.Append(" CPDSM = SQL2012CPDSM , ");                                    
            strSql.Append(" SubSKState = SQL2012SubSKState , ");                                    
            strSql.Append(" SJDZ = SQL2012SJDZ , ");                                    
            strSql.Append(" DLZH = SQL2012DLZH , ");                                    
            strSql.Append(" FDOne = SQL2012FDOne , ");                                    
            strSql.Append(" FDTwo = SQL2012FDTwo , ");                                    
            strSql.Append(" SubFK = SQL2012SubFK , ");                                    
            strSql.Append(" GRYH = SQL2012GRYH , ");                                    
            strSql.Append(" SYJJ = SQL2012SYJJ , ");                                    
            strSql.Append(" FXJE = SQL2012FXJE , ");                                    
            strSql.Append(" YWF = SQL2012YWF , ");                                    
            strSql.Append(" YSJE = SQL2012YSJE , ");                                    
            strSql.Append(" FKFS1 = SQL2012FKFS1 , ");                                    
            strSql.Append(" FKFS2 = SQL2012FKFS2 , ");                                    
            strSql.Append(" FKFS3 = SQL2012FKFS3 , ");                                    
            strSql.Append(" SubFK1 = SQL2012SubFK1 , ");                                    
            strSql.Append(" SubFK2 = SQL2012SubFK2 , ");                                    
            strSql.Append(" SubFK3 = SQL2012SubFK3 , ");                                    
            strSql.Append(" GRYH1 = SQL2012GRYH1 , ");                                    
            strSql.Append(" GRYH2 = SQL2012GRYH2 , ");                                    
            strSql.Append(" GRYH3 = SQL2012GRYH3 , ");                                    
            strSql.Append(" YSJE1 = SQL2012YSJE1 , ");                                    
            strSql.Append(" YSJE2 = SQL2012YSJE2 , ");                                    
            strSql.Append(" YSJE3 = SQL2012YSJE3 , ");                                    
            strSql.Append(" YWR = SQL2012YWR , ");                                    
            strSql.Append(" SKData = SQL2012SKData , ");                                    
            strSql.Append(" FKState = SQL2012FKState , ");                                    
            strSql.Append(" KPState = SQL2012KPState , ");                                    
            strSql.Append(" GNTPH = SQL2012GNTPH , ");                                    
            strSql.Append(" GNTPH1 = SQL2012GNTPH1 , ");                                    
            strSql.Append(" GNTPH2 = SQL2012GNTPH2 , ");                                    
            strSql.Append(" GNTPH3 = SQL2012GNTPH3 , ");                                    
            strSql.Append(" StartDate = SQL2012StartDate , ");                                    
            strSql.Append(" EndDate = SQL2012EndDate , ");                                    
            strSql.Append(" YQ = SQL2012YQ , ");                                    
            strSql.Append(" PNRText = SQL2012PNRText , ");                                    
            strSql.Append(" CJR = SQL2012CJR , ");                                    
            strSql.Append(" HBH = SQL2012HBH , ");                                    
            strSql.Append(" QLSJ = SQL2012QLSJ , ");                                    
            strSql.Append(" CWDJ = SQL2012CWDJ , ");                                    
            strSql.Append(" ZK = SQL2012ZK , ");                                    
            strSql.Append(" FWF = SQL2012FWF  ");            			
			strSql.Append(" where FinanceID=SQL2012FinanceID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("SQL2012FinanceID", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Company", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012JLCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012DPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SJPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SHPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012SSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012LRPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012XSPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012HXPrice", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FDPrice", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012DPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SJPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SHPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012LRPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012XSPriceStr", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012CPD", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012AddUser", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SKState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012CPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012XC", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("SQL2012RS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012PH", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("SQL2012FPTT", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("SQL2012FPJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012Customer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("SQL2012BZ", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("SQL2012SPY", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SPFS", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012CPDSM", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012SubSKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("SQL2012SJDZ", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012DLZH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDOne", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FDTwo", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012GRYH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SYJJ", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FXJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YWF", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012FKFS1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FKFS2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012FKFS3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SubFK3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GRYH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012YSJE1", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE2", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YSJE3", SqlDbType.Float,8) ,            
                        new SqlParameter("SQL2012YWR", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012SKData", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012FKState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("SQL2012KPState", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012GNTPH3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012StartDate", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012EndDate", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012YQ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("SQL2012PNRText", SqlDbType.Text) ,            
                        new SqlParameter("SQL2012CJR", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012HBH", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012QLSJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012CWDJ", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012ZK", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("SQL2012FWF", SqlDbType.NVarChar,-1)             
              
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
			strSql.Append(" where FinanceID=SQL2012FinanceID");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012FinanceID", SqlDbType.Int,4)
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
			strSql.Append(" where FinanceID=SQL2012FinanceID");
						SqlParameter[] parameters = {
					new SqlParameter("SQL2012FinanceID", SqlDbType.Int,4)
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

