using BenchmarkDotNet.Running;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosTest
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .Build();
            var summary = await Task.Run(() => BenchmarkRunner.Run<CosmosRepo>());
            await host.RunAsync();
        }
    }
}
