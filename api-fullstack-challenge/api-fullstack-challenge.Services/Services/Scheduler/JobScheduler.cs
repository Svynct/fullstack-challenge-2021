using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Services.Services.Scheduler
{
    public class JobScheduler : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        { 
            StdSchedulerFactory factory = new StdSchedulerFactory();

            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<MyJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithCronSchedule("0 00 14 * * ?", x => x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central Brazilian Standard Time")))
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
