using Quartz;
using Quartz.Impl;
using Schedular_API.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Schedular_API
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            #region Sensor data
            bool isIAQDataProcessingOn = Convert.ToBoolean(ConfigurationManager.AppSettings["IsIAQDataProcessingOn"]);

            #region IAQ sensor

            if (isIAQDataProcessingOn)
            {
                int IAQInterval = Convert.ToInt32(ConfigurationManager.AppSettings["IAQJobInervalInMinute"]);

                IJobDetail IAQJob = JobBuilder.Create<IAQData>().WithIdentity("IAQSensorJob").Build();

                ITrigger IAQSensorTrigger = TriggerBuilder.Create().WithIdentity("IAQSensorJobTrigger")
                    .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(IAQInterval)
                        .RepeatForever())
                    .ForJob(IAQJob)
                    .Build();

                scheduler.ScheduleJob(IAQJob, IAQSensorTrigger);
            }
            #endregion
        }
        #endregion

    }
}