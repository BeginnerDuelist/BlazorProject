namespace BlazorProject.Server.Services.CategoryService
{
     public interface ICategoryService
     {
          Task<ServiceResponse<List<Category>>> GetCategorysAsync();
          Task<ServiceResponse<Category>> GetCategoryAsync(int id);
          Task<ServiceResponse<Category>> AddCategoryAsync(Category category);
          Task<ServiceResponse<Category>> UpdateCategoryAsync(int id, Category category);
          Task<ServiceResponse<Category>> DeleteCategoryAsync(int id);
          bool CategoryExists(int id);
     }
}
