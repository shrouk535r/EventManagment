using EventManagement.Application;
using EventManagement.Infrastructure;

namespace EventManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            return services;
        }

    }
}
