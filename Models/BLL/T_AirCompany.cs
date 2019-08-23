/**  版本信息模板在安装目录下，可自行修改。
* T_AirCompany.cs
*
* 功 能： N/A
* 类 名： T_AirCompany
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/8/14 18:13:18   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL
{
	/// <summary>
	/// T_AirCompany
	/// </summary>
	public partial class T_AirCompany
	{
        private readonly SQLServerDAL.T_AirCompany dal = new SQLServerDAL.T_AirCompany();
		public T_AirCompany()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int dcAirCompanyID)
		{
			return dal.Exists(dcAirCompanyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ApiAirkxCompany.Model.T_AirCompany model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.T_AirCompany model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int dcAirCompanyID)
		{
			
			return dal.Delete(dcAirCompanyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string dcAirCompanyIDlist )
		{
			return dal.DeleteList(dcAirCompanyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.T_AirCompany GetModel(int dcAirCompanyID)
		{
			
			return dal.GetModel(dcAirCompanyID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ApiAirkxCompany.Model.T_AirCompany GetModel(string dcCompanyCode)
        {

            return dal.GetModel(dcCompanyCode);
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
		public List<ApiAirkxCompany.Model.T_AirCompany> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.T_AirCompany> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.T_AirCompany> modelList = new List<ApiAirkxCompany.Model.T_AirCompany>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.T_AirCompany model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

