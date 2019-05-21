﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace TuiWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{GetEnvironmentName(args)}.json", true, true)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>();


        }

        private static string GetEnvironmentName(string[] args, string defaultEnvironmentName = null)
        {
            var environmentName = new ConfigurationBuilder()
                .AddEnvironmentVariables("ASPNETCORE_").AddCommandLine(args)
                .Build()[WebHostDefaults.EnvironmentKey];
            return environmentName ?? defaultEnvironmentName ?? EnvironmentName.Development;
        }

    }
}