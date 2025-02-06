namespace DiyarTask.Infrastructure.DI;

using DiyarTask.Application.Services.Hangfire.RecurningJobs;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Infrastructure.Persistence;
using DiyarTask.Infrastructure.Persistence.Repositories;
using DiyarTask.Infrastructure.Services.Notification.Email;
using DiyarTask.Infrastructure.Services.Notification.Sms;
using DiyarTask.Infrastructure.Services.Notification.Web;
using DiyarTask___Backup.Infrastructure.Services.Hangfire;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependenciesConfigurator
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure();
        services.AddMappingConfigurations();
        services.AddMediator();
        services.AddDataBaseServices(configuration);
        services.AddHangfireServices(configuration);
    }

    private static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INotificationService, EmailNotificationService>();
        services.AddScoped<INotificationService, SmsNotificationService>();
        services.AddScoped<INotificationService, WebNotificationService>();
        services.AddScoped<ISendReminderInvoiceDueJob, SendReminderInvoiceDueJob>();

    }

    public static void AddMappingConfigurations(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, Mapper>();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
    }

    private static void AddDataBaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DiyarDbContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
    }
}