using System;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.Logging;

namespace Schedulers.Schedulers.Jobs
{
    public class Job2 : IJob
    {
        private readonly ILogger<Job2> _logger;

        public Job2(ILogger<Job2> logger)
        {
            _logger = logger;
        }

        public void Execute()
        {
            Task.Delay(TimeSpan.FromSeconds(2));
            _logger.LogInformation($"This is {nameof(Job2)}");
        }
    }
}