using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
        );
        return services;
    }
}
