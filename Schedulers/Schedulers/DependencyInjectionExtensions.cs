using Microsoft.Extensions.DependencyInjection;
using Schedulers.Schedulers;
using Schedulers.Schedulers.Jobs;
using Schedulers.Schedulers.Setup;

namespace Schedulers
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterSchedulers(this IServiceCollection services)
        {
            services.AddHostedService<SchedulerHostedService>();

            services.AddTransient<RegistrySchedulers>();

            services.AddTransient<ThisIsALongLongLongNameOfSchedulerJob>();
            services.AddTransient<Job2>();
            services.AddTransient<Job3>();
            services.AddTransient<Job4>();

            services.AddSingleton<ISchedulerService, SchedulerService>();
        }
    }
}