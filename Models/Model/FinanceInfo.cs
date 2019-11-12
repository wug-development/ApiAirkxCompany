using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//FinanceInfo
		public class FinanceInfo
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
			
		private string _company;
		/// <summary>
		/// Company
        /// </summary>	
        public string Company
        {
            get{ return _company; }
            set{ _company = value; }
        }        
			
		private string _jlcode;
		/// <summary>
		/// JLCode
        /// </summary>	
        public string JLCode
        {
            get{ return _jlcode; }
            set{ _jlcode = value; }
        }        
			
		private decimal _dprice;
		/// <summary>
		/// DPrice
        /// </summary>	
        public decimal DPrice
        {
            get{ return _dprice; }
            set{ _dprice = value; }
        }        
			
		private decimal _sjprice;
		/// <summary>
		/// SJPrice
        /// </summary>	
        public decimal SJPrice
        {
            get{ return _sjprice; }
            set{ _sjprice = value; }
        }        
			
		private decimal _shprice;
		/// <summary>
		/// SHPrice
        /// </summary>	
        public decimal SHPrice
        {
            get{ return _shprice; }
            set{ _shprice = value; }
        }        
			
		private decimal _ssprice;
		/// <summary>
		/// SSPrice
        /// </summary>	
        public decimal SSPrice
        {
            get{ return _ssprice; }
            set{ _ssprice = value; }
        }        
			
		private decimal _lrprice;
		/// <summary>
		/// LRPrice
        /// </summary>	
        public decimal LRPrice
        {
            get{ return _lrprice; }
            set{ _lrprice = value; }
        }        
			
		private decimal _xsprice;
		/// <summary>
		/// XSPrice
        /// </summary>	
        public decimal XSPrice
        {
            get{ return _xsprice; }
            set{ _xsprice = value; }
        }        
			
		private string _fdprice;
		/// <summary>
		/// FDPrice
        /// </summary>	
        public string FDPrice
        {
            get{ return _fdprice; }
            set{ _fdprice = value; }
        }        
			
		private string _cpd;
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
			
		private string _adduser;
		/// <summary>
		/// AddUser
        /// </summary>	
        public string AddUser
        {
            get{ return _adduser; }
            set{ _adduser = value; }
        }        
			
		private string _skstate;
		/// <summary>
		/// SKState
        /// </summary>	
        public string SKState
        {
            get{ return _skstate; }
            set{ _skstate = value; }
        }        
			
		private string _cpy;
		/// <summary>
		/// CPY
        /// </summary>	
        public string CPY
        {
            get{ return _cpy; }
            set{ _cpy = value; }
        }        
			
		private string _xc;
		/// <summary>
		/// XC
        /// </summary>	
        public string XC
        {
            get{ return _xc; }
            set{ _xc = value; }
        }        
			
		private string _rs;
		/// <summary>
		/// RS
        /// </summary>	
        public string RS
        {
            get{ return _rs; }
            set{ _rs = value; }
        }        
			
		private string _ph;
		/// <summary>
		/// PH
        /// </summary>	
        public string PH
        {
            get{ return _ph; }
            set{ _ph = value; }
        }        
			
		private string _fptt;
		/// <summary>
		/// FPTT
        /// </summary>	
        public string FPTT
        {
            get{ return _fptt; }
            set{ _fptt = value; }
        }        
			
		private string _fpje;
		/// <summary>
		/// FPJE
        /// </summary>	
        public string FPJE
        {
            get{ return _fpje; }
            set{ _fpje = value; }
        }        
			
		private string _fkfs;
		/// <summary>
		/// FKFS
        /// </summary>	
        public string FKFS
        {
            get{ return _fkfs; }
            set{ _fkfs = value; }
        }        
			
		private string _customer;
		/// <summary>
		/// Customer
        /// </summary>	
        public string Customer
        {
            get{ return _customer; }
            set{ _customer = value; }
        }        
			
		private string _bz;
		/// <summary>
		/// BZ
        /// </summary>	
        public string BZ
        {
            get{ return _bz; }
            set{ _bz = value; }
        }        
			
		private string _spy;
		/// <summary>
		/// SPY
        /// </summary>	
        public string SPY
        {
            get{ return _spy; }
            set{ _spy = value; }
        }        
			
		private string _spfs;
		/// <summary>
		/// SPFS
        /// </summary>	
        public string SPFS
        {
            get{ return _spfs; }
            set{ _spfs = value; }
        }        
			
		private string _zk;
		/// <summary>
		/// ZK
        /// </summary>	
        public string ZK
        {
            get{ return _zk; }
            set{ _zk = value; }
        }        
			
		private string _subfkfs;
		/// <summary>
		/// SubFKFS
        /// </summary>	
        public string SubFKFS
        {
            get{ return _subfkfs; }
            set{ _subfkfs = value; }
        }        
			
		private decimal _ysje;
		/// <summary>
		/// YSJE
        /// </summary>	
        public decimal YSJE
        {
            get{ return _ysje; }
            set{ _ysje = value; }
        }        
			
		private decimal _ysje1;
		/// <summary>
		/// YSJE1
        /// </summary>	
        public decimal YSJE1
        {
            get{ return _ysje1; }
            set{ _ysje1 = value; }
        }        
			
		private string _fkfs1;
		/// <summary>
		/// FKFS1
        /// </summary>	
        public string FKFS1
        {
            get{ return _fkfs1; }
            set{ _fkfs1 = value; }
        }        
			
		private string _subfkfs1;
		/// <summary>
		/// SubFKFS1
        /// </summary>	
        public string SubFKFS1
        {
            get{ return _subfkfs1; }
            set{ _subfkfs1 = value; }
        }        
			
		private string _subskstate;
		/// <summary>
		/// SubSKState
        /// </summary>	
        public string SubSKState
        {
            get{ return _subskstate; }
            set{ _subskstate = value; }
        }        
			
		private string _gryh;
		/// <summary>
		/// GRYH
        /// </summary>	
        public string GRYH
        {
            get{ return _gryh; }
            set{ _gryh = value; }
        }        
			
		private string _gryh1;
		/// <summary>
		/// GRYH1
        /// </summary>	
        public string GRYH1
        {
            get{ return _gryh1; }
            set{ _gryh1 = value; }
        }        
			
		private string _fdprice1;
		/// <summary>
		/// FDPrice1
        /// </summary>	
        public string FDPrice1
        {
            get{ return _fdprice1; }
            set{ _fdprice1 = value; }
        }        
			
		private decimal _ysprice;
		/// <summary>
		/// YSPrice
        /// </summary>	
        public decimal YSPrice
        {
            get{ return _ysprice; }
            set{ _ysprice = value; }
        }        
			
		private decimal _fxprice;
		/// <summary>
		/// FXPrice
        /// </summary>	
        public decimal FXPrice
        {
            get{ return _fxprice; }
            set{ _fxprice = value; }
        }        
			
		private decimal _sjdz;
		/// <summary>
		/// SJDZ
        /// </summary>	
        public decimal SJDZ
        {
            get{ return _sjdz; }
            set{ _sjdz = value; }
        }        
			
		private decimal _jpqj;
		/// <summary>
		/// JPQJ
        /// </summary>	
        public decimal JPQJ
        {
            get{ return _jpqj; }
            set{ _jpqj = value; }
        }        
			
		private string _cw;
		/// <summary>
		/// CW
        /// </summary>	
        public string CW
        {
            get{ return _cw; }
            set{ _cw = value; }
        }        
			
		private string _ordercode;
		/// <summary>
		/// OrderCode
        /// </summary>	
        public string OrderCode
        {
            get{ return _ordercode; }
            set{ _ordercode = value; }
        }        
			
		private decimal _jiangjin;
		/// <summary>
		/// Jiangjin
        /// </summary>	
        public decimal Jiangjin
        {
            get{ return _jiangjin; }
            set{ _jiangjin = value; }
        }        
			
		private string _jjry;
		/// <summary>
		/// JJRY
        /// </summary>	
        public string JJRY
        {
            get{ return _jjry; }
            set{ _jjry = value; }
        }        
			
		private string _gpr;
		/// <summary>
		/// GPR
        /// </summary>	
        public string GPR
        {
            get{ return _gpr; }
            set{ _gpr = value; }
        }        
			
		private string _hbh;
		/// <summary>
		/// HBH
        /// </summary>	
        public string HBH
        {
            get{ return _hbh; }
            set{ _hbh = value; }
        }        
			
		private string _dprq;
		/// <summary>
		/// DPRQ
        /// </summary>	
        public string DPRQ
        {
            get{ return _dprq; }
            set{ _dprq = value; }
        }        
			
		private decimal _newfxprice;
		/// <summary>
		/// NewFXPrice
        /// </summary>	
        public decimal NewFXPrice
        {
            get{ return _newfxprice; }
            set{ _newfxprice = value; }
        }        
			
		private DateTime _skdata;
		/// <summary>
		/// SKData
        /// </summary>	
        public DateTime SKData
        {
            get{ return _skdata; }
            set{ _skdata = value; }
        }        
			
		private string _cpdxx;
		/// <summary>
		/// CPDXX
        /// </summary>	
        public string CPDXX
        {
            get{ return _cpdxx; }
            set{ _cpdxx = value; }
        }        
			
		private string _bxxx;
		/// <summary>
		/// BXXX
        /// </summary>	
        public string BXXX
        {
            get{ return _bxxx; }
            set{ _bxxx = value; }
        }        
			
		private string _fkstate;
		/// <summary>
		/// FKState
        /// </summary>	
        public string FKState
        {
            get{ return _fkstate; }
            set{ _fkstate = value; }
        }        
		   
	}
}