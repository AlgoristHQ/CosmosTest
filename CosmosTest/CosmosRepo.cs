using CosmosTest.CosmosLib;
using CosmosTest.DocumentDb;
using CosmosTest.EFCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace CosmosTest
{
    [MemoryDiagnoser]
    [ConcurrencyVisualizerProfiler]
    [NativeMemoryProfiler]
    [ThreadingDiagnoser]
    public class CosmosRepo
    {
        private CosmosLibToCosmos _cosmosLibToCosmos = new CosmosLibToCosmos();
        private DocumentClientToCosmos _documentClientToCosmos = new DocumentClientToCosmos();
        private EFCoreToCosmos _efCoreToCosmos = new EFCoreToCosmos();

        [Benchmark]
        public List<DocumentDb.CosmosDocumentType> UseDocumentClient()
        {
            return _documentClientToCosmos.GetAll();
        }
        [Benchmark]
        public async Task<List<CosmosLib.CosmosDocumentType>> UseCosmosLib()
        {
            return await _cosmosLibToCosmos.GetAll();
        }
        [Benchmark]
        public List<EFCore.CosmosDocumentType> UseEFCore()
        {
            return _efCoreToCosmos.GetAll();
        }
    }
}
