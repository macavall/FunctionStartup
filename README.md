# FunctionStartup
Function V3 with Startup.cs injecting Table and Blob Client to the Function Builder object

In this example we are injecting a **Table Client** and **Blob Client**
  - This is what the Startup.cs file looks like in this project

```C#
using System;
using System.Net;
using System.Net.Http;
using Azure.Core;
using Azure.Data.AppConfiguration;
using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Storage;
using Azure.Data.Tables;


[assembly: FunctionsStartup(typeof(FunctionStartup.Startup))]

namespace FunctionStartup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            var storageConnectionString = Environment.GetEnvironmentVariable("storageConnectionString");

            services.AddLogging();
            services.AddAzureAppConfiguration();
            services.AddAzureClients(builder =>
            {
                builder.AddTableServiceClient("storageConnectionString");
                builder.AddQueueServiceClient("storageConnectionString");
            });
        }
    }
}

```
