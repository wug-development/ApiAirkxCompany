using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_OrderFlightInfo
		public partial class T_OrderFlightInfo
	{
		private readonly SQLServerDAL.T_OrderFlightInfo dal= new SQLServerDAL.T_OrderFlightInfo();
		public T_OrderFlightInfo()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcOrderFlightID)
		{
			return dal.Exists(dcOrderFlightID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_OrderFlightInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcOrderFlightID)
		{
			
			return dal.Delete(dcOrderFlightID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_OrderFlightInfo GetModel(string dcOrderFlightID)
		{
			
			return dal.GetModel(dcOrderFlightID);
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
		public List<ApiAirkxCompany.Model.T_OrderFlightInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_OrderFlightInfo> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_OrderFlightInfo> modelList = new List<ApiAirkxCompany.Model.T_OrderFlightInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_OrderFlightInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_OrderFlightInfo();					
													model.dcOrderFlightID= dt.Rows[n]["dcOrderFlightID"].ToString();
																												model.dcOrderID= dt.Rows[n]["dcOrderID"].ToString();
																								if(dt.Rows[n]["dnAirType"].ToString()!="")
				{
					model.dnAirType=int.Parse(dt.Rows[n]["dnAirType"].ToString());
				}
																								if(dt.Rows[n]["dnFlightType"].ToString()!="")
				{
					model.dnFlightType=int.Parse(dt.Rows[n]["dnFlightType"].ToString());
				}
																								if(dt.Rows[n]["dnAirID"].ToString()!="")
				{
					model.dnAirID=int.Parse(dt.Rows[n]["dnAirID"].ToString());
				}
																												model.dcAirCode= dt.Rows[n]["dcAirCode"].ToString();
																												model.dcSPortName= dt.Rows[n]["dcSPortName"].ToString();
																												model.dcEPortName= dt.Rows[n]["dcEPortName"].ToString();
																												model.dcSCode= dt.Rows[n]["dcSCode"].ToString();
																												model.dcECode= dt.Rows[n]["dcECode"].ToString();
																												model.dcSTime= dt.Rows[n]["dcSTime"].ToString();
																												model.dcETime= dt.Rows[n]["dcETime"].ToString();
																												model.dcJixing= dt.Rows[n]["dcJixing"].ToString();
																								if(dt.Rows[n]["dcAirCompanyID"].ToString()!="")
				{
					model.dcAirCompanyID=int.Parse(dt.Rows[n]["dcAirCompanyID"].ToString());
				}
																												model.dcCompanyName= dt.Rows[n]["dcCompanyName"].ToString();
																												model.dcEnCompanyName= dt.Rows[n]["dcEnCompanyName"].ToString();
																												model.dcCompanyLogo= dt.Rows[n]["dcCompanyLogo"].ToString();
																												model.dcCompanyCode= dt.Rows[n]["dcCompanyCode"].ToString();
																												model.dcContent= dt.Rows[n]["dcContent"].ToString();
																						
				
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