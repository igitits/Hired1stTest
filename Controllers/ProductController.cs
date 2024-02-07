using Hired1stTest.DTO;
using Hired1stTest.Models;
using Hired1stTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hired1stTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProduct _productService;

        public ProductController(IProduct productService)
        {
                _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public IActionResult Index(string userId)
        {
            var prods = _productService.GetAllProducts(userId);
            if (prods == null)
            {
                return NotFound();
            }

            return Ok(prods);
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductDTO productDTO) 
        {
            bool rs = _productService.AddProduct(productDTO);
            if (rs == false)
            {
                return BadRequest("Adding Product failed");
            }
            else return Ok("Added Product: " + rs);
        }

        [HttpPost]
        [Route("EditProduct")]
        public IActionResult EditProduct(Product prod)
        {
            int rs = _productService.UpdateProduct(prod);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Updated!");
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(string id)
        {
            int rs = _productService.DeleteProduct(id);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Deleted!");
        }
    }
}
