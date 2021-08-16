using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BenchmarkDotNet.Running;

namespace CosmosTest
{
    public class Function1
    {
        [FunctionName("ConnectionMethodsTest")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var summary = BenchmarkRunner.Run<CosmosRepo>();

            return new OkObjectResult("");
        }
    }
}
