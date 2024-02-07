using Amazon.Util;
using Hired1stTest.DTO;
using Hired1stTest.Models;
using Hired1stTest.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hired1stTest.Services
{
    public class ProductService : IProduct
    {
        private readonly MongoDBService _mongoDBService;

        public ProductService(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public bool AddProduct(ProductDTO p_dto) 
        { 
            bool result = false;
            if (p_dto != null) 
            {
                Product product = new Product()
                {
                    ProductName = p_dto.ProductName,
                    Description = p_dto.Description,
                    Price = p_dto.Price,
                    UserId = p_dto.UserId
                };

                _mongoDBService._productCollection.InsertOne(product);
                result = true;
            }
            return result;
        }

        public IEnumerable<Product> GetAllProducts(string userId)
        {
            var products = Builders<Product>.Filter.Eq(x => x.UserId, userId);
            return _mongoDBService._productCollection.Find(products).ToEnumerable();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _mongoDBService._productCollection.Find(_ => true).ToEnumerable();
        }

        public int UpdateProduct(Product prod)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, prod.Id);

            var productExist = _mongoDBService._productCollection.Find(filter).FirstOrDefault() ?? null;

            if (productExist != null)
            {
                productExist.ProductName = prod.ProductName;
                productExist.Description = prod.Description;
                productExist.Price = prod.Price;
                productExist.UserId = prod.UserId;

                var result = _mongoDBService._productCollection.ReplaceOne(filter, productExist);

                if (result.IsAcknowledged && result.ModifiedCount > 0)
                {
                    return 1;
                }
                return -1;
            }
            return -1;
        }

        public int DeleteProduct(string id)
        {
            ObjectId productId;
            if(!ObjectId.TryParse(id, out productId))
            {
                return -1;
            }

            var filter = Builders<Product>.Filter.Eq(x => x.Id, productId);
            if (filter != null)
            {
                var result = _mongoDBService._productCollection.DeleteOne(filter);

                if (result.IsAcknowledged)
                {
                    return 1;
                }
                return -1;
            }
            return -1;
        }
    }
}
