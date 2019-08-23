using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//T_Company
		public partial class T_Company
	{
		private readonly SQLServerDAL.T_Company dal= new SQLServerDAL.T_Company();
		public T_Company()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcCompanyID)
		{
			return dal.Exists(dcCompanyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(ApiAirkxCompany.Model.T_Company model)
		{
			dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_Company model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcCompanyID)
		{
			
			return dal.Delete(dcCompanyID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_Company GetModel(string dcCompanyID)
		{
			
			return dal.GetModel(dcCompanyID);
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
		public List<ApiAirkxCompany.Model.T_Company> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_Company> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_Company> modelList = new List<ApiAirkxCompany.Model.T_Company>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_Company model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.T_Company();					
													model.dcCompanyID= dt.Rows[n]["dcCompanyID"].ToString();
																												model.dcUserName= dt.Rows[n]["dcUserName"].ToString();
																												model.dcPassword= dt.Rows[n]["dcPassword"].ToString();
																												model.dcFullName= dt.Rows[n]["dcFullName"].ToString();
																												model.dcShortName= dt.Rows[n]["dcShortName"].ToString();
																												model.dcRegistrationNumber= dt.Rows[n]["dcRegistrationNumber"].ToString();
																								if(dt.Rows[n]["dnRegisteredFunds"].ToString()!="")
				{
					model.dnRegisteredFunds=decimal.Parse(dt.Rows[n]["dnRegisteredFunds"].ToString());
				}
																												model.dcBusinessAddress= dt.Rows[n]["dcBusinessAddress"].ToString();
																												model.dcMainBusiness= dt.Rows[n]["dcMainBusiness"].ToString();
																												model.dcShareholder= dt.Rows[n]["dcShareholder"].ToString();
																												model.dcLegalRepresentative= dt.Rows[n]["dcLegalRepresentative"].ToString();
																												model.dcLicenseRegistrationAddr= dt.Rows[n]["dcLicenseRegistrationAddr"].ToString();
																												model.dcBankAccount= dt.Rows[n]["dcBankAccount"].ToString();
																												model.dcOpeningBank= dt.Rows[n]["dcOpeningBank"].ToString();
																												model.dcParentCompanyID= dt.Rows[n]["dcParentCompanyID"].ToString();
																								if(dt.Rows[n]["dnCreditLine"].ToString()!="")
				{
					model.dnCreditLine=int.Parse(dt.Rows[n]["dnCreditLine"].ToString());
				}
																												model.dtCheckOutDate= dt.Rows[n]["dtCheckOutDate"].ToString();
																												model.dcLinkName= dt.Rows[n]["dcLinkName"].ToString();
																												model.dcPhone= dt.Rows[n]["dcPhone"].ToString();
																												model.dcAdminID= dt.Rows[n]["dcAdminID"].ToString();
																												model.dcAdminName= dt.Rows[n]["dcAdminName"].ToString();
																												model.dcOther= dt.Rows[n]["dcOther"].ToString();
																								if(dt.Rows[n]["dtAddDatetime"].ToString()!="")
				{
					model.dtAddDatetime=DateTime.Parse(dt.Rows[n]["dtAddDatetime"].ToString());
				}
																								if(dt.Rows[n]["dnIsCheck"].ToString()!="")
				{
					model.dnIsCheck=int.Parse(dt.Rows[n]["dnIsCheck"].ToString());
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