using BlazorProject.Shared;
using System.Net.Http.Json;


namespace BlazorProject.Client.Services.ProductService
{
     public class ProductService : IProductService
     {
          private readonly HttpClient _http;

          public ProductService(HttpClient http)
          {
               _http = http;
          }
          public List<Product> Products { get; set; } = new List<Product>();

          public event Action ProductsChanged;

          public async Task<ServiceResponse<Product>> GetProduct(int id)
          {
               var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
               return result;
          }

          public async Task GetProducts(string? categoryURL = null!)
          {
               var result = categoryURL == null ? 
                    await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product"):
                    await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryURL}");

               if(result != null && result.Data != null)
                    Products = result.Data;

               ProductsChanged.Invoke();
          }
     }
}
