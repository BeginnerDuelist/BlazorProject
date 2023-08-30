

using BlazorProject.Server.DTO.Product_DTO;

namespace BlazorProject.Server.Services.ProductService
{
     public interface IProductService
     {
          Task<ServiceResponse<List<Product>>> GetProductsAsync();
          Task<ServiceResponse<Product>> GetProductAsync(int id);
          Task<ServiceResponse<Product>> AddProductAsync(CreateProductDTO product);
          Task<ServiceResponse<Product>> UpdateProductAsync(int id ,UpdateProductDTO product);
          Task<ServiceResponse<Product>> DeleteProductAsync(int id);
          Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryURL);
          bool ProductExists(int id);
     }
}
