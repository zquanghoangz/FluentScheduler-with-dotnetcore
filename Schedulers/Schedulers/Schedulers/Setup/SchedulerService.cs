using System.Collections.Generic;
using System.Linq;
using FluentScheduler;
using Microsoft.Extensions.Logging;
using Schedulers.Schedulers.Setup.Models;

namespace Schedulers.Schedulers.Setup
{
    public interface ISchedulerService
    {
        void Initialize();
        void JobStartHandler(JobStartInfo info);
        void JobEndHandler(JobEndInfo info);
        void JobExceptionHandler(JobExceptionInfo info);
        SchedulerDashboardViewModel GetViewModel();
    }

    public class SchedulerService : ISchedulerService
    {
        private readonly ILogger<SchedulerService> _logger;
        private SchedulerDashboardViewModel _viewModel = new SchedulerDashboardViewModel();

        public SchedulerService(ILogger<SchedulerService> logger)
        {
            _logger = logger;
        }

        public void Initialize()
        {
            var schedules = (JobManager.AllSchedules?.ToList() ?? new List<Schedule>())
                .Concat(JobManager.RunningSchedules?.ToList() ?? new List<Schedule>());

            _viewModel = new SchedulerDashboardViewModel
            {
                Models = schedules.Select(x => new SchedulerDashboardModel(x)).ToList()
            };
        }

        public void JobStartHandler(JobStartInfo info)
        {
            GetSchedulerDashboardModel(info.Name)?.UpdateForStarted(info);

            _logger.LogInformation($"{info.Name}: started");
        }

        public void JobEndHandler(JobEndInfo info)
        {
            GetSchedulerDashboardModel(info.Name)?.UpdateForEnded(info);

            _logger.LogInformation($"{info.Name}: ended ({info.Duration})");
        }

        public void JobExceptionHandler(JobExceptionInfo info)
        {
            GetSchedulerDashboardModel(info.Name)?.UpdateForException(info);

            _logger.LogError($"{info.Name}: exception {info.Exception}");
        }

        public SchedulerDashboardViewModel GetViewModel()
        {
            return _viewModel;
        }

        private SchedulerDashboardModel GetSchedulerDashboardModel(string name)
        {
            return _viewModel.Models?.FirstOrDefault(x => x.Name == name);
        }
    }
}
