using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class LimitMenuController : ApiController
    {
        // POST api/<controller>
        [HttpPost]
        public string SaveLimit(dynamic obj)
        {
            string s = obj.id + (Convert.ToBoolean(obj.muser.muser) ? 1 : 0) + (Convert.ToBoolean(obj.muser.mregister) ? 1 : 0);
            return s;
        }
    }
}