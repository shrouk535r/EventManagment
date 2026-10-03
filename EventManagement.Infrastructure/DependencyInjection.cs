
using EventManagement.Domain.Entities.Users;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.Domain.Interfaces.UOW;
using EventManagement.Infrastructure.Data;
using EventManagement.Infrastructure.Repositories;
using EventManagement.Infrastructure.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EventManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddDbContext<EventDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EventManagementDB"))
            );
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<EventDBContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
