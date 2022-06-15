using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;

namespace StartupFA
{
    public class Function1
    {
        private readonly QueueServiceClient _queueStorage;

        public Function1(IAzureClientFactory<QueueServiceClient> clientFactory)
        {
            _queueStorage = clientFactory.CreateClient("PrivateQueue");
        }

        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _queueStorage.
        }
    }
}
