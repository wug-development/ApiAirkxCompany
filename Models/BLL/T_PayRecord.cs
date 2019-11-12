using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_PayRecord
		public partial class T_PayRecord
	{
		private readonly SQLServerDAL.T_PayRecord dal= new SQLServerDAL.T_PayRecord();
		public T_PayRecord()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcPRID)
		{
			return dal.Exists(dcPRID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_PayRecord model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_PayRecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcPRID)
		{
			
			return dal.Delete(dcPRID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_PayRecord GetModel(string dcPRID)
		{
			
			return dal.GetModel(dcPRID);
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
		public List<ApiAirkxCompany.Model.T_PayRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_PayRecord> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_PayRecord> modelList = new List<ApiAirkxCompany.Model.T_PayRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_PayRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_PayRecord();					
													model.dcPRID= dt.Rows[n]["dcPRID"].ToString();
																												model.dcCompanyID= dt.Rows[n]["dcCompanyID"].ToString();
																								if(dt.Rows[n]["dnMoney"].ToString()!="")
				{
					model.dnMoney=decimal.Parse(dt.Rows[n]["dnMoney"].ToString());
				}
																												model.dcPayType= dt.Rows[n]["dcPayType"].ToString();
																												model.dcPayDate= dt.Rows[n]["dcPayDate"].ToString();
																												model.dcRemarks= dt.Rows[n]["dcRemarks"].ToString();
																								if(dt.Rows[n]["dnStatus"].ToString()!="")
				{
					model.dnStatus=int.Parse(dt.Rows[n]["dnStatus"].ToString());
				}
																												model.dcAdminID= dt.Rows[n]["dcAdminID"].ToString();
																												model.dcAdminName= dt.Rows[n]["dcAdminName"].ToString();
																								if(dt.Rows[n]["dtAddDatetime"].ToString()!="")
				{
					model.dtAddDatetime=DateTime.Parse(dt.Rows[n]["dtAddDatetime"].ToString());
				}
																												model.dcComfirmAdminID= dt.Rows[n]["dcComfirmAdminID"].ToString();
																												model.dcComfirmDate= dt.Rows[n]["dcComfirmDate"].ToString();
																						
				
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