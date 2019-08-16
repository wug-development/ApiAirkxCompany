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
        // 乘机人
        public List<Person> persons { get; set; }
        // 航班信息
        public AirInfo airinfo { get; set; }
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
}