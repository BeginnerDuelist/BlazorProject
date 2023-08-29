

namespace BlazorProject.Server.Services.ProductService
{
     public interface IProductService
     {
          Task<ServiceResponse<List<Product>>> GetProductsAsync();
          Task<ServiceResponse<Product>> GetProductAsync(int id);
          Task<ServiceResponse<Product>> AddProductAsync(Product product);
          Task<ServiceResponse<Product>> UpdateProductAsync(int id ,Product product);
          Task<ServiceResponse<Product>> DeleteProductAsync(int id);
          bool ProductExists(int id);
     }
}
