using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAirkxCompany
{
    public class Company
    {
        public Company()
        { }
        public string companyid { get; set; }// 企业ID
        public string comShorthand { get; set; }//企业简称（账号）
        public string comPass { get; set; }//登录密码
        public string billfields { get; set; }//账单字段
        public CompanyInfo comInfo { get; set; }//企业信息
        public List<LinkMan> linkman { get; set; } //联系人
        public List<SubCompany> subcompany { get; set; } //子公司
    }

    public class SubCompany
    {
        public string cid { get; set; }// 分公司ID
        public string comShorthand { get; set; }// 分公司简称（账号）
        public string comPass { get; set; }// 登录密码
        public string other { get; set; }// 备注
        public LinkMan linkmanList { get; set; }// 联系人
    }

    public class LinkMan
    {
        public string name { get; set; }// 联系人
        public string phone { get; set; }// 联系电话
        public string email { get; set; }// 邮箱
        public string qq { get; set; }// QQ
        public string wechart { get; set; }// 微信号
    }

    //企业信息
    public class CompanyInfo
    {
        public string nickname { get; set; }// 企业全称
        public string reno { get; set; }//注册号
        public string remoney { get; set; }//注册资金
        public string readdr { get; set; }//实际经营地址
        public string business { get; set; }//主营业务
        public string shareholder { get; set; }//股东明细
        public string legal { get; set; }//法人代表
        public string licenseAddr { get; set; }//执照注册地址
        public string bankAccount { get; set; }//银行账号
        public string bankName { get; set; }//开户行
        public string credit { get; set; }//信用额度
        public string servicePirce { get; set; }//服务费
        public string settleDate { get; set; }//结账日期
        public Manager manager { get; set; }//管理员
        public string other { get; set; }//备注
    }

    //管理员
    public class Manager
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Passenger
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string jjphone { get; set; }
        public string idcard { get; set; }
        public string hzh { get; set; }
        public string hzyxq { get; set; }
    }
}