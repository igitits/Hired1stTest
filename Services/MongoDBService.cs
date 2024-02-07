using Hired1stTest.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hired1stTest.Services
{
    public class MongoDBService
    {
        public IMongoCollection<User> _usersCollection { get; }
        public IMongoCollection<Product> _productCollection { get; }

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _usersCollection = database.GetCollection<User>("user");
            _productCollection = database.GetCollection<Product>("product");
        }
    }
}
