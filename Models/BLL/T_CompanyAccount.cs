using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_CompanyAccount
		public partial class T_CompanyAccount
	{
		private readonly SQLServerDAL.T_CompanyAccount dal= new SQLServerDAL.T_CompanyAccount();
		public T_CompanyAccount()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcCAID)
		{
			return dal.Exists(dcCAID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_CompanyAccount model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_CompanyAccount model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcCAID)
		{
			
			return dal.Delete(dcCAID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_CompanyAccount GetModel(string dcCAID)
		{
			
			return dal.GetModel(dcCAID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_CompanyAccount GetCModel(string dcCompanyID)
		{
			
			return dal.GetCModel(dcCompanyID);
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
		public List<ApiAirkxCompany.Model.T_CompanyAccount> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_CompanyAccount> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_CompanyAccount> modelList = new List<ApiAirkxCompany.Model.T_CompanyAccount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_CompanyAccount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_CompanyAccount();					
													model.dcCAID= dt.Rows[n]["dcCAID"].ToString();
																												model.dcCompanyID= dt.Rows[n]["dcCompanyID"].ToString();
																								if(dt.Rows[n]["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=decimal.Parse(dt.Rows[n]["dnCreditLine"].ToString());
				}
																								if(dt.Rows[n]["dnDebt"].ToString()!="")
				{
					model.dnDebt=decimal.Parse(dt.Rows[n]["dnDebt"].ToString());
				}
																								if(dt.Rows[n]["dnPayCount"].ToString()!="")
				{
					model.dnPayCount=decimal.Parse(dt.Rows[n]["dnPayCount"].ToString());
				}
																								if(dt.Rows[n]["dnUrgentMoney"].ToString()!="")
				{
					model.dnUrgentMoney=decimal.Parse(dt.Rows[n]["dnUrgentMoney"].ToString());
				}
																												model.dcLastOrderDate= dt.Rows[n]["dcLastOrderDate"].ToString();
																								if(dt.Rows[n]["dnTotalTicketPrice"].ToString()!="")
				{
					model.dnTotalTicketPrice=decimal.Parse(dt.Rows[n]["dnTotalTicketPrice"].ToString());
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