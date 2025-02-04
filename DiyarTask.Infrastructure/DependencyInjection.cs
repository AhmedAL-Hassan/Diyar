using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Infrastructure.Persistence.Repositories;
using DiyarTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;
using DiyarTask.Domain.Core.Configs;

namespace DiyarTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }

        public static IServiceCollection AddMappingConfigurations(this IServiceCollection services)
        {
            // Register custom Mapster mappings
            MapsterMapperConfig.RegisterMappings();

            // Register Mapster's IMapper
            services.AddSingleton<IMapper, Mapper>();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").ToString();
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString, ops =>
               {
                   ops.EnableRetryOnFailure(3, TimeSpan.FromSeconds(60), null);
                   ops.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                   //ops.MigrationsHistoryTable(HistoryRepository.DefaultTableName, currentTenant.DatabaseSettings.Schema);
               }));

            return services;
        }
    }
}