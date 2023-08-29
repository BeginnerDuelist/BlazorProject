using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Server.Services.CategoryService
{
     public class CategoryService : ICategoryService
     {
          private readonly BlazorProjectAPIDbContext _context;

          public CategoryService(BlazorProjectAPIDbContext context) 
          {
               _context = context;
          }
          public async Task<ServiceResponse<Category>> AddCategoryAsync(Category category)
          {
               _context.Category.Add(category);
               await _context.SaveChangesAsync();
               var response = new ServiceResponse<Category>()
               {
                    Data = category,
                    Message = "Added category"
               };
               return response;
          }

          public bool CategoryExists(int id)
          {
               return _context.Category.Any(e => e.Id == id);
          }

          public async Task<ServiceResponse<Category>> DeleteCategoryAsync(int id)
          {
               var response = new ServiceResponse<Category>();
               var category = await _context.Category.FindAsync(id);
               if (category == null)
               {
                    response.Success = false;
                    response.Message = "Sorry Category not found!!!";
               }
               else
               {
                    _context.Category.Remove(category);
                    await _context.SaveChangesAsync();
                    response.Data = null!;
                    response.Message = "We deleted the category";
               }

               return response;
          }

          public async Task<ServiceResponse<Category>> GetCategoryAsync(int id)
          {
               var response = new ServiceResponse<Category>();
               var category = await _context.Category.FindAsync(id);
               if (category == null)
               {
                    response.Success = false;
                    response.Message = "Sorry Category not found!!!";
               }
               else
               {
                    response.Data = category;
                    response.Message = "We found your Category";
               }
               return response;
          }

          public async Task<ServiceResponse<List<Category>>> GetCategorysAsync()
          {
               var response = new ServiceResponse<List<Category>>()
               {
                    Data = await _context.Category.ToListAsync()

               };
               return response;
          }

          public async Task<ServiceResponse<Category>> UpdateCategoryAsync(int id, Category category)
          {
               var response = new ServiceResponse<Category>();
               if (id != category.Id)
               {
                    response.Success = false;
                    response.Message = "Category not found";
                    response.Data = null!;
                    return response;
               }

               _context.Entry(category).State = EntityState.Modified;

               try
               {
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Category updated succesful";
                    response.Data = category;
                    return response;
               }
               catch (DbUpdateConcurrencyException)
               {
                    if (!CategoryExists(id))
                    {
                         response.Success = false;
                         response.Message = "Category doesn't exist!!!";
                         response.Data = null!;
                         return response;
                    }
               }
               return response;
          }
     }
}
