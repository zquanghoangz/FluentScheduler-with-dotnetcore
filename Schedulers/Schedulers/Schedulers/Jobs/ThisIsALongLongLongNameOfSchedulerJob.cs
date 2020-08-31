using System;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.Logging;

namespace Schedulers.Schedulers.Jobs
{
    public class ThisIsALongLongLongNameOfSchedulerJob : IJob
    {
        private readonly ILogger<ThisIsALongLongLongNameOfSchedulerJob> _logger;

        public ThisIsALongLongLongNameOfSchedulerJob(ILogger<ThisIsALongLongLongNameOfSchedulerJob> logger)
        {
            _logger = logger;
        }

        public void Execute()
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            _logger.LogInformation($"This is {nameof(ThisIsALongLongLongNameOfSchedulerJob)}");
        }
    }
}
