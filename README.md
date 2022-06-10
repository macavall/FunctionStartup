# FunctionStartup
Function V3 with Startup.cs injecting Table and Blob Client to the Function Builder object

In this example we are injecting a **Queue Client** using Dependency Injection
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


The Interface looks like this:
```C#
namespace FunctionStartup
{
    public interface IMyBlobClient
    {
        public void SendMessage(string messageValue);
    }
}
```

And the MyBlobClient class appears as follows
```C#
using Azure.Storage.Queues;

namespace FunctionStartup
{
    public class MyBlobClient : IMyBlobClient
    {
        public static QueueClient queueClient = new QueueClient("DefaultEndpointsProtocol=https;AccountName=globalstorage5601;AccountKey=;EndpointSuffix=core.windows.net", "myqueue-items");

        public MyBlobClient()
        {
        }

        public void SendMessage(string messageValue)
        {
            queueClient.SendMessage(messageValue);
        }
    }
}
```

# [Star Formation Theory][sft]
[Reference to this section](#sft)
Finally the Function App Injection Portion appears as follows
```C#
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues;

namespace FunctionStartup
{
    public class Function1
    {
        private readonly IMyBlobClient _myBlobClient;

        public Function1(IMyBlobClient myBlobClient)
        {
            _myBlobClient = myBlobClient;
        }

        // Instantiate a QueueClient which will be used to create and manipulate the queue
        //static QueueClient queueClient = new QueueClient("DefaultEndpointsProtocol=https;AccountName=globalstorage5601;AccountKey=MiUoNPnBtIbVmTM0c9/T6DQ3j+0Df+qgR7tR0HPRsyqOxNrzq2oaTvekkJWZCPA25SteIygcxSfZUMhERosepA==;EndpointSuffix=core.windows.net", "myqueue-items");

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _myBlobClient.SendMessage("message=messageValue");
        }
    }
}

```
