using TaskManagement.Application.Behaviors;
using TaskManagement.Application.Features.Auth.Services;
using TaskManagement.Application.Features.Auth.Services.Interfaces;
using TaskManagement.Domain.Entities.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {


            // Add MediatR services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IJWTService, JWTService>();
            // Add FluentValidation services
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Add pipeline behavior for validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
