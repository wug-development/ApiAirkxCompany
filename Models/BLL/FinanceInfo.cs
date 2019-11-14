using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//FinanceInfo
		public partial class FinanceInfo
	{
		private readonly SQLServerDAL.FinanceInfo dal= new SQLServerDAL.FinanceInfo();
		public FinanceInfo()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FinanceID)
		{
			return dal.Exists(FinanceID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ApiAirkxCompany.Model.FinanceInfo model)
		{
			return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.FinanceInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FinanceID)
		{
			
			return dal.Delete(FinanceID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string FinanceIDlist )
		{
			return dal.DeleteList(FinanceIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApiAirkxCompany.Model.FinanceInfo GetModel(int FinanceID)
		{
			
			return dal.GetModel(FinanceID);
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
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}