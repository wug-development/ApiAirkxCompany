using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_TicketSheet
		public partial class T_TicketSheet
	{
		private readonly SQLServerDAL.T_TicketSheet dal= new SQLServerDAL.T_TicketSheet();
		public T_TicketSheet()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcTSID)
		{
			return dal.Exists(dcTSID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_TicketSheet model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_TicketSheet model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcTSID)
		{
			
			return dal.Delete(dcTSID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_TicketSheet GetModel(string dcTSID)
		{
			
			return dal.GetModel(dcTSID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_TicketSheet> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_TicketSheet> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_TicketSheet> modelList = new List<ApiAirkxCompany.Model.T_TicketSheet>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_TicketSheet model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_TicketSheet();					
													model.dcTSID= dt.Rows[n]["dcTSID"].ToString();
																								if(dt.Rows[n]["dnFlightClass"].ToString()!="")
				{
					model.dnFlightClass=int.Parse(dt.Rows[n]["dnFlightClass"].ToString());
				}
																												model.dcAirCompanyName= dt.Rows[n]["dcAirCompanyName"].ToString();
																												model.dcOrderCode= dt.Rows[n]["dcOrderCode"].ToString();
																												model.dcStartCity= dt.Rows[n]["dcStartCity"].ToString();
																												model.dcBackCity= dt.Rows[n]["dcBackCity"].ToString();
																								if(dt.Rows[n]["dnSellPrice"].ToString()!="")
				{
					model.dnSellPrice=decimal.Parse(dt.Rows[n]["dnSellPrice"].ToString());
				}
																								if(dt.Rows[n]["dnReturnPoint1"].ToString()!="")
				{
					model.dnReturnPoint1=decimal.Parse(dt.Rows[n]["dnReturnPoint1"].ToString());
				}
																								if(dt.Rows[n]["dnReturnPoint2"].ToString()!="")
				{
					model.dnReturnPoint2=decimal.Parse(dt.Rows[n]["dnReturnPoint2"].ToString());
				}
																								if(dt.Rows[n]["dnReturnPoint3"].ToString()!="")
				{
					model.dnReturnPoint3=decimal.Parse(dt.Rows[n]["dnReturnPoint3"].ToString());
				}
																								if(dt.Rows[n]["dnTax"].ToString()!="")
				{
					model.dnTax=decimal.Parse(dt.Rows[n]["dnTax"].ToString());
				}
																								if(dt.Rows[n]["dnPersonNumber"].ToString()!="")
				{
					model.dnPersonNumber=int.Parse(dt.Rows[n]["dnPersonNumber"].ToString());
				}
																								if(dt.Rows[n]["dnYaoWeiPrice"].ToString()!="")
				{
					model.dnYaoWeiPrice=decimal.Parse(dt.Rows[n]["dnYaoWeiPrice"].ToString());
				}
																								if(dt.Rows[n]["dnHKYWID"].ToString()!="")
				{
					model.dnHKYWID=int.Parse(dt.Rows[n]["dnHKYWID"].ToString());
				}
																												model.dcLXR= dt.Rows[n]["dcLXR"].ToString();
																								if(dt.Rows[n]["dnShiShouPrice"].ToString()!="")
				{
					model.dnShiShouPrice=decimal.Parse(dt.Rows[n]["dnShiShouPrice"].ToString());
				}
																								if(dt.Rows[n]["dnReturnPrice"].ToString()!="")
				{
					model.dnReturnPrice=decimal.Parse(dt.Rows[n]["dnReturnPrice"].ToString());
				}
																								if(dt.Rows[n]["dnShiJiDaoZhang"].ToString()!="")
				{
					model.dnShiJiDaoZhang=decimal.Parse(dt.Rows[n]["dnShiJiDaoZhang"].ToString());
				}
																								if(dt.Rows[n]["dnJieSuanPrice"].ToString()!="")
				{
					model.dnJieSuanPrice=decimal.Parse(dt.Rows[n]["dnJieSuanPrice"].ToString());
				}
																								if(dt.Rows[n]["dnLiRun"].ToString()!="")
				{
					model.dnLiRun=decimal.Parse(dt.Rows[n]["dnLiRun"].ToString());
				}
																								if(dt.Rows[n]["dnDiJia"].ToString()!="")
				{
					model.dnDiJia=decimal.Parse(dt.Rows[n]["dnDiJia"].ToString());
				}
																								if(dt.Rows[n]["dnFandianPrice"].ToString()!="")
				{
					model.dnFandianPrice=decimal.Parse(dt.Rows[n]["dnFandianPrice"].ToString());
				}
																								if(dt.Rows[n]["dnHangXiePrice"].ToString()!="")
				{
					model.dnHangXiePrice=decimal.Parse(dt.Rows[n]["dnHangXiePrice"].ToString());
				}
																												model.dcOutTicketID= dt.Rows[n]["dcOutTicketID"].ToString();
																												model.dcOutTicketName= dt.Rows[n]["dcOutTicketName"].ToString();
																								if(dt.Rows[n]["dnTotalPrice"].ToString()!="")
				{
					model.dnTotalPrice=decimal.Parse(dt.Rows[n]["dnTotalPrice"].ToString());
				}
																												model.dcCompanyID= dt.Rows[n]["dcCompanyID"].ToString();
																												model.dcCompanyName= dt.Rows[n]["dcCompanyName"].ToString();
																												model.dcLinkName= dt.Rows[n]["dcLinkName"].ToString();
																								if(dt.Rows[n]["dnFlightPrice"].ToString()!="")
				{
					model.dnFlightPrice=decimal.Parse(dt.Rows[n]["dnFlightPrice"].ToString());
				}
																												model.dcTicketNO= dt.Rows[n]["dcTicketNO"].ToString();
																												model.dcOrderID= dt.Rows[n]["dcOrderID"].ToString();
																								if(dt.Rows[n]["dnServicePrice"].ToString()!="")
				{
					model.dnServicePrice=decimal.Parse(dt.Rows[n]["dnServicePrice"].ToString());
				}
																												model.dcStartDate= dt.Rows[n]["dcStartDate"].ToString();
																								if(dt.Rows[n]["dnTicketPrice"].ToString()!="")
				{
					model.dnTicketPrice=decimal.Parse(dt.Rows[n]["dnTicketPrice"].ToString());
				}
																												model.dcRakedClass= dt.Rows[n]["dcRakedClass"].ToString();
																												model.dcPersonName= dt.Rows[n]["dcPersonName"].ToString();
																												model.dcFlightNumber= dt.Rows[n]["dcFlightNumber"].ToString();
																												model.dcFlightTime= dt.Rows[n]["dcFlightTime"].ToString();
																												model.dcOther= dt.Rows[n]["dcOther"].ToString();
																												model.dcPaymentMethod1= dt.Rows[n]["dcPaymentMethod1"].ToString();
																								if(dt.Rows[n]["dnPaymentPrice1"].ToString()!="")
				{
					model.dnPaymentPrice1=decimal.Parse(dt.Rows[n]["dnPaymentPrice1"].ToString());
				}
																												model.dcPaymentMethod2= dt.Rows[n]["dcPaymentMethod2"].ToString();
																								if(dt.Rows[n]["dnPaymentPrice2"].ToString()!="")
				{
					model.dnPaymentPrice2=decimal.Parse(dt.Rows[n]["dnPaymentPrice2"].ToString());
				}
																												model.dcPaymentMethod3= dt.Rows[n]["dcPaymentMethod3"].ToString();
																								if(dt.Rows[n]["dnPaymentPrice3"].ToString()!="")
				{
					model.dnPaymentPrice3=decimal.Parse(dt.Rows[n]["dnPaymentPrice3"].ToString());
				}
																												model.dcPaymentMethod4= dt.Rows[n]["dcPaymentMethod4"].ToString();
																								if(dt.Rows[n]["dnPaymentPrice4"].ToString()!="")
				{
					model.dnPaymentPrice4=decimal.Parse(dt.Rows[n]["dnPaymentPrice4"].ToString());
				}
																								if(dt.Rows[n]["dtAddTime"].ToString()!="")
				{
					model.dtAddTime=DateTime.Parse(dt.Rows[n]["dtAddTime"].ToString());
				}
																								if(dt.Rows[n]["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(dt.Rows[n]["dnStatus"].ToString());
				}
																												model.dcAddUser= dt.Rows[n]["dcAddUser"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}