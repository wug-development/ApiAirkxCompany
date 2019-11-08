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
        public AirFlightBody airbody { get; set; }
        // 国内航班舱位信息
        public SeatItem airseat { get; set; }
        
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
        
        private string _name = "";
        private string _sex = "";
        private string _hzh = "";
        private string _hzyxq = "";
        private string _csrq = "";
        private string _idcard = "";
        private string _type = "";
        private string _id = "";
        private string _phone = "";
        private string _jjphone = "";

        //联系人
        public string name { get => _name; set => _name = value; }
        //性别
        public string sex { get => _sex; set => _sex = value; }
        //护照号码
        public string hzh { get => _hzh; set => _hzh = value; }
        //护照有效期
        public string hzyxq { get => _hzyxq; set => _hzyxq = value; }
        //出生日期
        public string csrq { get => _csrq; set => _csrq = value; }
        //身份证
        public string idcard { get => _idcard; set => _idcard = value; }
        //类型1成人 2儿童
        public string type { get => _type; set => _type = value; }
        //id
        public string id { get => _id; set => _id = value; }
        //电话
        public string phone { get => _phone; set => _phone = value; }
        //紧急电话
        public string jjphone { get => _jjphone; set => _jjphone = value; }
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

    public class AirFlightBody
    {
        private double _airportTax = 0;

        private bool _airportTaxSpecified = false;

        private string _arriModifyTime = "";

        private string _arriTime = "";

        private bool _codeShare = false;

        private bool _codeShareSpecified = false;

        private string _depModifyTime = "";

        private string _depTime = "";

        private string _dstCity = "";

        private string _dstJetquay = "";

        private string _flightNo = "";

        private double _fuelTax = 0;

        private bool _fuelTaxSpecified = false;

        private bool _isElectronicTicket = false;

        private bool _isElectronicTicketSpecified = false;

        private string _link = "";

        private string _meal = "";

        private string _orgCity = "";

        private string _orgJetquay = "";

        private string _param1 = "";

        private string _param2 = "";

        private string _param3 = "";

        private string _param4 = "";

        private string _planeType = "";

        private SeatItem[] _seatItems;

        private string _shareNum = "";

        private int _stopnum = 0;

        private bool _stopnumSpecified = false;

        public double airportTax { get => _airportTax; set => _airportTax = value; }
        public bool airportTaxSpecified { get => _airportTaxSpecified; set => _airportTaxSpecified = value; }
        public string arriModifyTime { get => _arriModifyTime; set => _arriModifyTime = value; }
        public string arriTime { get => _arriTime; set => _arriTime = value; }
        public bool codeShare { get => _codeShare; set => _codeShare = value; }
        public bool codeShareSpecified { get => _codeShareSpecified; set => _codeShareSpecified = value; }
        public string depModifyTime { get => _depModifyTime; set => _depModifyTime = value; }
        public string depTime { get => _depTime; set => _depTime = value; }
        public string dstCity { get => _dstCity; set => _dstCity = value; }
        public string dstJetquay { get => _dstJetquay; set => _dstJetquay = value; }
        public string flightNo { get => _flightNo; set => _flightNo = value; }
        public double fuelTax { get => _fuelTax; set => _fuelTax = value; }
        public bool fuelTaxSpecified { get => _fuelTaxSpecified; set => _fuelTaxSpecified = value; }
        public bool isElectronicTicket { get => _isElectronicTicket; set => _isElectronicTicket = value; }
        public bool isElectronicTicketSpecified { get => _isElectronicTicketSpecified; set => _isElectronicTicketSpecified = value; }
        public string link { get => _link; set => _link = value; }
        public string meal { get => _meal; set => _meal = value; }
        public string orgCity { get => _orgCity; set => _orgCity = value; }
        public string orgJetquay { get => _orgJetquay; set => _orgJetquay = value; }
        public string param1 { get => _param1; set => _param1 = value; }
        public string param2 { get => _param2; set => _param2 = value; }
        public string param3 { get => _param3; set => _param3 = value; }
        public string param4 { get => _param4; set => _param4 = value; }
        public string planeType { get => _planeType; set => _planeType = value; }
        public SeatItem[] seatItems { get => _seatItems; set => _seatItems = value; }
        public string shareNum { get => _shareNum; set => _shareNum = value; }
        public int stopnum { get => _stopnum; set => _stopnum = value; }
        public bool stopnumSpecified { get => _stopnumSpecified; set => _stopnumSpecified = value; }
    }

    public class SeatItem
    {
        private double _discount = 0;

        private bool _discountSpecified = false;

        private string _flightNo = "";

        private int _parPrice = 0;

        private bool _parPriceSpecified = false;

        private string _param1 = "";

        private string _param2 = "";

        private string _param3 = "";

        private string _param4 = "";

        private string _seatCode = "";

        private string _seatMsg = "";

        private string _seatStatus = "";

        private int _seatType = 0;

        private bool _seatTypeSpecified = false;

        private double _settlePrice = 0;

        private bool _settlePriceSpecified = false;

        public double discount { get => _discount; set => _discount = value; }
        public bool discountSpecified { get => _discountSpecified; set => _discountSpecified = value; }
        public string flightNo { get => _flightNo; set => _flightNo = value; }
        public int parPrice { get => _parPrice; set => _parPrice = value; }
        public bool parPriceSpecified { get => _parPriceSpecified; set => _parPriceSpecified = value; }
        public string param1 { get => _param1; set => _param1 = value; }
        public string param2 { get => _param2; set => _param2 = value; }
        public string param3 { get => _param3; set => _param3 = value; }
        public string param4 { get => _param4; set => _param4 = value; }
        public string seatCode { get => _seatCode; set => _seatCode = value; }
        public string seatMsg { get => _seatMsg; set => _seatMsg = value; }
        public string seatStatus { get => _seatStatus; set => _seatStatus = value; }
        public int seatType { get => _seatType; set => _seatType = value; }
        public bool seatTypeSpecified { get => _seatTypeSpecified; set => _seatTypeSpecified = value; }
        public double settlePrice { get => _settlePrice; set => _settlePrice = value; }
        public bool settlePriceSpecified { get => _settlePriceSpecified; set => _settlePriceSpecified = value; }
    }
}