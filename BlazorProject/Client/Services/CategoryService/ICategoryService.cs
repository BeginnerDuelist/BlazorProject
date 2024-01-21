using BlazorProject.Shared;

namespace BlazorProject.Client.Services.CategoryService
{
     public interface ICategoryService
     {
          Task<ServiceModel<Category>> AddCategory(Category newCategory);
          Task<ServiceModel<Category>> DeleteCategory(int id);
          Task<ServiceModel<Category>> UpdateCategory(Category newCategory);
          Task<ServiceModel<Category>> GetCategory(int id);
          Task<ServiceModel<Category>> GetCategories();
          Task<int> GetCategoryCount();
     }
}
