using System;
using FluentScheduler;

namespace Schedulers.Schedulers.Setup.Models
{
    public class SchedulerDashboardModel
    {
        public SchedulerDashboardModel(Schedule schedule)
        {
            Name = schedule.Name;
            Description = GetDescription(schedule.Name);
            StartTime = DateTime.MinValue;
            Duration = TimeSpan.Zero;
            NextRun = schedule.NextRun;
            IsDisabled = schedule.Disabled;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime NextRun { get; set; }

        public Exception Exception { get; set; }

        public bool IsDisabled { get; set; }

        public bool IsRunning { get; set; }

        public SchedulerStatus Status
        {
            get
            {
                if (Exception != null) return SchedulerStatus.Error;

                if (NextRun == DateTime.MinValue) return SchedulerStatus.Done;

                if (IsRunning) return SchedulerStatus.Running;

                return IsDisabled ? SchedulerStatus.Disabled : SchedulerStatus.Alive;
            }
        }

        private string GetDescription(string name)
        {
            return SchedulerExtensions.DescriptionMapping.ContainsKey(name)
                ? SchedulerExtensions.DescriptionMapping[name]
                : string.Empty;
        }

        public void UpdateForStarted(JobStartInfo info)
        {
            IsRunning = true;
            StartTime = info.StartTime;
            Exception = null;
        }

        public void UpdateForEnded(JobEndInfo info)
        {
            IsRunning = false;
            StartTime = info.StartTime;
            Duration = info.Duration;
            if (info.NextRun != null) NextRun = info.NextRun.Value;
        }

        public void UpdateForException(JobExceptionInfo info)
        {
            Exception = info.Exception;
        }
    }

    public enum SchedulerStatus
    {
        Alive,
        Running,
        Error,
        Done,
        Disabled
    }
}