# Schedulers with FluentScheduler
Documentation https://github.com/fluentscheduler/FluentScheduler

## Steps to create new Job
1. Create a new job in **Schedulers > Jobs**, make sure to inherit from **IJob**
2. Register dependency injection for new job in **DependencyInjectionExtensions.cs**
3. Register scheduler for new job in **RegistrySchedulers.cs**

