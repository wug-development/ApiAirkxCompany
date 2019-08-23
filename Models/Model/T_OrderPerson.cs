using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_OrderPerson
		public class T_OrderPerson
	{
   		     
      	/// <summary>
		/// 订单乘客ID
        /// </summary>		
		private string _dcopid;
        public string dcOPID
        {
            get{ return _dcopid; }
            set{ _dcopid = value; }
        }        
		/// <summary>
		/// 订单ID
        /// </summary>		
		private string _dcorderid;
        public string dcOrderID
        {
            get{ return _dcorderid; }
            set{ _dcorderid = value; }
        }        
		/// <summary>
		/// 乘客姓名
        /// </summary>		
		private string _dcpername;
        public string dcPerName
        {
            get{ return _dcpername; }
            set{ _dcpername = value; }
        }        
		/// <summary>
		/// 出生日期
        /// </summary>		
		private string _dcbirthday;
        public string dcBirthday
        {
            get{ return _dcbirthday; }
            set{ _dcbirthday = value; }
        }        
		/// <summary>
		/// 护照号
        /// </summary>		
		private string _dcpassportno;
        public string dcPassportNo
        {
            get{ return _dcpassportno; }
            set{ _dcpassportno = value; }
        }        
		/// <summary>
		/// 护照有效期
        /// </summary>		
		private string _dcpassportdate;
        public string dcPassportDate
        {
            get{ return _dcpassportdate; }
            set{ _dcpassportdate = value; }
        }        
		/// <summary>
		/// 性别
        /// </summary>		
		private string _dcsex;
        public string dcSex
        {
            get{ return _dcsex; }
            set{ _dcsex = value; }
        }        
		/// <summary>
		/// 身份证号码
        /// </summary>		
		private string _dcidnumber;
        public string dcIDNumber
        {
            get{ return _dcidnumber; }
            set{ _dcidnumber = value; }
        }        
		/// <summary>
		/// 联系人手机号
        /// </summary>		
		private string _dcphone;
        public string dcPhone
        {
            get{ return _dcphone; }
            set{ _dcphone = value; }
        }        
		/// <summary>
		/// 紧急联系人手机号
        /// </summary>		
		private string _dcurgentphone;
        public string dcUrgentPhone
        {
            get{ return _dcurgentphone; }
            set{ _dcurgentphone = value; }
        }        
		/// <summary>
		/// 乘客类型(1成人2儿童)
        /// </summary>		
		private int _dctype;
        public int dcType
        {
            get{ return _dctype; }
            set{ _dctype = value; }
        }        
		   
	}
}

