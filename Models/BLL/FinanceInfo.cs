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
		public List<ApiAirkxCompany.Model.FinanceInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.FinanceInfo> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.FinanceInfo> modelList = new List<ApiAirkxCompany.Model.FinanceInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.FinanceInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.FinanceInfo();					
									if(dt.Rows[n]["FinanceID"].ToString()!="")
				{
					model.FinanceID=int.Parse(dt.Rows[n]["FinanceID"].ToString());
				}
																												model.Company= dt.Rows[n]["Company"].ToString();
																												model.JLCode= dt.Rows[n]["JLCode"].ToString();
																								if(dt.Rows[n]["DPrice"].ToString()!="")
				{
					model.DPrice=decimal.Parse(dt.Rows[n]["DPrice"].ToString());
				}
																								if(dt.Rows[n]["SJPrice"].ToString()!="")
				{
					model.SJPrice=decimal.Parse(dt.Rows[n]["SJPrice"].ToString());
				}
																								if(dt.Rows[n]["SHPrice"].ToString()!="")
				{
					model.SHPrice=decimal.Parse(dt.Rows[n]["SHPrice"].ToString());
				}
																								if(dt.Rows[n]["SSPrice"].ToString()!="")
				{
					model.SSPrice=decimal.Parse(dt.Rows[n]["SSPrice"].ToString());
				}
																								if(dt.Rows[n]["LRPrice"].ToString()!="")
				{
					model.LRPrice=decimal.Parse(dt.Rows[n]["LRPrice"].ToString());
				}
																								if(dt.Rows[n]["XSPrice"].ToString()!="")
				{
					model.XSPrice=decimal.Parse(dt.Rows[n]["XSPrice"].ToString());
				}
																												model.FDPrice= dt.Rows[n]["FDPrice"].ToString();
																												model.CPD= dt.Rows[n]["CPD"].ToString();
																								if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																												model.AddUser= dt.Rows[n]["AddUser"].ToString();
																												model.SKState= dt.Rows[n]["SKState"].ToString();
																												model.CPY= dt.Rows[n]["CPY"].ToString();
																												model.XC= dt.Rows[n]["XC"].ToString();
																												model.RS= dt.Rows[n]["RS"].ToString();
																												model.PH= dt.Rows[n]["PH"].ToString();
																												model.FPTT= dt.Rows[n]["FPTT"].ToString();
																												model.FPJE= dt.Rows[n]["FPJE"].ToString();
																												model.FKFS= dt.Rows[n]["FKFS"].ToString();
																												model.Customer= dt.Rows[n]["Customer"].ToString();
																												model.BZ= dt.Rows[n]["BZ"].ToString();
																												model.SPY= dt.Rows[n]["SPY"].ToString();
																												model.SPFS= dt.Rows[n]["SPFS"].ToString();
																												model.ZK= dt.Rows[n]["ZK"].ToString();
																												model.SubFKFS= dt.Rows[n]["SubFKFS"].ToString();
																								if(dt.Rows[n]["YSJE"].ToString()!="")
				{
					model.YSJE=decimal.Parse(dt.Rows[n]["YSJE"].ToString());
				}
																								if(dt.Rows[n]["YSJE1"].ToString()!="")
				{
					model.YSJE1=decimal.Parse(dt.Rows[n]["YSJE1"].ToString());
				}
																												model.FKFS1= dt.Rows[n]["FKFS1"].ToString();
																												model.SubFKFS1= dt.Rows[n]["SubFKFS1"].ToString();
																												model.SubSKState= dt.Rows[n]["SubSKState"].ToString();
																												model.GRYH= dt.Rows[n]["GRYH"].ToString();
																												model.GRYH1= dt.Rows[n]["GRYH1"].ToString();
																												model.FDPrice1= dt.Rows[n]["FDPrice1"].ToString();
																								if(dt.Rows[n]["YSPrice"].ToString()!="")
				{
					model.YSPrice=decimal.Parse(dt.Rows[n]["YSPrice"].ToString());
				}
																								if(dt.Rows[n]["FXPrice"].ToString()!="")
				{
					model.FXPrice=decimal.Parse(dt.Rows[n]["FXPrice"].ToString());
				}
																								if(dt.Rows[n]["SJDZ"].ToString()!="")
				{
					model.SJDZ=decimal.Parse(dt.Rows[n]["SJDZ"].ToString());
				}
																								if(dt.Rows[n]["JPQJ"].ToString()!="")
				{
					model.JPQJ=decimal.Parse(dt.Rows[n]["JPQJ"].ToString());
				}
																												model.CW= dt.Rows[n]["CW"].ToString();
																												model.OrderCode= dt.Rows[n]["OrderCode"].ToString();
																								if(dt.Rows[n]["Jiangjin"].ToString()!="")
				{
					model.Jiangjin=decimal.Parse(dt.Rows[n]["Jiangjin"].ToString());
				}
																												model.JJRY= dt.Rows[n]["JJRY"].ToString();
																												model.GPR= dt.Rows[n]["GPR"].ToString();
																												model.HBH= dt.Rows[n]["HBH"].ToString();
																												model.DPRQ= dt.Rows[n]["DPRQ"].ToString();
																								if(dt.Rows[n]["NewFXPrice"].ToString()!="")
				{
					model.NewFXPrice=decimal.Parse(dt.Rows[n]["NewFXPrice"].ToString());
				}
																								if(dt.Rows[n]["SKData"].ToString()!="")
				{
					model.SKData=DateTime.Parse(dt.Rows[n]["SKData"].ToString());
				}
																												model.CPDXX= dt.Rows[n]["CPDXX"].ToString();
																												model.BXXX= dt.Rows[n]["BXXX"].ToString();
																												model.FKState= dt.Rows[n]["FKState"].ToString();
																						
				
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