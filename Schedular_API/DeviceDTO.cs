using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedular_API
{
    public class DeviceDTO
    {
        public string deviceName { get; set; }
        public string macAddress { get; set; }

        public string serialNumber { get; set; }

        public string roomName { get; set; }
        public string timezone { get; set; }


    }
}