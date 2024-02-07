using Hired1stTest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hired1stTest.DTO
{
    public class ProductDTO
    {
        [JsonPropertyName("prod_name")]
        public string ProductName { get; set; }
        [JsonPropertyName("prod_desc")]
        public string Description { get; set; }
        [JsonPropertyName("prod_price")]
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
