using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosTest.DocumentDb
{
    public class DocumentClientToCosmos
    {
        private readonly string _endpoint = "";
        private readonly string _authkey = "";
        private readonly string _cosmosDatabaseId = "";
        private readonly string _containerId = "";
        public List<CosmosDocumentType> GetAll()
        {
            List<CosmosDocumentType> results = new List<CosmosDocumentType>();
            using (var client = new DocumentClient(new Uri(_endpoint), _authkey))
            {
                results = client.CreateDocumentQuery<CosmosDocumentType>(UriFactory.CreateDocumentCollectionUri(_cosmosDatabaseId, _containerId),
                    "SELECT c.id, c.name, c.type FROM c", new FeedOptions { PartitionKey = new PartitionKey("isSaleable") })
                    .Select(x => new CosmosDocumentType() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList();
            }
            return results;
        }
    }

    public class CosmosDocumentType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
