using System;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.Logging;

namespace Schedulers.Schedulers.Jobs
{
    public class Job4 : IJob
    {
        private readonly ILogger<Job4> _logger;

        public Job4(ILogger<Job4> logger)
        {
            _logger = logger;
        }

        public void Execute()
        {
            Task.Delay(TimeSpan.FromSeconds(3));
            _logger.LogInformation($"This is {nameof(Job4)}");
            //throw new Exception("This is testing exception");
        }
    }
}