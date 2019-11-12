using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.SQLServerDAL
{
	 	//T_TicketSheet
		public partial class T_TicketSheet
	{
   		     
		public bool Exists(string dcTSID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_TicketSheet");
			strSql.Append(" where ");
			                                       strSql.Append(" dcTSID = @dcTSID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@dcTSID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcTSID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ApiAirkxCompany.Model.T_TicketSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_TicketSheet(");			
            strSql.Append("dcTSID,dnFlightClass,dcAirCompanyName,dcOrderCode,dcStartCity,dcBackCity,dnSellPrice,dnReturnPoint1,dnReturnPoint2,dnReturnPoint3,dnTax,dnPersonNumber,dnYaoWeiPrice,dnHKYWID,dcLXR,dnShiShouPrice,dnReturnPrice,dnShiJiDaoZhang,dnJieSuanPrice,dnLiRun,dnDiJia,dnFandianPrice,dnHangXiePrice,dnCountPrice,dnYingShouPrice,dcOutTicketID,dcOutTicketName,dcCPDXX,dnTotalPrice,dcCompanyID,dcCompanyName,dcLinkName,dnFlightPrice,dcTicketNO,dcOrderID,dnServicePrice,dnSafePrice,dcStartDate,dnTicketPrice,dcRakedClass,dcPersonName,dcFlightNumber,dcFlightTime,dcOther,dcPaymentMethod1,dnPaymentPrice1,dcPaymentMethod2,dnPaymentPrice2,dcPaymentMethod3,dnPaymentPrice3,dcPaymentMethod4,dnPaymentPrice4,dnStatus,dnBonus,dnDiscount,dcSendTicketType,dcSendTicketerName,dcAddUser,dtAddTime");
			strSql.Append(") values (");
            strSql.Append("@dcTSID,@dnFlightClass,@dcAirCompanyName,@dcOrderCode,@dcStartCity,@dcBackCity,@dnSellPrice,@dnReturnPoint1,@dnReturnPoint2,@dnReturnPoint3,@dnTax,@dnPersonNumber,@dnYaoWeiPrice,@dnHKYWID,@dcLXR,@dnShiShouPrice,@dnReturnPrice,@dnShiJiDaoZhang,@dnJieSuanPrice,@dnLiRun,@dnDiJia,@dnFandianPrice,@dnHangXiePrice,@dnCountPrice,@dnYingShouPrice,@dcOutTicketID,@dcOutTicketName,@dcCPDXX,@dnTotalPrice,@dcCompanyID,@dcCompanyName,@dcLinkName,@dnFlightPrice,@dcTicketNO,@dcOrderID,@dnServicePrice,@dnSafePrice,@dcStartDate,@dnTicketPrice,@dcRakedClass,@dcPersonName,@dcFlightNumber,@dcFlightTime,@dcOther,@dcPaymentMethod1,@dnPaymentPrice1,@dcPaymentMethod2,@dnPaymentPrice2,@dcPaymentMethod3,@dnPaymentPrice3,@dcPaymentMethod4,@dnPaymentPrice4,@dnStatus,@dnBonus,@dnDiscount,@dcSendTicketType,@dcSendTicketerName,@dcAddUser,@dtAddTime");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@dcTSID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnFlightClass", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAirCompanyName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dnSellPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint1", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint2", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnPersonNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnYaoWeiPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnHKYWID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcLXR", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnShiShouPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnShiJiDaoZhang", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnJieSuanPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnLiRun", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnDiJia", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnFandianPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnHangXiePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnCountPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnYingShouPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcOutTicketID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOutTicketName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcCPDXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnFlightPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcTicketNO", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dnTicketPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcRakedClass", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPersonName", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@dcFlightNumber", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcFlightTime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcOther", SqlDbType.Text) ,            
                        new SqlParameter("@dcPaymentMethod1", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice1", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod2", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice2", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod3", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod4", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice4", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnDiscount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcSendTicketType", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcSendTicketerName", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcAddUser", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime)             
              
            };
			            
            parameters[0].Value = model.dcTSID;                        
            parameters[1].Value = model.dnFlightClass;                        
            parameters[2].Value = model.dcAirCompanyName;                        
            parameters[3].Value = model.dcOrderCode;                        
            parameters[4].Value = model.dcStartCity;                        
            parameters[5].Value = model.dcBackCity;                        
            parameters[6].Value = model.dnSellPrice;                        
            parameters[7].Value = model.dnReturnPoint1;                        
            parameters[8].Value = model.dnReturnPoint2;                        
            parameters[9].Value = model.dnReturnPoint3;                        
            parameters[10].Value = model.dnTax;                        
            parameters[11].Value = model.dnPersonNumber;                        
            parameters[12].Value = model.dnYaoWeiPrice;                        
            parameters[13].Value = model.dnHKYWID;                        
            parameters[14].Value = model.dcLXR;                        
            parameters[15].Value = model.dnShiShouPrice;                        
            parameters[16].Value = model.dnReturnPrice;                        
            parameters[17].Value = model.dnShiJiDaoZhang;                        
            parameters[18].Value = model.dnJieSuanPrice;                        
            parameters[19].Value = model.dnLiRun;                        
            parameters[20].Value = model.dnDiJia;                        
            parameters[21].Value = model.dnFandianPrice;                        
            parameters[22].Value = model.dnHangXiePrice;                        
            parameters[23].Value = model.dnCountPrice;                        
            parameters[24].Value = model.dnYingShouPrice;                        
            parameters[25].Value = model.dcOutTicketID;                        
            parameters[26].Value = model.dcOutTicketName;                        
            parameters[27].Value = model.dcCPDXX;                        
            parameters[28].Value = model.dnTotalPrice;                        
            parameters[29].Value = model.dcCompanyID;                        
            parameters[30].Value = model.dcCompanyName;                        
            parameters[31].Value = model.dcLinkName;                        
            parameters[32].Value = model.dnFlightPrice;                        
            parameters[33].Value = model.dcTicketNO;                        
            parameters[34].Value = model.dcOrderID;                        
            parameters[35].Value = model.dnServicePrice;                        
            parameters[36].Value = model.dnSafePrice;                        
            parameters[37].Value = model.dcStartDate;                        
            parameters[38].Value = model.dnTicketPrice;                        
            parameters[39].Value = model.dcRakedClass;                        
            parameters[40].Value = model.dcPersonName;                        
            parameters[41].Value = model.dcFlightNumber;                        
            parameters[42].Value = model.dcFlightTime;                        
            parameters[43].Value = model.dcOther;                        
            parameters[44].Value = model.dcPaymentMethod1;                        
            parameters[45].Value = model.dnPaymentPrice1;                        
            parameters[46].Value = model.dcPaymentMethod2;                        
            parameters[47].Value = model.dnPaymentPrice2;                        
            parameters[48].Value = model.dcPaymentMethod3;                        
            parameters[49].Value = model.dnPaymentPrice3;                        
            parameters[50].Value = model.dcPaymentMethod4;                        
            parameters[51].Value = model.dnPaymentPrice4;                        
            parameters[52].Value = model.dnStatus;                        
            parameters[53].Value = model.dnBonus;                        
            parameters[54].Value = model.dnDiscount;                        
            parameters[55].Value = model.dcSendTicketType;                        
            parameters[56].Value = model.dcSendTicketerName;                        
            parameters[57].Value = model.dcAddUser;                        
            parameters[58].Value = model.dtAddTime;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_TicketSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_TicketSheet set ");
			                        
            strSql.Append(" dcTSID = @dcTSID , ");                                    
            strSql.Append(" dnFlightClass = @dnFlightClass , ");                                    
            strSql.Append(" dcAirCompanyName = @dcAirCompanyName , ");                                    
            strSql.Append(" dcOrderCode = @dcOrderCode , ");                                    
            strSql.Append(" dcStartCity = @dcStartCity , ");                                    
            strSql.Append(" dcBackCity = @dcBackCity , ");                                    
            strSql.Append(" dnSellPrice = @dnSellPrice , ");                                    
            strSql.Append(" dnReturnPoint1 = @dnReturnPoint1 , ");                                    
            strSql.Append(" dnReturnPoint2 = @dnReturnPoint2 , ");                                    
            strSql.Append(" dnReturnPoint3 = @dnReturnPoint3 , ");                                    
            strSql.Append(" dnTax = @dnTax , ");                                    
            strSql.Append(" dnPersonNumber = @dnPersonNumber , ");                                    
            strSql.Append(" dnYaoWeiPrice = @dnYaoWeiPrice , ");                                    
            strSql.Append(" dnHKYWID = @dnHKYWID , ");                                    
            strSql.Append(" dcLXR = @dcLXR , ");                                    
            strSql.Append(" dnShiShouPrice = @dnShiShouPrice , ");                                    
            strSql.Append(" dnReturnPrice = @dnReturnPrice , ");                                    
            strSql.Append(" dnShiJiDaoZhang = @dnShiJiDaoZhang , ");                                    
            strSql.Append(" dnJieSuanPrice = @dnJieSuanPrice , ");                                    
            strSql.Append(" dnLiRun = @dnLiRun , ");                                    
            strSql.Append(" dnDiJia = @dnDiJia , ");                                    
            strSql.Append(" dnFandianPrice = @dnFandianPrice , ");                                    
            strSql.Append(" dnHangXiePrice = @dnHangXiePrice , ");                                    
            strSql.Append(" dnCountPrice = @dnCountPrice , ");                                    
            strSql.Append(" dnYingShouPrice = @dnYingShouPrice , ");                                    
            strSql.Append(" dcOutTicketID = @dcOutTicketID , ");                                    
            strSql.Append(" dcOutTicketName = @dcOutTicketName , ");                                    
            strSql.Append(" dcCPDXX = @dcCPDXX , ");                                    
            strSql.Append(" dnTotalPrice = @dnTotalPrice , ");                                    
            strSql.Append(" dcCompanyID = @dcCompanyID , ");                                    
            strSql.Append(" dcCompanyName = @dcCompanyName , ");                                    
            strSql.Append(" dcLinkName = @dcLinkName , ");                                    
            strSql.Append(" dnFlightPrice = @dnFlightPrice , ");                                    
            strSql.Append(" dcTicketNO = @dcTicketNO , ");                                    
            strSql.Append(" dcOrderID = @dcOrderID , ");                                    
            strSql.Append(" dnServicePrice = @dnServicePrice , ");                                    
            strSql.Append(" dnSafePrice = @dnSafePrice , ");                                    
            strSql.Append(" dcStartDate = @dcStartDate , ");                                    
            strSql.Append(" dnTicketPrice = @dnTicketPrice , ");                                    
            strSql.Append(" dcRakedClass = @dcRakedClass , ");                                    
            strSql.Append(" dcPersonName = @dcPersonName , ");                                    
            strSql.Append(" dcFlightNumber = @dcFlightNumber , ");                                    
            strSql.Append(" dcFlightTime = @dcFlightTime , ");                                    
            strSql.Append(" dcOther = @dcOther , ");                                    
            strSql.Append(" dcPaymentMethod1 = @dcPaymentMethod1 , ");                                    
            strSql.Append(" dnPaymentPrice1 = @dnPaymentPrice1 , ");                                    
            strSql.Append(" dcPaymentMethod2 = @dcPaymentMethod2 , ");                                    
            strSql.Append(" dnPaymentPrice2 = @dnPaymentPrice2 , ");                                    
            strSql.Append(" dcPaymentMethod3 = @dcPaymentMethod3 , ");                                    
            strSql.Append(" dnPaymentPrice3 = @dnPaymentPrice3 , ");                                    
            strSql.Append(" dcPaymentMethod4 = @dcPaymentMethod4 , ");                                    
            strSql.Append(" dnPaymentPrice4 = @dnPaymentPrice4 , ");                                    
            strSql.Append(" dnStatus = @dnStatus , ");                                    
            strSql.Append(" dnBonus = @dnBonus , ");                                    
            strSql.Append(" dnDiscount = @dnDiscount , ");                                    
            strSql.Append(" dcSendTicketType = @dcSendTicketType , ");                                    
            strSql.Append(" dcSendTicketerName = @dcSendTicketerName , ");                                    
            strSql.Append(" dcAddUser = @dcAddUser , ");                                    
            strSql.Append(" dtAddTime = @dtAddTime  ");            			
			strSql.Append(" where dcTSID=@dcTSID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@dcTSID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnFlightClass", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcAirCompanyName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcOrderCode", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcStartCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dcBackCity", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@dnSellPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint1", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint2", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPoint3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnTax", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnPersonNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnYaoWeiPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnHKYWID", SqlDbType.Int,4) ,            
                        new SqlParameter("@dcLXR", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnShiShouPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnReturnPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnShiJiDaoZhang", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnJieSuanPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnLiRun", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnDiJia", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnFandianPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnHangXiePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnCountPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnYingShouPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcOutTicketID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcOutTicketName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcCPDXX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@dnTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dcCompanyName", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@dcLinkName", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnFlightPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcTicketNO", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@dcOrderID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@dnServicePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnSafePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcStartDate", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dnTicketPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcRakedClass", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dcPersonName", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@dcFlightNumber", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcFlightTime", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dcOther", SqlDbType.Text) ,            
                        new SqlParameter("@dcPaymentMethod1", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice1", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod2", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice2", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod3", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcPaymentMethod4", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dnPaymentPrice4", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dnStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@dnDiscount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dcSendTicketType", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcSendTicketerName", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@dcAddUser", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@dtAddTime", SqlDbType.SmallDateTime)             
              
            };
						            
            parameters[0].Value = model.dcTSID;                        
            parameters[1].Value = model.dnFlightClass;                        
            parameters[2].Value = model.dcAirCompanyName;                        
            parameters[3].Value = model.dcOrderCode;                        
            parameters[4].Value = model.dcStartCity;                        
            parameters[5].Value = model.dcBackCity;                        
            parameters[6].Value = model.dnSellPrice;                        
            parameters[7].Value = model.dnReturnPoint1;                        
            parameters[8].Value = model.dnReturnPoint2;                        
            parameters[9].Value = model.dnReturnPoint3;                        
            parameters[10].Value = model.dnTax;                        
            parameters[11].Value = model.dnPersonNumber;                        
            parameters[12].Value = model.dnYaoWeiPrice;                        
            parameters[13].Value = model.dnHKYWID;                        
            parameters[14].Value = model.dcLXR;                        
            parameters[15].Value = model.dnShiShouPrice;                        
            parameters[16].Value = model.dnReturnPrice;                        
            parameters[17].Value = model.dnShiJiDaoZhang;                        
            parameters[18].Value = model.dnJieSuanPrice;                        
            parameters[19].Value = model.dnLiRun;                        
            parameters[20].Value = model.dnDiJia;                        
            parameters[21].Value = model.dnFandianPrice;                        
            parameters[22].Value = model.dnHangXiePrice;                        
            parameters[23].Value = model.dnCountPrice;                        
            parameters[24].Value = model.dnYingShouPrice;                        
            parameters[25].Value = model.dcOutTicketID;                        
            parameters[26].Value = model.dcOutTicketName;                        
            parameters[27].Value = model.dcCPDXX;                        
            parameters[28].Value = model.dnTotalPrice;                        
            parameters[29].Value = model.dcCompanyID;                        
            parameters[30].Value = model.dcCompanyName;                        
            parameters[31].Value = model.dcLinkName;                        
            parameters[32].Value = model.dnFlightPrice;                        
            parameters[33].Value = model.dcTicketNO;                        
            parameters[34].Value = model.dcOrderID;                        
            parameters[35].Value = model.dnServicePrice;                        
            parameters[36].Value = model.dnSafePrice;                        
            parameters[37].Value = model.dcStartDate;                        
            parameters[38].Value = model.dnTicketPrice;                        
            parameters[39].Value = model.dcRakedClass;                        
            parameters[40].Value = model.dcPersonName;                        
            parameters[41].Value = model.dcFlightNumber;                        
            parameters[42].Value = model.dcFlightTime;                        
            parameters[43].Value = model.dcOther;                        
            parameters[44].Value = model.dcPaymentMethod1;                        
            parameters[45].Value = model.dnPaymentPrice1;                        
            parameters[46].Value = model.dcPaymentMethod2;                        
            parameters[47].Value = model.dnPaymentPrice2;                        
            parameters[48].Value = model.dcPaymentMethod3;                        
            parameters[49].Value = model.dnPaymentPrice3;                        
            parameters[50].Value = model.dcPaymentMethod4;                        
            parameters[51].Value = model.dnPaymentPrice4;                        
            parameters[52].Value = model.dnStatus;                        
            parameters[53].Value = model.dnBonus;                        
            parameters[54].Value = model.dnDiscount;                        
            parameters[55].Value = model.dcSendTicketType;                        
            parameters[56].Value = model.dcSendTicketerName;                        
            parameters[57].Value = model.dcAddUser;                        
            parameters[58].Value = model.dtAddTime;                        
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
		public bool Delete(string dcTSID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_TicketSheet ");
			strSql.Append(" where dcTSID=@dcTSID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcTSID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcTSID;


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
		public ApiAirkxCompany.Model.T_TicketSheet GetModel(string dcTSID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select dcTSID, dnFlightClass, dcAirCompanyName, dcOrderCode, dcStartCity, dcBackCity, dnSellPrice, dnReturnPoint1, dnReturnPoint2, dnReturnPoint3, dnTax, dnPersonNumber, dnYaoWeiPrice, dnHKYWID, dcLXR, dnShiShouPrice, dnReturnPrice, dnShiJiDaoZhang, dnJieSuanPrice, dnLiRun, dnDiJia, dnFandianPrice, dnHangXiePrice, dnCountPrice, dnYingShouPrice, dcOutTicketID, dcOutTicketName, dcCPDXX, dnTotalPrice, dcCompanyID, dcCompanyName, dcLinkName, dnFlightPrice, dcTicketNO, dcOrderID, dnServicePrice, dnSafePrice, dcStartDate, dnTicketPrice, dcRakedClass, dcPersonName, dcFlightNumber, dcFlightTime, dcOther, dcPaymentMethod1, dnPaymentPrice1, dcPaymentMethod2, dnPaymentPrice2, dcPaymentMethod3, dnPaymentPrice3, dcPaymentMethod4, dnPaymentPrice4, dnStatus, dnBonus, dnDiscount, dcSendTicketType, dcSendTicketerName, dcAddUser, dtAddTime  ");			
			strSql.Append("  from T_TicketSheet ");
			strSql.Append(" where dcTSID=@dcTSID ");
						SqlParameter[] parameters = {
					new SqlParameter("@dcTSID", SqlDbType.VarChar,40)			};
			parameters[0].Value = dcTSID;

			
			ApiAirkxCompany.Model.T_TicketSheet model=new ApiAirkxCompany.Model.T_TicketSheet();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.dcTSID= ds.Tables[0].Rows[0]["dcTSID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnFlightClass"].ToString()!="")
				{
					model.dnFlightClass=int.Parse(ds.Tables[0].Rows[0]["dnFlightClass"].ToString());
				}
																																				model.dcAirCompanyName= ds.Tables[0].Rows[0]["dcAirCompanyName"].ToString();
																																model.dcOrderCode= ds.Tables[0].Rows[0]["dcOrderCode"].ToString();
																																model.dcStartCity= ds.Tables[0].Rows[0]["dcStartCity"].ToString();
																																model.dcBackCity= ds.Tables[0].Rows[0]["dcBackCity"].ToString();
																												if(ds.Tables[0].Rows[0]["dnSellPrice"].ToString()!="")
				{
					model.dnSellPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnSellPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnReturnPoint1"].ToString()!="")
				{
					model.dnReturnPoint1=decimal.Parse(ds.Tables[0].Rows[0]["dnReturnPoint1"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnReturnPoint2"].ToString()!="")
				{
					model.dnReturnPoint2=decimal.Parse(ds.Tables[0].Rows[0]["dnReturnPoint2"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnReturnPoint3"].ToString()!="")
				{
					model.dnReturnPoint3=decimal.Parse(ds.Tables[0].Rows[0]["dnReturnPoint3"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnTax"].ToString()!="")
				{
					model.dnTax=decimal.Parse(ds.Tables[0].Rows[0]["dnTax"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnPersonNumber"].ToString()!="")
				{
					model.dnPersonNumber=int.Parse(ds.Tables[0].Rows[0]["dnPersonNumber"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnYaoWeiPrice"].ToString()!="")
				{
					model.dnYaoWeiPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnYaoWeiPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnHKYWID"].ToString()!="")
				{
					model.dnHKYWID=int.Parse(ds.Tables[0].Rows[0]["dnHKYWID"].ToString());
				}
																																				model.dcLXR= ds.Tables[0].Rows[0]["dcLXR"].ToString();
																												if(ds.Tables[0].Rows[0]["dnShiShouPrice"].ToString()!="")
				{
					model.dnShiShouPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnShiShouPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnReturnPrice"].ToString()!="")
				{
					model.dnReturnPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnReturnPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnShiJiDaoZhang"].ToString()!="")
				{
					model.dnShiJiDaoZhang=decimal.Parse(ds.Tables[0].Rows[0]["dnShiJiDaoZhang"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnJieSuanPrice"].ToString()!="")
				{
					model.dnJieSuanPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnJieSuanPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnLiRun"].ToString()!="")
				{
					model.dnLiRun=decimal.Parse(ds.Tables[0].Rows[0]["dnLiRun"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnDiJia"].ToString()!="")
				{
					model.dnDiJia=decimal.Parse(ds.Tables[0].Rows[0]["dnDiJia"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnFandianPrice"].ToString()!="")
				{
					model.dnFandianPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnFandianPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnHangXiePrice"].ToString()!="")
				{
					model.dnHangXiePrice=decimal.Parse(ds.Tables[0].Rows[0]["dnHangXiePrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnCountPrice"].ToString()!="")
				{
					model.dnCountPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnCountPrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnYingShouPrice"].ToString()!="")
				{
					model.dnYingShouPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnYingShouPrice"].ToString());
				}
																																				model.dcOutTicketID= ds.Tables[0].Rows[0]["dcOutTicketID"].ToString();
																																model.dcOutTicketName= ds.Tables[0].Rows[0]["dcOutTicketName"].ToString();
																																model.dcCPDXX= ds.Tables[0].Rows[0]["dcCPDXX"].ToString();
																												if(ds.Tables[0].Rows[0]["dnTotalPrice"].ToString()!="")
				{
					model.dnTotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnTotalPrice"].ToString());
				}
																																				model.dcCompanyID= ds.Tables[0].Rows[0]["dcCompanyID"].ToString();
																																model.dcCompanyName= ds.Tables[0].Rows[0]["dcCompanyName"].ToString();
																																model.dcLinkName= ds.Tables[0].Rows[0]["dcLinkName"].ToString();
																												if(ds.Tables[0].Rows[0]["dnFlightPrice"].ToString()!="")
				{
					model.dnFlightPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnFlightPrice"].ToString());
				}
																																				model.dcTicketNO= ds.Tables[0].Rows[0]["dcTicketNO"].ToString();
																																model.dcOrderID= ds.Tables[0].Rows[0]["dcOrderID"].ToString();
																												if(ds.Tables[0].Rows[0]["dnServicePrice"].ToString()!="")
				{
					model.dnServicePrice=decimal.Parse(ds.Tables[0].Rows[0]["dnServicePrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnSafePrice"].ToString()!="")
				{
					model.dnSafePrice=decimal.Parse(ds.Tables[0].Rows[0]["dnSafePrice"].ToString());
				}
																																				model.dcStartDate= ds.Tables[0].Rows[0]["dcStartDate"].ToString();
																												if(ds.Tables[0].Rows[0]["dnTicketPrice"].ToString()!="")
				{
					model.dnTicketPrice=decimal.Parse(ds.Tables[0].Rows[0]["dnTicketPrice"].ToString());
				}
																																				model.dcRakedClass= ds.Tables[0].Rows[0]["dcRakedClass"].ToString();
																																model.dcPersonName= ds.Tables[0].Rows[0]["dcPersonName"].ToString();
																																model.dcFlightNumber= ds.Tables[0].Rows[0]["dcFlightNumber"].ToString();
																																model.dcFlightTime= ds.Tables[0].Rows[0]["dcFlightTime"].ToString();
																																model.dcOther= ds.Tables[0].Rows[0]["dcOther"].ToString();
																																model.dcPaymentMethod1= ds.Tables[0].Rows[0]["dcPaymentMethod1"].ToString();
																												if(ds.Tables[0].Rows[0]["dnPaymentPrice1"].ToString()!="")
				{
					model.dnPaymentPrice1=decimal.Parse(ds.Tables[0].Rows[0]["dnPaymentPrice1"].ToString());
				}
																																				model.dcPaymentMethod2= ds.Tables[0].Rows[0]["dcPaymentMethod2"].ToString();
																												if(ds.Tables[0].Rows[0]["dnPaymentPrice2"].ToString()!="")
				{
					model.dnPaymentPrice2=decimal.Parse(ds.Tables[0].Rows[0]["dnPaymentPrice2"].ToString());
				}
																																				model.dcPaymentMethod3= ds.Tables[0].Rows[0]["dcPaymentMethod3"].ToString();
																												if(ds.Tables[0].Rows[0]["dnPaymentPrice3"].ToString()!="")
				{
					model.dnPaymentPrice3=decimal.Parse(ds.Tables[0].Rows[0]["dnPaymentPrice3"].ToString());
				}
																																				model.dcPaymentMethod4= ds.Tables[0].Rows[0]["dcPaymentMethod4"].ToString();
																												if(ds.Tables[0].Rows[0]["dnPaymentPrice4"].ToString()!="")
				{
					model.dnPaymentPrice4=decimal.Parse(ds.Tables[0].Rows[0]["dnPaymentPrice4"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(ds.Tables[0].Rows[0]["dnStatus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnBonus"].ToString()!="")
				{
					model.dnBonus=int.Parse(ds.Tables[0].Rows[0]["dnBonus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["dnDiscount"].ToString()!="")
				{
					model.dnDiscount=decimal.Parse(ds.Tables[0].Rows[0]["dnDiscount"].ToString());
				}
																																				model.dcSendTicketType= ds.Tables[0].Rows[0]["dcSendTicketType"].ToString();
																																model.dcSendTicketerName= ds.Tables[0].Rows[0]["dcSendTicketerName"].ToString();
																																model.dcAddUser= ds.Tables[0].Rows[0]["dcAddUser"].ToString();
																												if(ds.Tables[0].Rows[0]["dtAddTime"].ToString()!="")
				{
					model.dtAddTime=DateTime.Parse(ds.Tables[0].Rows[0]["dtAddTime"].ToString());
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
			strSql.Append(" FROM T_TicketSheet ");
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
			strSql.Append(" FROM T_TicketSheet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

