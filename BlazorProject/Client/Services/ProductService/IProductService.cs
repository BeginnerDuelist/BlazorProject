using BlazorProject.Shared;

namespace BlazorProject.Client.Services.ProductService
{
     public interface IProductService
     {
          public Task<ServiceModel<Product>?> AddProduct(Product NewProduct);
          public Task<ServiceModel<Product>?> UpdateProduct(Product NewProduct);
          public Task<ServiceModel<Product>?> GetProducts();
          public Task<ServiceModel<Product>?> GetProduct(int ProductId);
          public Task<ServiceModel<Product>?> DeleteProduct(int ProductId);
          public Task<ServiceModel<Product>?> GetProductbyCategory(string url);
          public Task<int> GetProductsCount();

     }
}
