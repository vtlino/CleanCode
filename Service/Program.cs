﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                 //.ConfigureLogging((hostContext, config) =>
                 //{
                 //    config.AddConsole();
                 //    config.AddDebug();
                 //})
                 //.ConfigureHostConfiguration(config =>
                 //{
                 //    config.AddEnvironmentVariables();
                 //})
                 //.ConfigureAppConfiguration((hostContext, config) =>
                 //{
                 //    //config.AddJsonFile("appsettings.json", optional: true);
                 //    //config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                 //    config.AddCommandLine(args);
                 //})
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.AddLogging();
                     //services.AddSingleton<MonitorLoop>();

                    #region snippet1
                    services.AddHostedService<TimedHostedService>();
                    #endregion

                    //#region snippet2
                    //services.AddHostedService<ConsumeScopedServiceHostedService>();
                    // services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                    //#endregion

                    //#region snippet3
                    //services.AddHostedService<QueuedHostedService>();
                    // services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                    //#endregion
                })
                 .UseConsoleLifetime()
                 .Build();

            using (host)
            {
                // Start the host
                //await host.StartAsync();

                // Monitor for new background queue work items
                //var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
                //monitorLoop.StartMonitorLoop();

                //// Wait for the host to shutdown
                //await host.WaitForShutdownAsync();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
