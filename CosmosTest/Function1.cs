using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CosmosTest
{
    public class Function1
    {
        [Function("ConnectionMethodsTest")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var results = new CosmosRepo().UseDocumentClient();
            var response = req.CreateResponse();
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Let's do some Cosmos!!");
            return response;
        }
    }
}
