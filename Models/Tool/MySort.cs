using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAirkxCompany
{
    public class MySort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
            // int iResult = (int)x - (int)y;
            // if(iResult == 0) iResult = -1;
            // return iResult;
        }

    }
}