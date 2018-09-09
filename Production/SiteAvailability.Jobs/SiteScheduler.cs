using Quartz;
using Quartz.Impl;

namespace SiteAvailability.Jobs
{
    public class SiteScheduler
    {
        private static IScheduler _scheduler;
        private static ITrigger _trigger;
        private static IJobDetail _job;

        public static async void Start()
        {
            _scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await _scheduler.Start();

            _job = JobBuilder.Create<SiteChecker>().Build();

            _trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger1", "group1")    
                .StartNow()                     
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)          
                    .RepeatForever())   
                .ForJob(_job)
                .Build();

            await _scheduler.ScheduleJob(_job, _trigger);
        }

        public static void StartNow()
        {
            _trigger.GetTriggerBuilder().StartNow();
        }

        public static void ChangePeriod(int period)
        {
            _trigger = _trigger.GetTriggerBuilder().WithSimpleSchedule(x => x
                .WithIntervalInMinutes(period)
                .RepeatForever()).Build();
        }

    }
}
