﻿using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_Order
		public partial class T_Order
	{
		private readonly SQLServerDAL.T_Order dal= new SQLServerDAL.T_Order();
		public T_Order()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcOrderID)
		{
			return dal.Exists(dcOrderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_Order model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_Order model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcOrderID)
		{
			
			return dal.Delete(dcOrderID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Order GetModel(string dcOrderID)
		{
			
			return dal.GetModel(dcOrderID);
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
		public List<ApiAirkxCompany.Model.T_Order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_Order> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_Order> modelList = new List<ApiAirkxCompany.Model.T_Order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_Order model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_Order();					
													model.dcOrderID= dt.Rows[n]["dcOrderID"].ToString();
																												model.dcOrderCode= dt.Rows[n]["dcOrderCode"].ToString();
																												model.dcTicketNO= dt.Rows[n]["dcTicketNO"].ToString();
																								if(dt.Rows[n]["dnOrderType"].ToString()!="")
				{
					model.dnOrderType=int.Parse(dt.Rows[n]["dnOrderType"].ToString());
				}
																								if(dt.Rows[n]["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(dt.Rows[n]["dnAirType"].ToString());
				}
																												model.dcStartDate= dt.Rows[n]["dcStartDate"].ToString();
																												model.dcBackDate= dt.Rows[n]["dcBackDate"].ToString();
																												model.dcStartCity= dt.Rows[n]["dcStartCity"].ToString();
																												model.dcBackCity= dt.Rows[n]["dcBackCity"].ToString();
																												model.dcCompanyID= dt.Rows[n]["dcCompanyID"].ToString();
																												model.dcCompanyName= dt.Rows[n]["dcCompanyName"].ToString();
																												model.dcLinkName= dt.Rows[n]["dcLinkName"].ToString();
																												model.dcPhone= dt.Rows[n]["dcPhone"].ToString();
																								if(dt.Rows[n]["dnPrice"].ToString()!="")
				{
					model.dnPrice=decimal.Parse(dt.Rows[n]["dnPrice"].ToString());
				}
																								if(dt.Rows[n]["dnTax"].ToString()!="")
				{
					model.dnTax=decimal.Parse(dt.Rows[n]["dnTax"].ToString());
				}
																								if(dt.Rows[n]["dnServicePrice"].ToString()!="")
				{
					model.dnServicePrice=decimal.Parse(dt.Rows[n]["dnServicePrice"].ToString());
				}
																								if(dt.Rows[n]["dnSafePrice"].ToString()!="")
				{
					model.dnSafePrice=decimal.Parse(dt.Rows[n]["dnSafePrice"].ToString());
				}
																								if(dt.Rows[n]["dnTotalPrice"].ToString()!="")
				{
					model.dnTotalPrice=decimal.Parse(dt.Rows[n]["dnTotalPrice"].ToString());
				}
																								if(dt.Rows[n]["dnChangePrice"].ToString()!="")
				{
					model.dnChangePrice=decimal.Parse(dt.Rows[n]["dnChangePrice"].ToString());
				}
																								if(dt.Rows[n]["dnChangeDatePrice"].ToString()!="")
				{
					model.dnChangeDatePrice=decimal.Parse(dt.Rows[n]["dnChangeDatePrice"].ToString());
				}
																								if(dt.Rows[n]["dnChaPrice"].ToString()!="")
				{
					model.dnChaPrice=decimal.Parse(dt.Rows[n]["dnChaPrice"].ToString());
				}
																												model.dcContent= dt.Rows[n]["dcContent"].ToString();
																												model.dcAdminID= dt.Rows[n]["dcAdminID"].ToString();
																												model.dcAdminName= dt.Rows[n]["dcAdminName"].ToString();
																								if(dt.Rows[n]["dnTicketID"].ToString()!="")
				{
					model.dnTicketID=int.Parse(dt.Rows[n]["dnTicketID"].ToString());
				}
																								if(dt.Rows[n]["dnDetailID"].ToString()!="")
				{
					model.dnDetailID=int.Parse(dt.Rows[n]["dnDetailID"].ToString());
				}
																								if(dt.Rows[n]["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(dt.Rows[n]["dnStatus"].ToString());
				}
																								if(dt.Rows[n]["dnOrderStatus"].ToString()!="")
				{
					model.dnOrderStatus=int.Parse(dt.Rows[n]["dnOrderStatus"].ToString());
				}
																								if(dt.Rows[n]["dnIsTicket"].ToString()!="")
				{
					model.dnIsTicket=int.Parse(dt.Rows[n]["dnIsTicket"].ToString());
				}
																								if(dt.Rows[n]["dtAddTime"].ToString()!="")
				{
					model.dtAddTime=DateTime.Parse(dt.Rows[n]["dtAddTime"].ToString());
				}
																								if(dt.Rows[n]["dtEditTime"].ToString()!="")
				{
					model.dtEditTime=DateTime.Parse(dt.Rows[n]["dtEditTime"].ToString());
				}
																						
				
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