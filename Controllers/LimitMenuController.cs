using LinqToDB.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAirkxCompany.Controllers
{
    public class LimitMenuController : ApiController
    {
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="obj"></param>
        /// muser: false,
        /// mregister: false,
        /// mshoukuan: false,
        /// museredit: false,
        /// muserdel: false
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SaveLimit(dynamic obj)
        {
            if (obj != null)
            {
                try
                {
                    string sql = " select * from T_Limits ";
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];

                    ArrayList sqls = new ArrayList();
                    string aid = PageValidate.SQL_KILL(obj.id.Value);
                    sqls.Add(" delete from T_AdminLimit where dcAdminID='" + aid + "' ");

                    if (obj.muser != null)
                    {
                        string id = Utils.getDataID("al");
                        if (obj.muser.muser.Value == true)
                        {
                            sqls.Add(getSql(dt, "用户管理", id + 0, aid));
                        }
                        if (obj.muser.mregister.Value == true)
                        {
                            sqls.Add(getSql(dt, "客户注册", id + 1, aid));
                        }
                        if (obj.muser.mshoukuan.Value == true)
                        {
                            sqls.Add(getSql(dt, "收款确认", id + 2, aid));
                        }
                        if (obj.muser.museredit.Value == true)
                        {
                            sqls.Add(getSql(dt, "用户编辑", id + 3, aid));
                        }
                        if (obj.muser.muserdel.Value == true)
                        {
                            sqls.Add(getSql(dt, "用户删除", id + 4, aid));
                        }
                    }
                    DbHelperSQL.ExecuteSqlTran(sqls);
                    return Utils.pubResult(1);
                }
                catch
                {
                    return Utils.pubResult(0);
                }
            }
            else
            {
                return Utils.pubResult(0);
            }
            // string s = obj.id + (Convert.ToBoolean(obj.muser.muser) ? 1 : 0) + (Convert.ToBoolean(obj.muser.mregister) ? 1 : 0);

        }

        [HttpGet]
        public HttpResponseMessage GetLimit(string id)
        {
            string _id = PageValidate.SQL_KILL(id);
            string sql = "select b.dcLimitName as name from T_AdminLimit a, T_Limits b where a.dcLimitID=b.dcLimitID and a.dcAdminID = '" + _id + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return Utils.pubResult(1, "", dt);
        }

        private string getSql(DataTable dt, string v, string id, string aid)
        {
            string lmid = findLimitID(dt, v);
            if (lmid != "")
            {
                return " insert into T_AdminLimit (dcALID,dcLimitID,dcAdminID) values ('" + id + "', '" + lmid + "', '" + aid + "')";
            }
            else
            {
                return "";
            }
        }

        private string findLimitID(DataTable dt, string v)
        {
            string _id = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (v.Trim() == dt.Rows[i]["dcLimitName"].ToString())
                {
                    _id = dt.Rows[i]["dcLimitID"].ToString();
                    break;
                }
            }
            return _id;
        }
    }
}