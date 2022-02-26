using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedular_API
{
    public class IAQDataObject
    {
        public string status { get; set; }
        public string message { get; set; }
        public DataSensor data { get; set; }


    }
    public class DataSensor
    {
        public DateTime time { get; set; }
        public List<Pollutant> pollutant { get; set; }
        public string device_id { get; set; }
        public string mac_address { get; set; }
        public string serial_number { get; set; }
    }
    public class Pollutant
    {
        public string name { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
    }
}