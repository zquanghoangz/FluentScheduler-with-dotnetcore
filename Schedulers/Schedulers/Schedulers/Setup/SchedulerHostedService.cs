using System.Threading;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Schedulers.Schedulers.Setup
{
    public class SchedulerHostedService : IHostedService
    {
        private readonly ILogger<SchedulerHostedService> _logger;
        private readonly RegistrySchedulers _registrySchedulers;
        private readonly ISchedulerService _schedulerService;

        public SchedulerHostedService(ILogger<SchedulerHostedService> logger,
            ISchedulerService schedulerService,
            RegistrySchedulers registrySchedulers)
        {
            _logger = logger;
            _registrySchedulers = registrySchedulers;
            _schedulerService = schedulerService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            JobManager.JobException += _schedulerService.JobExceptionHandler;
            JobManager.JobStart += _schedulerService.JobStartHandler;
            JobManager.JobEnd += _schedulerService.JobEndHandler;
            JobManager.Initialize(_registrySchedulers);

            _schedulerService.Initialize();

            _logger.LogInformation("Scheduler Jobs initialized.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            JobManager.Stop();
            _logger.LogInformation("Scheduler Jobs stopped.");

            return Task.CompletedTask;
        }
    }
}