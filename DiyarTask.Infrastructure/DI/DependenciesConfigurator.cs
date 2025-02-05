namespace DiyarTask.Infrastructure.DI;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Infrastructure.Persistence;
using DiyarTask.Infrastructure.Persistence.Repositories;

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
    }

    private static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
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