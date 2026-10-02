using EventManagement.Api.Excepitions;
using EventManagement.Application;
using EventManagement.Infrastructure;

namespace EventManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProblemDetails();
            services.AddExceptionHandler<GlobalExcepitionHandler>();
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            return services;
        }

    }
}
