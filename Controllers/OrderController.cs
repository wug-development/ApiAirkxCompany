using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            if (order != null)
            {
                string sql = "";
                StringBuilder strSql = new StringBuilder();
                if (order.persons.Count > 0) {
                    foreach (Person person in order.persons)
                    {
                        strSql.Append("insert into T_Passenger(");
                        strSql.Append("dcPerID,dcCompanyID,dcPerName,dcBirthday,dcPassportNo,dcPassportDate,dcSex,dcIDNumber,dcPhone,dcUrgentPhone,dcType,dtAddTime");
                        strSql.Append(") values (");
                        strSql.Append("@dcPerID,@dcCompanyID,@dcPerName,@dcBirthday,@dcPassportNo,@dcPassportDate,@dcSex,@dcIDNumber,@dcPhone,@dcUrgentPhone,@dcType,@dtAddTime");
                        strSql.Append(") ");

                        SqlParameter[] parameters = {
                            new SqlParameter("@dcPerID", SqlDbType.VarChar,40) ,
                            new SqlParameter("@dcCompanyID", SqlDbType.VarChar,40) ,
                            new SqlParameter("@dcPerName", SqlDbType.NVarChar,20) ,
                            new SqlParameter("@dcBirthday", SqlDbType.VarChar,20) ,
                            new SqlParameter("@dcPassportNo", SqlDbType.NVarChar,25) ,
                            new SqlParameter("@dcPassportDate", SqlDbType.VarChar,20) ,
                            new SqlParameter("@dcSex", SqlDbType.NVarChar,10) ,
                            new SqlParameter("@dcIDNumber", SqlDbType.VarChar,20) ,
                            new SqlParameter("@dcPhone", SqlDbType.VarChar,20) ,
                            new SqlParameter("@dcUrgentPhone", SqlDbType.VarChar,20) ,
                            new SqlParameter("@dcType", SqlDbType.Int,4) 

                        };

                        parameters[0].Value = Utils.getDataID("per");
                        parameters[1].Value = order.cid;
                        parameters[2].Value = person.PName;
                        parameters[3].Value = person.PBD;
                        parameters[4].Value = person.PHZ;
                        parameters[5].Value = person.PHZYXQ;
                        parameters[6].Value = person.PSEX;
                        parameters[7].Value = "";
                        parameters[8].Value = "";
                        parameters[9].Value = "";
                        parameters[10].Value = 1;
                    }
                }


                BLL.T_Company b_company = new BLL.T_Company();
                Model.T_Company m_company = new Model.T_Company();
                m_company = b_company.GetModel(order.cid);

                BLL.T_Order b_order = new BLL.T_Order();
                Model.T_Order o = new Model.T_Order();
                o.dcOrderID = Utils.getDataID("o");
                o.dcCompanyID = m_company.dcCompanyID;
                o.dcLinkName = m_company.dcCompanyID;



                return Utils.pubResult(1, "提交成功", "");
            }
            else
            {
                return Utils.pubResult(0, "提交失败", "");
            }
        }
        #endregion

    }
}