using BlazorProject.Shared;
using System.Net.Http.Json;

namespace BlazorProject.Client.Services.CategoryService
{
     public class CategoryService : ICategoryService
     {
          private readonly HttpClient _http;

          public CategoryService(HttpClient http)
          {
               _http = http;
          }
        public List<Category> Categorys { get; set; }=new List<Category>();

        public async Task GetCategorys()
        {
               var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
               if(response != null && response.Data != null)
                    Categorys=response.Data;

        }
     }
}
