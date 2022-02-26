using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedular_API
{
    public class Datum
    {
        public int virusIndex { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public int pm25 { get; set; }
        public int tvoc { get; set; }
        public int co2 { get; set; }
        public double co { get; set; }
        public double airPressure { get; set; }
        public int ozone { get; set; }
        public int no2 { get; set; }
        public int pm1 { get; set; }
        public int pm4 { get; set; }
        public int pm10 { get; set; }
        public int ch2o { get; set; }
        public int light { get; set; }
        public int sound { get; set; }
        public int timestamp { get; set; }
    }

    public class Usersettings
    {
        public string temperature { get; set; }
        public string temp { get; set; }
        public string humidity { get; set; }
        public string pm25 { get; set; }
        public string dust { get; set; }
        public string tvoc { get; set; }
        public string voc { get; set; }
        public string co2 { get; set; }
        public string co { get; set; }
        public string airPressure { get; set; }
        public string pressure { get; set; }
        public string ozone { get; set; }
        public string no2 { get; set; }
        public string pm1 { get; set; }
        public string pm4 { get; set; }
        public string pm10 { get; set; }
        public string ch2o { get; set; }
        public string light { get; set; }
        public string sound { get; set; }
    }

    public class Root
    {
        //public List<Datum> data { get; set; }
        public List<Dictionary<string, object>> data { get; set; }
        public Dictionary<string, object> usersettings { get; set; }
    }
}