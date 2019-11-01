using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAirkxCompany
{
    public class OrderBody
    {
        public OrderBody() { }

        // 企业ID
        public string cid { get; set; }
        // 企业名称
        public string cname { get; set; }
        // 乘机人
        public List<Person> persons { get; set; }
        // 乘机人
        public List<PersonList> personlist { get; set; }
        // 国际航班信息
        public AirInfo airinfo { get; set; }
        // 出发日期
        public string sdate { get; set; }
        // 出发城市
        public AirPort scity { get; set; }
        // 到达城市
        public AirPort ecity { get; set; }
        // 国内航班信息
        public getAvailableFlightWithPriceAndCommision.wsFlightWithPriceAndCommision airbody { get; set; }
        // 国内航班舱位信息
        public getAvailableFlightWithPriceAndCommision.wsSeatWithPriceAndComisionItem airseat { get; set; }        
        
    }

    public class Person
    {
        public Person() { }
        //联系人
        public string PName { get; set; }
        public string PCode { get; set; }        
        //性别
        public string PSEX { get; set; }
        //护照号码
        public string PHZ { get; set; }
        //护照有效期
        public string PHZYXQ { get; set; }
        //出生日期
        public string PBD { get; set; }
        //身份证
        public string SFZ { get; set; }
        //类型1成人 0儿童
        public string PTYPE { get; set; }
        //id
        public string ID { get; set; }
        //航班 id
        public string FlightID { get; set; }
    }
    
    public class Persons
    {
        public Persons() { }
        //联系人
        public string CjrName { get; set; }
        //性别
        public string Sex { get; set; }
        //护照号码
        public string HZH { get; set; }
        //护照有效期
        public string HZYXQ { get; set; }
        //出生日期
        public string CSRQ { get; set; }
        //身份证
        public string idcard { get; set; }
        //类型1成人 0儿童
        public string type { get; set; }
        //id
        public string id { get; set; }
        //电话
        public string phone { get; set; }
        //紧急电话
        public string jingji { get; set; }
    }
    public class PersonList
    {
        public PersonList() { }
        //联系人
        public string name { get; set; }
        //性别
        public string sex { get; set; }
        //护照号码
        public string hzh { get; set; }
        //护照有效期
        public string hzyxq { get; set; }
        //出生日期
        public string csrq { get; set; }
        //身份证
        public string idcard { get; set; }
        //类型1成人 2儿童
        public string type { get; set; }
        //id
        public string id { get; set; }
        //电话
        public string phone { get; set; }
        //紧急电话
        public string jjphone { get; set; }
    }

    public class AirInfo
    {
        public AirInfo() { }
        // 航线类型 1往返 0直飞
        public int airtype { get; set; }
        // 出发日期
        public string startDate { get; set; }
        // 返回日期
        public string backDate { get; set; }
        // 出发城市
        public string startCity { get; set; }
        // 目的地城市
        public string backCity { get; set; }
        // 去程航班信息
        public FlightInfo flightInfo { get; set; }
        // 回程航班信息
        public FlightInfo backFlightInfo { get; set; }
    }
    public class AirBody
    {
        public AirBody() { }
        // 航线类型 1往返 0直飞
        public int airtype { get; set; }
        // 出发日期
        public string startDate { get; set; }
        // 返回日期
        public string backDate { get; set; }
        // 出发城市
        public string startCity { get; set; }
        // 目的地城市
        public string backCity { get; set; }
        // 去程航班信息
        public FlightInfo flightInfo { get; set; }
    }

    public class FlightInfo
    {
        public FlightInfo() { }
        // 航班ID
        public int airID { get; set; }
        // 机票ID
        public int ticketID { get; set; }
        // 机票价格ID
        public int detailID { get; set; }
        // 转机IDS
        public int[] toFlightInfo { get; set; }
    }

    public class DZOrderBody
    {
        //定制行程内容
        public string content { get; set; }
        //企业 ID
        public string cid { get; set; }
    }

    public class AirPort
    {
        public int id { get; set; }
        public string airportname { get; set; }
        public string code { get; set; }
        public string country { get; set; }
        public string enname { get; set; }
        public string name { get; set; }
    }
}