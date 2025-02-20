using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;

namespace EFCodeFirst.Services
{
    public interface IProductService
    {
        ApiResponse<IEnumerable<Product>> GetAllProducts();
        ApiResponse<Product> GetProductById(int id);
        ApiResponse<Product> AddProduct(Product product);
        ApiResponse<Product> UpdateProduct(int id, ProductDTO product);
        ApiResponse<bool> DeleteProduct(int id);
    }
}
