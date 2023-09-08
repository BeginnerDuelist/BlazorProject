

using BlazorProject.Server.DTO.Product_DTO;

namespace BlazorProject.Server.Services.ProductService
{
     public interface IProductService
     {
          Task<ServiceModel<Product>> GetProductsAsync();
          Task<ServiceModel<Product>> GetProductAsync(int id);
          Task<ServiceModel<Product>> AddProductAsync(Product product);
          Task<ServiceModel<Product>> UpdateProductAsync(Product product);
          Task<ServiceModel<Product>> DeleteProductAsync(int id);
          Task<ServiceModel<Product>> GetProductsByCategory(string url);
     }
}
