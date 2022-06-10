using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Azure;

[assembly: FunctionsStartup(typeof(StartupFA.Startup))]

namespace StartupFA
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            var storageConnectionString = Environment.GetEnvironmentVariable("storageConnectionString");

            services.AddLogging();
            services.AddAzureAppConfiguration();
            services.AddAzureClients();
        }
    }
}
