using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TnTetraPusher.Core.Engine;
using TnTetraPusher.Engine.ContentHandlers;
using TnTetraPusher.Engine.EmailReaders;

namespace TnTetraPusher.Configuration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет опции из конфигурационного файла appsettings.json
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection ConfigureServiceCollection(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
             //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             //.AddJsonFile($"appsettings.json")
             //.AddEnvironmentVariables()
             //.AddCommandLine(args)
             .Build();

            services.AddScoped<IEmailReader, ExchangeEmailReader>();
            services.AddScoped<IContentHandler, ContentHandler>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            /*
            services
                .AddSingleton<IConfiguration>(configuration)
                .AddDbContext<URContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("URConnection"));
                    options.EnableSensitiveDataLogging(true);
                })
                .AddDbContext<JobContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("JobConnection"));
                    options.EnableSensitiveDataLogging(true);
                })
                .AddDbContext<SedContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("SedConnection"));
                    options.EnableSensitiveDataLogging(true);
                })
                .AddDbContext<DocumentContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging(true);
                })
                .AddEngine()
                .AddUchetRabotOptions(configuration);
            */

            return services;
        }
    }
}