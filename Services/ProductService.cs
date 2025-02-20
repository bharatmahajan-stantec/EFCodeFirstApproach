using EFCodeFirst.Data.Repositories;
using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;

namespace EFCodeFirst.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ApiResponse<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                return ApiResponse<IEnumerable<Product>>.Success(products);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Product>>.Error(ex.Message);
            }
        }

        public ApiResponse<Product> GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product == null)
                {
                    return ApiResponse<Product>.Error("Product not found", 404);
                }
                return ApiResponse<Product>.Success(product);
            }
            catch (Exception ex)
            {
                return ApiResponse<Product>.Error(ex.Message);
            }
        }

        public ApiResponse<Product> AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                return ApiResponse<Product>.Success(product);
            }
            catch (Exception ex)
            {
                return ApiResponse<Product>.Error(ex.Message);
            }
        }

        public ApiResponse<Product> UpdateProduct(int id, ProductDTO product)
        {
            try
            {
                var existingProduct = _productRepository.GetById(id);
                if (existingProduct == null)
                {
                    return ApiResponse<Product>.Error("Product not found", 404);
                }
                bool isUpdated = false;

                if (!string.IsNullOrEmpty(product.Name))
                {
                    existingProduct.Name = product.Name;
                    isUpdated = true;
                }

                if (product.Price.HasValue)
                {
                    existingProduct.Price = product.Price.Value;
                    isUpdated = true;
                }

                if (!string.IsNullOrEmpty(product.Description))
                {
                    existingProduct.Description = product.Description;
                    isUpdated = true;
                }

                if (!isUpdated)
                {
                    return ApiResponse<Product>.Error("No fields provided for update", 400);
                }

                _productRepository.Update(existingProduct);

                return ApiResponse<Product>.Success(existingProduct);
            }
            catch (Exception ex)
            {
                return ApiResponse<Product>.Error(ex.Message);
            }
        }

        public ApiResponse<bool> DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product == null)
                {
                    return ApiResponse<bool>.Error("Product not found", 404);
                }

                _productRepository.Delete(product);
                return ApiResponse<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error(ex.Message);
            }
        }
    }
}
