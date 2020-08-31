using System.Collections.Generic;
using FluentScheduler;

namespace Schedulers.Schedulers.Setup
{
    public static class SchedulerExtensions
    {
        public static Dictionary<string, string> DescriptionMapping = new Dictionary<string, string>();

        public static Schedule WithDescription(this Schedule schedule, string description)
        {
            DescriptionMapping[schedule.Name] = description;
            return schedule;
        }
    }
}