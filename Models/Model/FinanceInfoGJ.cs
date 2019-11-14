using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//FinanceInfo
		public class FinanceInfoGJ
	{
   		     
      		
		private int _financeid;
		/// <summary>
		/// FinanceID
        /// </summary>	
        public int FinanceID
        {
            get{ return _financeid; }
            set{ _financeid = value; }
        }        
			
		private string _company = "";
		/// <summary>
		/// Company
        /// </summary>	
        public string Company
        {
            get{ return _company; }
            set{ _company = value; }
        }        
			
		private string _jlcode = "";
		/// <summary>
		/// JLCode
        /// </summary>	
        public string JLCode
        {
            get{ return _jlcode; }
            set{ _jlcode = value; }
        }        
			
		private decimal _dprice = 0M;
		/// <summary>
		/// DPrice
        /// </summary>	
        public decimal DPrice
        {
            get{ return _dprice; }
            set{ _dprice = value; }
        }        
			
		private decimal _sjprice = 0M;
		/// <summary>
		/// SJPrice
        /// </summary>	
        public decimal SJPrice
        {
            get{ return _sjprice; }
            set{ _sjprice = value; }
        }        
			
		private decimal _shprice = 0M;
		/// <summary>
		/// SHPrice
        /// </summary>	
        public decimal SHPrice
        {
            get{ return _shprice; }
            set{ _shprice = value; }
        }        
			
		private decimal _ssprice = 0M;
		/// <summary>
		/// SSPrice
        /// </summary>	
        public decimal SSPrice
        {
            get{ return _ssprice; }
            set{ _ssprice = value; }
        }        
			
		private decimal _lrprice = 0M;
		/// <summary>
		/// LRPrice
        /// </summary>	
        public decimal LRPrice
        {
            get{ return _lrprice; }
            set{ _lrprice = value; }
        }        
			
		private decimal _xsprice = 0M;
		/// <summary>
		/// XSPrice
        /// </summary>	
        public decimal XSPrice
        {
            get{ return _xsprice; }
            set{ _xsprice = value; }
        }        
			
		private decimal _hxprice = 0M;
		/// <summary>
		/// HXPrice
        /// </summary>	
        public decimal HXPrice
        {
            get{ return _hxprice; }
            set{ _hxprice = value; }
        }        
			
		private string _fdprice = "";
		/// <summary>
		/// FDPrice
        /// </summary>	
        public string FDPrice
        {
            get{ return _fdprice; }
            set{ _fdprice = value; }
        }        
			
		private string _dpricestr = "";
        /// <summary>
        /// DPriceStr
        /// </summary>	
        public string DPriceStr
        {
            get{ return _dpricestr; }
            set{ _dpricestr = value; }
        }        
			
		private string _sjpricestr = "";
		/// <summary>
		/// SJPriceStr
        /// </summary>	
        public string SJPriceStr
        {
            get{ return _sjpricestr; }
            set{ _sjpricestr = value; }
        }        
			
		private string _shpricestr = "";
		/// <summary>
		/// SHPriceStr
        /// </summary>	
        public string SHPriceStr
        {
            get{ return _shpricestr; }
            set{ _shpricestr = value; }
        }        
			
		private string _sspricestr = "";
		/// <summary>
		/// SSPriceStr
        /// </summary>	
        public string SSPriceStr
        {
            get{ return _sspricestr; }
            set{ _sspricestr = value; }
        }        
			
		private string _lrpricestr = "";
		/// <summary>
		/// LRPriceStr
        /// </summary>	
        public string LRPriceStr
        {
            get{ return _lrpricestr; }
            set{ _lrpricestr = value; }
        }        
			
		private string _xspricestr = "";
		/// <summary>
		/// XSPriceStr
        /// </summary>	
        public string XSPriceStr
        {
            get{ return _xspricestr; }
            set{ _xspricestr = value; }
        }        
			
		private string _cpd = "";
		/// <summary>
		/// CPD
        /// </summary>	
        public string CPD
        {
            get{ return _cpd; }
            set{ _cpd = value; }
        }        
			
		private DateTime _addtime;
		/// <summary>
		/// AddTime
        /// </summary>	
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
			
		private string _adduser = "";
		/// <summary>
		/// AddUser
        /// </summary>	
        public string AddUser
        {
            get{ return _adduser; }
            set{ _adduser = value; }
        }        
			
		private string _skstate = "";
		/// <summary>
		/// SKState
        /// </summary>	
        public string SKState
        {
            get{ return _skstate; }
            set{ _skstate = value; }
        }        
			
		private string _cpy = "";
		/// <summary>
		/// CPY
        /// </summary>	
        public string CPY
        {
            get{ return _cpy; }
            set{ _cpy = value; }
        }        
			
		private string _xc = "";
		/// <summary>
		/// XC
        /// </summary>	
        public string XC
        {
            get{ return _xc; }
            set{ _xc = value; }
        }        
			
		private string _rs = "";
		/// <summary>
		/// RS
        /// </summary>	
        public string RS
        {
            get{ return _rs; }
            set{ _rs = value; }
        }        
			
		private string _ph = "";
		/// <summary>
		/// PH
        /// </summary>	
        public string PH
        {
            get{ return _ph; }
            set{ _ph = value; }
        }        
			
		private string _fptt = "";
		/// <summary>
		/// FPTT
        /// </summary>	
        public string FPTT
        {
            get{ return _fptt; }
            set{ _fptt = value; }
        }        
			
		private decimal _fpje = 0M;
		/// <summary>
		/// FPJE
        /// </summary>	
        public decimal FPJE
        {
            get{ return _fpje; }
            set{ _fpje = value; }
        }        
			
		private string _fkfs = "请选择";
		/// <summary>
		/// FKFS
        /// </summary>	
        public string FKFS
        {
            get{ return _fkfs; }
            set{ _fkfs = value; }
        }        
			
		private string _customer = "";
		/// <summary>
		/// Customer
        /// </summary>	
        public string Customer
        {
            get{ return _customer; }
            set{ _customer = value; }
        }        
			
		private string _bz = "";
		/// <summary>
		/// BZ
        /// </summary>	
        public string BZ
        {
            get{ return _bz; }
            set{ _bz = value; }
        }        
			
		private string _spy = "";
		/// <summary>
		/// SPY
        /// </summary>	
        public string SPY
        {
            get{ return _spy; }
            set{ _spy = value; }
        }        
			
		private string _spfs = "";
		/// <summary>
		/// SPFS
        /// </summary>	
        public string SPFS
        {
            get{ return _spfs; }
            set{ _spfs = value; }
        }        
			
		private decimal _fdje = 0M;
		/// <summary>
		/// FDJE
        /// </summary>	
        public decimal FDJE
        {
            get{ return _fdje; }
            set{ _fdje = value; }
        }        
			
		private string _fksm = "";
		/// <summary>
		/// FKSM
        /// </summary>	
        public string FKSM
        {
            get{ return _fksm; }
            set{ _fksm = value; }
        }        
			
		private string _cpdsm = "";
		/// <summary>
		/// CPDSM
        /// </summary>	
        public string CPDSM
        {
            get{ return _cpdsm; }
            set{ _cpdsm = value; }
        }        
			
		private string _subskstate = "";
		/// <summary>
		/// SubSKState
        /// </summary>	
        public string SubSKState
        {
            get{ return _subskstate; }
            set{ _subskstate = value; }
        }        
			
		private decimal _sjdz = 0M;
		/// <summary>
		/// SJDZ
        /// </summary>	
        public decimal SJDZ
        {
            get{ return _sjdz; }
            set{ _sjdz = value; }
        }        
			
		private string _dlzh = "";
		/// <summary>
		/// DLZH
        /// </summary>	
        public string DLZH
        {
            get{ return _dlzh; }
            set{ _dlzh = value; }
        }        
			
		private string _fdone = "";
		/// <summary>
		/// FDOne
        /// </summary>	
        public string FDOne
        {
            get{ return _fdone; }
            set{ _fdone = value; }
        }        
			
		private string _fdtwo = "";
		/// <summary>
		/// FDTwo
        /// </summary>	
        public string FDTwo
        {
            get{ return _fdtwo; }
            set{ _fdtwo = value; }
        }        
			
		private string _subfk = "";
		/// <summary>
		/// SubFK
        /// </summary>	
        public string SubFK
        {
            get{ return _subfk; }
            set{ _subfk = value; }
        }        
			
		private string _gryh = "";
		/// <summary>
		/// GRYH
        /// </summary>	
        public string GRYH
        {
            get{ return _gryh; }
            set{ _gryh = value; }
        }        
			
		private decimal _syjj = 0M;
		/// <summary>
		/// SYJJ
        /// </summary>	
        public decimal SYJJ
        {
            get{ return _syjj; }
            set{ _syjj = value; }
        }        
			
		private decimal _fxje = 0M;
		/// <summary>
		/// FXJE
        /// </summary>	
        public decimal FXJE
        {
            get{ return _fxje; }
            set{ _fxje = value; }
        }        
			
		private decimal _ywf = 0M;
		/// <summary>
		/// YWF
        /// </summary>	
        public decimal YWF
        {
            get{ return _ywf; }
            set{ _ywf = value; }
        }        
			
		private decimal _ysje = 0M;
		/// <summary>
		/// YSJE
        /// </summary>	
        public decimal YSJE
        {
            get{ return _ysje; }
            set{ _ysje = value; }
        }        
			
		private string _fkfs1 = "请选择";
		/// <summary>
		/// FKFS1
        /// </summary>	
        public string FKFS1
        {
            get{ return _fkfs1; }
            set{ _fkfs1 = value; }
        }        
			
		private string _fkfs2 = "请选择";
		/// <summary>
		/// FKFS2
        /// </summary>	
        public string FKFS2
        {
            get{ return _fkfs2; }
            set{ _fkfs2 = value; }
        }        
			
		private string _fkfs3 = "请选择";
		/// <summary>
		/// FKFS3
        /// </summary>	
        public string FKFS3
        {
            get{ return _fkfs3; }
            set{ _fkfs3 = value; }
        }        
			
		private string _subfk1 = "";
		/// <summary>
		/// SubFK1
        /// </summary>	
        public string SubFK1
        {
            get{ return _subfk1; }
            set{ _subfk1 = value; }
        }        
			
		private string _subfk2 = "";
		/// <summary>
		/// SubFK2
        /// </summary>	
        public string SubFK2
        {
            get{ return _subfk2; }
            set{ _subfk2 = value; }
        }        
			
		private string _subfk3 = "";
		/// <summary>
		/// SubFK3
        /// </summary>	
        public string SubFK3
        {
            get{ return _subfk3; }
            set{ _subfk3 = value; }
        }        
			
		private string _gryh1 = "";
		/// <summary>
		/// GRYH1
        /// </summary>	
        public string GRYH1
        {
            get{ return _gryh1; }
            set{ _gryh1 = value; }
        }        
			
		private string _gryh2 = "";
		/// <summary>
		/// GRYH2
        /// </summary>	
        public string GRYH2
        {
            get{ return _gryh2; }
            set{ _gryh2 = value; }
        }        
			
		private string _gryh3 = "";
		/// <summary>
		/// GRYH3
        /// </summary>	
        public string GRYH3
        {
            get{ return _gryh3; }
            set{ _gryh3 = value; }
        }        
			
		private decimal _ysje1 = 0M;
		/// <summary>
		/// YSJE1
        /// </summary>	
        public decimal YSJE1
        {
            get{ return _ysje1; }
            set{ _ysje1 = value; }
        }
			
		private decimal _ysje2 = 0M;
		/// <summary>
		/// YSJE2
        /// </summary>	
        public decimal YSJE2
        {
            get{ return _ysje2; }
            set{ _ysje2 = value; }
        }        
			
		private decimal _ysje3 = 0M;
		/// <summary>
		/// YSJE3
        /// </summary>	
        public decimal YSJE3
        {
            get{ return _ysje3; }
            set{ _ysje3 = value; }
        }        
			
		private string _ywr = "请选择";
		/// <summary>
		/// YWR
        /// </summary>	
        public string YWR
        {
            get{ return _ywr; }
            set{ _ywr = value; }
        }        
			
		private DateTime? _skdata;
		/// <summary>
		/// SKData
        /// </summary>	
        public DateTime? SKData
        {
            get{ return _skdata; }
            set{ _skdata = value; }
        }        
			
		private string _fkstate = "";
		/// <summary>
		/// FKState
        /// </summary>	
        public string FKState
        {
            get{ return _fkstate; }
            set{ _fkstate = value; }
        }        
			
		private string _kpstate = "";
		/// <summary>
		/// KPState
        /// </summary>	
        public string KPState
        {
            get{ return _kpstate; }
            set{ _kpstate = value; }
        }        
			
		private string _gntph = "";
		/// <summary>
		/// GNTPH
        /// </summary>	
        public string GNTPH
        {
            get{ return _gntph; }
            set{ _gntph = value; }
        }        
			
		private string _gntph1 = "";
		/// <summary>
		/// GNTPH1
        /// </summary>	
        public string GNTPH1
        {
            get{ return _gntph1; }
            set{ _gntph1 = value; }
        }        
			
		private string _gntph2 = "";
		/// <summary>
		/// GNTPH2
        /// </summary>	
        public string GNTPH2
        {
            get{ return _gntph2; }
            set{ _gntph2 = value; }
        }        
			
		private string _gntph3 = "";
		/// <summary>
		/// GNTPH3
        /// </summary>	
        public string GNTPH3
        {
            get{ return _gntph3; }
            set{ _gntph3 = value; }
        }        
			
		private DateTime? _startdate;
		/// <summary>
		/// StartDate
        /// </summary>	
        public DateTime? StartDate
        {
            get{ return _startdate; }
            set{ _startdate = value; }
        }        
			
		private DateTime? _enddate;
		/// <summary>
		/// EndDate
        /// </summary>	
        public DateTime? EndDate
        {
            get{ return _enddate; }
            set{ _enddate = value; }
        }        
			
		private string _yq = "";
		/// <summary>
		/// YQ
        /// </summary>	
        public string YQ
        {
            get{ return _yq; }
            set{ _yq = value; }
        }        
			
		private string _pnrtext = "";
		/// <summary>
		/// PNRText
        /// </summary>	
        public string PNRText
        {
            get{ return _pnrtext; }
            set{ _pnrtext = value; }
        }        
			
		private string _cjr = "";
		/// <summary>
		/// CJR
        /// </summary>	
        public string CJR
        {
            get{ return _cjr; }
            set{ _cjr = value; }
        }        
			
		private string _hbh = "";
		/// <summary>
		/// HBH
        /// </summary>	
        public string HBH
        {
            get{ return _hbh; }
            set{ _hbh = value; }
        }        
			
		private string _qlsj = "";
		/// <summary>
		/// QLSJ
        /// </summary>	
        public string QLSJ
        {
            get{ return _qlsj; }
            set{ _qlsj = value; }
        }        
			
		private string _cwdj = "";
		/// <summary>
		/// CWDJ
        /// </summary>	
        public string CWDJ
        {
            get{ return _cwdj; }
            set{ _cwdj = value; }
        }        
			
		private string _zk = "";
		/// <summary>
		/// ZK
        /// </summary>	
        public string ZK
        {
            get{ return _zk; }
            set{ _zk = value; }
        }        
			
		private string _fwf = "";
		/// <summary>
		/// FWF
        /// </summary>	
        public string FWF
        {
            get{ return _fwf; }
            set{ _fwf = value; }
        }        
		   
	}
}