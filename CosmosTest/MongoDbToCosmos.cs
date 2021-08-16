using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace CosmosTest.MongoDb
{
    public class MongoDbToCosmos
    {
        private readonly string _cosmosDbConnectionString = "";
        private readonly string _cosmosDbId = "";
        private readonly string _collectionId = "";
        public List<CosmosDocumentType> GetAll()
        {
            MongoClient mongoClient = new MongoClient(_cosmosDbConnectionString);
            var db = mongoClient.GetDatabase(_cosmosDbId);
            var results = db.GetCollection<CosmosDocumentType>(_collectionId)
                            .AsQueryable()
                            .Select(x => new CosmosDocumentType() { Id = x.Id, Name = x.Name, Type = x.Type })
                            .ToList();
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
