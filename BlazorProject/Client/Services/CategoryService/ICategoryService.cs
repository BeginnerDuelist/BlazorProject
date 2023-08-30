using BlazorProject.Shared;

namespace BlazorProject.Client.Services.CategoryService
{
     public interface ICategoryService
     {
          List<Category> Categorys { get; set; }
          Task GetCategorys();
     }
}
