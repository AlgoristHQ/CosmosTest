using CosmosTest.CosmosLib;
using CosmosTest.DocumentDb;
using CosmosTest.EFCore;
using CosmosTest.MongoDb;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace CosmosTest
{
    public class CosmosRepo
    {
        private CosmosLibToCosmos _cosmosLibToCosmos = new CosmosLibToCosmos();
        private DocumentClientToCosmos _documentClientToCosmos = new DocumentClientToCosmos();
        private EFCoreToCosmos _efCoreToCosmos = new EFCoreToCosmos();
        MongoDbToCosmos _mongoDbToCosmos = new MongoDbToCosmos();

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
        [Benchmark]
        public List<MongoDb.CosmosDocumentType> UseMongoDb()
        {
            return _mongoDbToCosmos.GetAll();
        }
    }
}
