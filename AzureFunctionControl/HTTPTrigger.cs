using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;



namespace AzureFunctionControl
{
    public static class HTTPTrigger
    {
        [FunctionName("HTTPTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            AzureFunction.Context.TriggerContext context = new(new AzureFunction.Strategies.HTTPTriggerStrategy(req, log));
            await context.Execute();

            return new OkObjectResult("---POPULATION DONE!---");
        }
    }
}

