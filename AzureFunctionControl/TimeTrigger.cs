using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionControl
{
    public static class TimeTrigger
    {
        [FunctionName("TimeTrigger")]
        public static async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            AzureFunction.Context.TriggerContext context = new(new AzureFunction.Strategies.TimeTriggerStrategy(log));
            await context.Execute();

            log.LogInformation("--- POPULATION DONE!---");
        }
    }
}

