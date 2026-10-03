using EventManagement.Api.Excepitions;
using EventManagement.Application;
using EventManagement.Domain.Entities.Users;
using EventManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
namespace EventManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            services.AddProblemDetails();
            services.AddExceptionHandler<GlobalExcepitionHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
                    };
                });
            services.AddAuthorization();
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            services.AddSwaggerGen(options =>
            {
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token in the format: Bearer {your token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                      new OpenApiSecurityScheme
                      {
                         Reference = new OpenApiReference
                         {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer" 
                         }
                      },
                      Array.Empty<string>() 
                   }
                });
            });

            return services;
        }

    }
}
