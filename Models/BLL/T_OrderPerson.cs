using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_OrderPerson
		public partial class T_OrderPerson
	{
		private readonly SQLServerDAL.T_OrderPerson dal= new SQLServerDAL.T_OrderPerson();
		public T_OrderPerson()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcOPID)
		{
			return dal.Exists(dcOPID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_OrderPerson model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_OrderPerson model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcOPID)
		{
			
			return dal.Delete(dcOPID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_OrderPerson GetModel(string dcOPID)
		{
			
			return dal.GetModel(dcOPID);
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
		public List<ApiAirkxCompany.Model.T_OrderPerson> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_OrderPerson> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_OrderPerson> modelList = new List<ApiAirkxCompany.Model.T_OrderPerson>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_OrderPerson model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_OrderPerson();					
													model.dcOPID= dt.Rows[n]["dcOPID"].ToString();
																												model.dcOrderID= dt.Rows[n]["dcOrderID"].ToString();
																												model.dcPerName= dt.Rows[n]["dcPerName"].ToString();
																												model.dcBirthday= dt.Rows[n]["dcBirthday"].ToString();
																												model.dcPassportNo= dt.Rows[n]["dcPassportNo"].ToString();
																												model.dcPassportDate= dt.Rows[n]["dcPassportDate"].ToString();
																												model.dcSex= dt.Rows[n]["dcSex"].ToString();
																												model.dcIDNumber= dt.Rows[n]["dcIDNumber"].ToString();
																												model.dcPhone= dt.Rows[n]["dcPhone"].ToString();
																												model.dcUrgentPhone= dt.Rows[n]["dcUrgentPhone"].ToString();
																								if(dt.Rows[n]["dcType"].ToString()!="")
				{
					model.dcType=int.Parse(dt.Rows[n]["dcType"].ToString());
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