using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionStartup
{
    public static class ServiceBusTopic
    {
        [FunctionName("ServiceBusTopic")]
        public static void Run([ServiceBusTrigger("mytopic", "mysubscription", Connection = "serbusconnstring")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
