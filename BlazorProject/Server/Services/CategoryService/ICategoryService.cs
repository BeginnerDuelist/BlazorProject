namespace BlazorProject.Server.Services.CategoryService
{
     public interface ICategoryService
     {
          Task<ServiceModel<Category>> GetCategorysAsync();
          Task<ServiceModel<Category>> GetCategoryAsync(int id);
          Task<ServiceModel<Category>> AddCategoryAsync(Category newCategory);
          Task<ServiceModel<Category>> UpdateCategoryAsync(Category newCategory);
          Task<ServiceModel<Category>> DeleteCategoryAsync(int id);
          Task<int> GetTotalCategorysCount();


     }
}
