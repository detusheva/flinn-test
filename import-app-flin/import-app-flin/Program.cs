using import_app_flin.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace import_app_flin
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine(args);

            serviceProvider.GetService<ConsoleApplication>().Run(args[0]);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            services.AddDbContext<flintestContext>(opt =>
                            opt.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));

            services.AddTransient<ConsoleApplication>();

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
