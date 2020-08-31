using System;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.Logging;

namespace Schedulers.Schedulers.Jobs
{
    public class Job3 : IJob
    {
        private readonly ILogger<Job3> _logger;

        public Job3(ILogger<Job3> logger)
        {
            _logger = logger;
        }

        public void Execute()
        {
            Task.Delay(TimeSpan.FromSeconds(3));
            _logger.LogInformation($"This is {nameof(Job3)}");
        }
    }
}