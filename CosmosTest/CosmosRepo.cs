using CosmosTest.CosmosLib;
using CosmosTest.DocumentDb;
using CosmosTest.EFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosTest
{
    public class CosmosRepo
    {
        private CosmosLibToCosmos _cosmosLibToCosmos = new CosmosLibToCosmos();
        private DocumentClientToCosmos _documentClientToCosmos = new DocumentClientToCosmos();
        private EFCoreToCosmos _efCoreToCosmos = new EFCoreToCosmos();

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
    }
}
