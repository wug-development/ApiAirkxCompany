using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL
{
	//T_AdminMenu
	public partial class T_AdminMenu
	{
		private readonly SQLServerDAL.T_AdminMenu dal= new SQLServerDAL.T_AdminMenu();
		public T_AdminMenu()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcAMID)
		{
			return dal.Exists(dcAMID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_AdminMenu model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_AdminMenu model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcAMID)
		{
			
			return dal.Delete(dcAMID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_AdminMenu GetModel(string dcAMID)
		{
			
			return dal.GetModel(dcAMID);
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
		public List<ApiAirkxCompany.Model.T_AdminMenu> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_AdminMenu> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_AdminMenu> modelList = new List<ApiAirkxCompany.Model.T_AdminMenu>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_AdminMenu model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_AdminMenu();					
													model.dcAMID= dt.Rows[n]["dcAMID"].ToString();
																												model.dcAdminID= dt.Rows[n]["dcAdminID"].ToString();
																												model.dcMenuID= dt.Rows[n]["dcMenuID"].ToString();
																						
				
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