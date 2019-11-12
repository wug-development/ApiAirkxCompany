using System; 
using System.Data;
using System.Collections.Generic; 
using ApiAirkxCompany.Model;
namespace ApiAirkxCompany.BLL {
	 	//FinanceInfo
		public partial class FinanceInfoGJ
	{
		private readonly SQLServerDAL.FinanceInfoGJ dal= new SQLServerDAL.FinanceInfoGJ();
		public FinanceInfoGJ()
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
		public int  Add(ApiAirkxCompany.Model.FinanceInfoGJ model)
		{
			return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApiAirkxCompany.Model.FinanceInfoGJ model)
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
		public ApiAirkxCompany.Model.FinanceInfoGJ GetModel(int FinanceID)
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
		public List<ApiAirkxCompany.Model.FinanceInfoGJ> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApiAirkxCompany.Model.FinanceInfoGJ> DataTableToList(DataTable dt)
		{
			List<ApiAirkxCompany.Model.FinanceInfoGJ> modelList = new List<ApiAirkxCompany.Model.FinanceInfoGJ>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApiAirkxCompany.Model.FinanceInfoGJ model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApiAirkxCompany.Model.FinanceInfoGJ();					
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
																								if(dt.Rows[n]["HXPrice"].ToString()!="")
				{
					model.HXPrice=decimal.Parse(dt.Rows[n]["HXPrice"].ToString());
				}
																												model.FDPrice= dt.Rows[n]["FDPrice"].ToString();
																												model.DPriceStr= dt.Rows[n]["DPriceStr"].ToString();
																												model.SJPriceStr= dt.Rows[n]["SJPriceStr"].ToString();
																												model.SHPriceStr= dt.Rows[n]["SHPriceStr"].ToString();
																												model.SSPriceStr= dt.Rows[n]["SSPriceStr"].ToString();
																												model.LRPriceStr= dt.Rows[n]["LRPriceStr"].ToString();
																												model.XSPriceStr= dt.Rows[n]["XSPriceStr"].ToString();
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
																								if(dt.Rows[n]["FPJE"].ToString()!="")
				{
					model.FPJE=decimal.Parse(dt.Rows[n]["FPJE"].ToString());
				}
																												model.FKFS= dt.Rows[n]["FKFS"].ToString();
																												model.Customer= dt.Rows[n]["Customer"].ToString();
																												model.BZ= dt.Rows[n]["BZ"].ToString();
																												model.SPY= dt.Rows[n]["SPY"].ToString();
																												model.SPFS= dt.Rows[n]["SPFS"].ToString();
																								if(dt.Rows[n]["FDJE"].ToString()!="")
				{
					model.FDJE=decimal.Parse(dt.Rows[n]["FDJE"].ToString());
				}
																												model.FKSM= dt.Rows[n]["FKSM"].ToString();
																												model.CPDSM= dt.Rows[n]["CPDSM"].ToString();
																												model.SubSKState= dt.Rows[n]["SubSKState"].ToString();
																								if(dt.Rows[n]["SJDZ"].ToString()!="")
				{
					model.SJDZ=decimal.Parse(dt.Rows[n]["SJDZ"].ToString());
				}
																												model.DLZH= dt.Rows[n]["DLZH"].ToString();
																												model.FDOne= dt.Rows[n]["FDOne"].ToString();
																												model.FDTwo= dt.Rows[n]["FDTwo"].ToString();
																												model.SubFK= dt.Rows[n]["SubFK"].ToString();
																												model.GRYH= dt.Rows[n]["GRYH"].ToString();
																								if(dt.Rows[n]["SYJJ"].ToString()!="")
				{
					model.SYJJ=decimal.Parse(dt.Rows[n]["SYJJ"].ToString());
				}
																								if(dt.Rows[n]["FXJE"].ToString()!="")
				{
					model.FXJE=decimal.Parse(dt.Rows[n]["FXJE"].ToString());
				}
																								if(dt.Rows[n]["YWF"].ToString()!="")
				{
					model.YWF=decimal.Parse(dt.Rows[n]["YWF"].ToString());
				}
																								if(dt.Rows[n]["YSJE"].ToString()!="")
				{
					model.YSJE=decimal.Parse(dt.Rows[n]["YSJE"].ToString());
				}
																												model.FKFS1= dt.Rows[n]["FKFS1"].ToString();
																												model.FKFS2= dt.Rows[n]["FKFS2"].ToString();
																												model.FKFS3= dt.Rows[n]["FKFS3"].ToString();
																												model.SubFK1= dt.Rows[n]["SubFK1"].ToString();
																												model.SubFK2= dt.Rows[n]["SubFK2"].ToString();
																												model.SubFK3= dt.Rows[n]["SubFK3"].ToString();
																												model.GRYH1= dt.Rows[n]["GRYH1"].ToString();
																												model.GRYH2= dt.Rows[n]["GRYH2"].ToString();
																												model.GRYH3= dt.Rows[n]["GRYH3"].ToString();
																								if(dt.Rows[n]["YSJE1"].ToString()!="")
				{
					model.YSJE1=decimal.Parse(dt.Rows[n]["YSJE1"].ToString());
				}
																								if(dt.Rows[n]["YSJE2"].ToString()!="")
				{
					model.YSJE2=decimal.Parse(dt.Rows[n]["YSJE2"].ToString());
				}
																								if(dt.Rows[n]["YSJE3"].ToString()!="")
				{
					model.YSJE3=decimal.Parse(dt.Rows[n]["YSJE3"].ToString());
				}
																												model.YWR= dt.Rows[n]["YWR"].ToString();
																								if(dt.Rows[n]["SKData"].ToString()!="")
				{
					model.SKData=DateTime.Parse(dt.Rows[n]["SKData"].ToString());
				}
																												model.FKState= dt.Rows[n]["FKState"].ToString();
																												model.KPState= dt.Rows[n]["KPState"].ToString();
																												model.GNTPH= dt.Rows[n]["GNTPH"].ToString();
																												model.GNTPH1= dt.Rows[n]["GNTPH1"].ToString();
																												model.GNTPH2= dt.Rows[n]["GNTPH2"].ToString();
																												model.GNTPH3= dt.Rows[n]["GNTPH3"].ToString();
																								if(dt.Rows[n]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
				}
																								if(dt.Rows[n]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
				}
																												model.YQ= dt.Rows[n]["YQ"].ToString();
																												model.PNRText= dt.Rows[n]["PNRText"].ToString();
																												model.CJR= dt.Rows[n]["CJR"].ToString();
																												model.HBH= dt.Rows[n]["HBH"].ToString();
																												model.QLSJ= dt.Rows[n]["QLSJ"].ToString();
																												model.CWDJ= dt.Rows[n]["CWDJ"].ToString();
																												model.ZK= dt.Rows[n]["ZK"].ToString();
																												model.FWF= dt.Rows[n]["FWF"].ToString();
																						
				
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