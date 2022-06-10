# FunctionStartup
Function V3 with Startup.cs injecting Table and Blob Client to the Function Builder object

In this example we are injecting a **Table Client** and **Blob Client**
  - This is what the Startup.cs file looks like in this project

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionStartup.Startup))]

namespace FunctionStartup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMyBlobClient, MyBlobClient>();
        }
    }
}

```
