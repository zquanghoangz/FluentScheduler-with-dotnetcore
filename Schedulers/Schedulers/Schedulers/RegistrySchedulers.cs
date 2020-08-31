using System;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Schedulers.Schedulers.Jobs;
using Schedulers.Schedulers.Setup;

namespace Schedulers.Schedulers
{
    public class RegistrySchedulers : Registry
    {
        private readonly IServiceProvider _serviceProvider;

        public RegistrySchedulers(IServiceProvider serviceProvider, Job4 job4)
        {
            _serviceProvider = serviceProvider;

            Schedule<ThisIsALongLongLongNameOfSchedulerJob>().WithDescription("To run every 5 seconds")
                .ToRunEvery(5).Seconds();

            Schedule<Job2>().WithDescription("To run once started").ToRunNow();

            Schedule<Job3>().WithDescription("To run once at 15:55:00")
                .ToRunOnceAt(15, 55);

            Schedule(job4).WithName(job4.GetType().Name).WithDescription("To run every 10 seconds")
                .ToRunEvery(10).Seconds();

            //NOTE: Register new Job here..
        }

        private new Schedule Schedule<T>() where T : IJob
        {
            return Schedule(_serviceProvider.GetService<T>())
                .WithName(typeof(T).Name);
        }
    }
}