using Microsoft.EntityFrameworkCore;
using Quartz;
using Woker.Contracts.Repositories;
using Woker.Jobs;
using Woker.Options;
using Woker.Persistence;
using Woker.Persistence.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<WokerDbContext>(options =>
        {
            options.UseNpgsql(context.Configuration.GetConnectionString("DbConnectionString"));
        });
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            var jobKey = new JobKey("DeleteLogsJob");

            q.AddJob<DeleteLogsJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
            .ForJob(jobKey)
            .WithIdentity($"{jobKey}-trigger")
            .WithCronSchedule(context.Configuration.GetSection("DeleteLogsJob:CronSchedule").Value ?? "0/5 * * * * ?"));
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.Configure<DeleteLogsJobOptions>(
            context.Configuration.GetSection(DeleteLogsJobOptions.DeleteLogsJob));
        services.AddScoped<ILogRepository, LogRepository>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<WokerDbContext>();

if (dbContext != null)
{
    Seeder.Seed(dbContext);
}
host.Run();