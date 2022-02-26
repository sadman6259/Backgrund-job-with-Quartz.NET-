using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Schedular_API.Services
{
    public class IAQData : IJob
    {
        
        private readonly bool isIAQDataProcessingOn = Convert.ToBoolean(ConfigurationManager.AppSettings["IsIAQDataProcessingOn"]);
        CredentialsDTO credentials = new CredentialsDTO();
        List<DeviceDTO> devices = new List<DeviceDTO>();
        Root r = new Root();
        DateTime tokenexpirationtime = new DateTime();
    
        public void Execute(IJobExecutionContext context)
        {
           
            try
            {
                if (isIAQDataProcessingOn && DateTime.Now < tokenexpirationtime && tokenexpirationtime != new DateTime())
                {
                    StartProcessWithoutToken();
                }
                else
                {
                    tokenexpirationtime = DateTime.Now.AddMinutes(10);
                    StartProcessWithToken();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async void StartProcessWithToken()
        {

            var dict = new Dictionary<string, string>();
            dict.Add("code", ConfigurationManager.AppSettings["ClientId"]);

           
              //create token
                var client = new HttpClient();
                var req = new HttpRequestMessage(HttpMethod.Post, ConfigurationManager.AppSettings["CreateTokenUrl"]) { Content = new FormUrlEncodedContent(dict) };
                var res = await client.SendAsync(req);
                if (res.IsSuccessStatusCode)
                {
                   // tokenexpirationtime = DateTime.Now.AddMinutes(10);

                    //cookie["tokenexpirationtime"].Value = DateTime.Now.AddMinutes(10);
                    var responsedata = res.Content.ReadAsStringAsync().Result;
                    credentials = new JavaScriptSerializer().Deserialize<CredentialsDTO>(responsedata);
                }

                if (!String.IsNullOrEmpty(credentials.access_token))
                {
                    await GetdevicesData();
                }
            
          
        }
        public async void StartProcessWithoutToken()
        {
           await GetdevicesData();
        }
        public async Task GetdevicesData()
        {
            IAQDataObject iaqdata = new IAQDataObject();
            List<Pollutant> pollutants = new List<Pollutant>();
            Pollutant pollutantitem = new Pollutant();
            DataSensor datasensoritem = new DataSensor();
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Dictionary<string, object> unitDictionary = new Dictionary<string, object>();
            Dictionary<string, object> valueDictionary = new Dictionary<string, object>();
            List<SensorDevice> devices = new List<SensorDevice>();
            var singapore = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");


            //get device list
            using (var db = new sbn_cwDBEntities())
            {
                devices = db.SensorDevices.Where(x => (x.BuildingId == "cw") && (x.Type == "IAQ")).ToList();
            }


            if (devices.Count > 0)
            {
                foreach (var item in devices)
                {
                    var dict = new Dictionary<string, string>();
                    dict.Add("macAddress", item.MacAddress);
                    dict.Add("mode", ConfigurationManager.AppSettings["IAQMode"]);

                    // get device data
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization","Bearer "+ credentials.access_token);
                    var req = new HttpRequestMessage(HttpMethod.Post, ConfigurationManager.AppSettings["DeviceDataListUrl"]) { Content = new FormUrlEncodedContent(dict) };
                    var res = await client.SendAsync(req);
                    if (res.IsSuccessStatusCode)
                    {
                        var responsedata = res.Content.ReadAsStringAsync().Result;
                        r = new JavaScriptSerializer().Deserialize<Root>(responsedata);


                        iaqdata.status = "OK";
                        iaqdata.message = "successfully retrived";

                        using (var db = new sbn_cwDBEntities())
                        {
                            var device = db.SensorDevices.Where(x => x.MacAddress == item.MacAddress).FirstOrDefault();
                            datasensoritem.device_id = device.Id.ToString();
                        }
                        

                        datasensoritem.mac_address = item.MacAddress;
                        datasensoritem.serial_number = item.SerialNumber;

                        iaqdata.data = datasensoritem;

                        valueDictionary = r.data[0].Where(pair => pair.Key == "timestamp").ToDictionary(p => p.Key, p => p.Value);

                        if (valueDictionary.Count > 0)
                        {
                            dateTime = dateTime.AddSeconds(Convert.ToDouble(valueDictionary.FirstOrDefault().Value)).ToLocalTime();
                            
                        }
                        else
                        {
                            dateTime = DateTime.Now;
                        }
                        iaqdata.data.time = dateTime;

                        if (r != null)
                        {
                            foreach (var itemdata in r.data[0])
                            {

                                pollutantitem.name = itemdata.Key;
                                pollutantitem.value = Convert.ToDouble(itemdata.Value);
                                unitDictionary = r.usersettings.Where(pair => pair.Key == itemdata.Key).ToDictionary(p => p.Key, p => p.Value);
                                if (unitDictionary.Count > 0)
                                {
                                    pollutantitem.unit = unitDictionary.FirstOrDefault().Value.ToString();
                                }
                                else
                                {
                                    pollutantitem.unit = null;
                                }

                                pollutants.Add(pollutantitem);
                                pollutantitem = new Pollutant();
                            }

                            iaqdata.data.pollutant = pollutants;
                            iaqdata.data.pollutant = iaqdata.data.pollutant.Where(x => x.name != "timestamp").ToList();

                        }

                    }
                    //  iaqdata.data.time = TimeZoneInfo.ConvertTimeFromUtc(iaqdata.data.time.ToUniversalTime(), singapore);
                    InsertIAQData(iaqdata);
                    iaqdata = new IAQDataObject();
                    pollutants = new List<Pollutant>();
                    pollutantitem = new Pollutant();
                    datasensoritem = new DataSensor();
                    unitDictionary = new Dictionary<string, object>();
                    valueDictionary = new Dictionary<string, object>();
                    devices = new List<SensorDevice>();
                    dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                }



            }
           // return iaqdata;
        }

        private void InsertIAQData(IAQDataObject dataObject)
        {
            try
            {
                using (var db = new sbn_cwDBEntities())
                {
                    var data = dataObject.data;
                    int deviceId = Convert.ToInt32(data.device_id);

                    if (data != null)
                    {

                        var device = db.SensorDevices.Where(x => x.Id == deviceId).FirstOrDefault();
                        var singapore = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");

                        #region Add data to List

                        var iaqReadings = (from d in data.pollutant
                                           select new IAQReading
                                           {
                                               DeviceFkId = device.Id,
                                               Name = d.name,
                                               Unit = d.unit,
                                               Value = d.value,
                                               //Timestamp = data.time,
                                               Timestamp = TimeZoneInfo.ConvertTimeFromUtc(data.time.ToUniversalTime(), singapore)
                                           }).ToList();

                        foreach(var item in iaqReadings)
                        {
                            if(String.IsNullOrEmpty(item.Unit))
                            {
                                item.Unit = "none";
                            }
                            db.IAQReadings.Add(item);
                            db.SaveChanges();

                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
            
            }
        }

    }
}