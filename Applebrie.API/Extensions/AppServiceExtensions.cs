using Applebrie.Application.Core;
using Applebrie.Application.Users;
using Applebrie.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Applebrie.API.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddCustomApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Create>();
            });

            services.AddDbContext<ApplebrieDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Development"));
            });

            // Added CorsPolice 
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
