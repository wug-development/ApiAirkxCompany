using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class OrderController : ApiController
    {
        #region 提交国际订单
        /// <summary>
        /// 提交国际订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public HttpResponseMessage SubmitOrder([FromBody] OrderBody order)
        {
            return Utils.pubResult(0, "获取失败", "");
        }
        #endregion
    }
}