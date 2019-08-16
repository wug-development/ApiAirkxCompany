using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ApiAirkxCompany.Model{
	 	//T_AdminMenu
		public class T_AdminMenu
	{
   		     
      	/// <summary>
		/// dcAMID
        /// </summary>		
		private string _dcamid;
        public string dcAMID
        {
            get{ return _dcamid; }
            set{ _dcamid = value; }
        }        
		/// <summary>
		/// 管理员ID
        /// </summary>		
		private string _dcadminid;
        public string dcAdminID
        {
            get{ return _dcadminid; }
            set{ _dcadminid = value; }
        }        
		/// <summary>
		/// 菜单ID
        /// </summary>		
		private string _dcmenuid;
        public string dcMenuID
        {
            get{ return _dcmenuid; }
            set{ _dcmenuid = value; }
        }        
		   
	}
}

