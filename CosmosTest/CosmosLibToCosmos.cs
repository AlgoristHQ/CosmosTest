using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosTest.CosmosLib
{
    public class CosmosLibToCosmos
    {
        private readonly string _endpoint = "";
        private readonly string _authkey = "";
        private readonly string _cosmosDatabaseId = "";
        private readonly string _partitionKeyPath = "/partitionKeyPath";
        private readonly string _query = "SELECT c.Id, c.Name, c.Type FROM c";
        public async Task<List<CosmosDocumentType>> GetAll()
        {
            List<CosmosDocumentType> results = new List<CosmosDocumentType>();
            using (CosmosClient client = new CosmosClient(_endpoint, _authkey))
            {
                var cosmosDb = await client.CreateDatabaseIfNotExistsAsync(_cosmosDatabaseId);
                Container container = await GetOrCreateContainerAsync(cosmosDb, _cosmosDatabaseId);
                QueryDefinition query = new QueryDefinition(_query);
                using (FeedIterator<CosmosDocumentType> resultSetIterator = container.GetItemQueryIterator<CosmosDocumentType>(
                    query,
                    requestOptions: new QueryRequestOptions()
                    {
                        PartitionKey = new PartitionKey(partitionKeyValue: true)
                    }
                ))
                {
                    while (resultSetIterator.HasMoreResults)
                    {
                        var response = await resultSetIterator.ReadNextAsync();
                        results.AddRange(response);
                    }
                }
            }
            return results;
        }

        private async Task<Container> GetOrCreateContainerAsync(Database cosmosDb, string containerId)
        {
            ContainerProperties containerProperties = new ContainerProperties(id: containerId, partitionKeyPath: _partitionKeyPath);
            var returnVal = await cosmosDb.CreateContainerIfNotExistsAsync(
                containerProperties: containerProperties,
                throughput: 400);
            return returnVal;
        }
    }
    public class CosmosDocumentType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
