using Hired1stTest.DTO;
using Hired1stTest.Models;

namespace Hired1stTest.Services.Interfaces
{
    public interface IProduct
    {
        public bool AddProduct(ProductDTO p_dto);
        public IEnumerable<Product> GetAllProducts(string user);
        public int UpdateProduct(Product prod);
        public int DeleteProduct(string id);
        public IEnumerable<Product> GetProducts();
    }
}
