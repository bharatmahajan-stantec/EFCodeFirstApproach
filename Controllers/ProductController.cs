using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;
using EFCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirst.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    [ControllerName("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<Product>>> GetAllProducts()
        {
            var response = _productService.GetAllProducts();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{productId}")]
        public ActionResult<ApiResponse<Product>> GetProductById(int productId)
        {
            var response = _productService.GetProductById(productId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public ActionResult<ApiResponse<Product>> AddProduct([FromBody] Product product)
        {
            var response = _productService.AddProduct(product);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{productId}")]
        public ActionResult<ApiResponse<Product>> UpdateProduct(int productId, [FromBody] ProductDTO product)
        {
            var response = _productService.UpdateProduct(productId, product);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{productId}")]
        public ActionResult<ApiResponse<bool>> DeleteProduct(int productId)
        {
            var response = _productService.DeleteProduct(productId);
            return StatusCode(response.StatusCode, response);
        }
    }
}
