using Microsoft.Extensions.DependencyInjection;
using DiyarTask.Application.Authentication.Interfaces;
using DiyarTask.Application.Authentication;

namespace DiyarTask.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
