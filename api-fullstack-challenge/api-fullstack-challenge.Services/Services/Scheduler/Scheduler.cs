using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Services.Services.Scheduler
{
    public static class Scheduler
    {
        public static Task Schedule()
        {
            IScheduler scheduler = GetScheduler();
            scheduler.Start();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger")
                .StartNow()
                .WithPriority(1)
                .WithCronSchedule("0 00 14 * * ?")
                .Build();

            IJobDetail job = JobBuilder.Create<MyJob>()
                .WithIdentity("myJob")
                .Build();

            scheduler.ScheduleJob(job, trigger);

            return Task.FromResult(0);
        }

        private static IScheduler GetScheduler()
        {
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "QuartzWithCore",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "3",
                ["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz",
            };
            var schedulerFactory = new StdSchedulerFactory(properties);
            var scheduler = schedulerFactory.GetScheduler();
            //await scheduler.Start();                                                                                  
            return scheduler.Result;
        }
    }
}
