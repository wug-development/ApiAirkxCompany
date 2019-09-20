using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAirkxCompany
{
    public class PayRecordBody
    {
        public PayRecordBody() { }

        public decimal money { get; set; }
        public string payType { get; set; }
        public string cid { get; set; }
        public Manager manage { get; set; }
        public string date { get; set; }
        public string other { get; set; }

    }
}