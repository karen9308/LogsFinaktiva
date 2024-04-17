using LogsFinaktiva.Domain.Interfaces;
using LogsFinaktiva.Infraestructure;
using LogsFinaktiva.Infraestructure.Data;
using LogsFinaktiva.Service;
using LogsFinaktiva.Service.Common;
using LogsFinaktiva.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogsFinaktiva.Api.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEventLogService, EventLogService>();
        }
        public static void AddLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                option => option.UseSqlServer(connectionString)
                                .EnableSensitiveDataLogging()
                );
           
        }
        public static void AddCorsDomainConfiguration(this IServiceCollection services, string MyAllowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200");
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
        }
    }
}
