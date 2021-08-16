using CosmosTest.CosmosLib;
using CosmosTest.DocumentDb;
using CosmosTest.EFCore;
using CosmosTest.MongoDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosTest
{
    public class CosmosRepo
    {
        private CosmosLibToCosmos _cosmosLibToCosmos = new CosmosLibToCosmos();
        private DocumentClientToCosmos _documentClientToCosmos = new DocumentClientToCosmos();
        private EFCoreToCosmos _efCoreToCosmos = new EFCoreToCosmos();
        MongoDbToCosmos _mongoDbToCosmos = new MongoDbToCosmos();

        public List<DocumentDb.CosmosDocumentType> UseDocumentClient()
        {
            return _documentClientToCosmos.GetAll();
        }

        public async Task<List<CosmosLib.CosmosDocumentType>> UseCosmosLib()
        {
            return await _cosmosLibToCosmos.GetAll();
        }

        public List<EFCore.CosmosDocumentType> UseEFCore()
        {
            return _efCoreToCosmos.GetAll();
        }

        public List<MongoDb.CosmosDocumentType> UseMongoDb()
        {
            return _mongoDbToCosmos.GetAll();
        }
    }
}
