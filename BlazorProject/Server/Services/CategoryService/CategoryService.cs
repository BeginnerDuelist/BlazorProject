using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorProject.Server.Services.CategoryService
{
     public class CategoryService : ICategoryService
     {
          private readonly BlazorProjectAPIDbContext appDbContext;

          public CategoryService(BlazorProjectAPIDbContext appDbContext) 
          {
               this.appDbContext = appDbContext;
          }
          public async Task<ServiceModel<Category>> AddCategoryAsync(Category newCategory)
          {
               var response = new ServiceModel<Category>();
               if (newCategory != null)
               {
                    var category = await appDbContext.Category.FirstOrDefaultAsync(c => c.Name == newCategory.Name);
                    if (category != null)
                    {
                         response.Message = "Category already created !";
                         response.Success = false;
                         response.CssClass = "info fw-bold";
                    }
                    else
                    {
                         newCategory.Url = newCategory.Name!.ToLower().Replace(" ", "-");
                         appDbContext.Category.Add(newCategory);
                         await appDbContext.SaveChangesAsync();
                         response.Message = "Category created!";
                         response.Success = true;
                         response.CssClass = "success fw-bold";
                         var list = await GetCategorysAsync();
                         response.MultipleData = list.MultipleData;
                    }
               }
               else
               {
                    response.Message = "Category object is empty !";
                    response.Success = false;
                    response.CssClass = "danger fw-bold";
               }
               return response;
          }

          public async Task<ServiceModel<Category>> DeleteCategoryAsync(int id)
          {
               var response = new ServiceModel<Category>();
               if (id > 0)
               {
                    var category = await GetCategoryAsync(id);
                    if (category != null)
                    {
                         appDbContext.Category.Remove(category!.Data!);
                         await appDbContext.SaveChangesAsync();
                         response.Message = $"Category with the name {category.Data?.Name} deleted!";
                         response.Success = false;
                         response.CssClass = "danger fw-bold";
                         response.Data = category.Data;
                         var list = await GetCategorysAsync();
                         response.MultipleData = list.MultipleData;
                    }
                    else
                    {
                         response.Message = category!.Message;
                         response.Success = category.Success;
                         response.CssClass = category.CssClass;
                    }
               }
               else
               {
                    response.Message = "Invalid category!";
                    response.Success = false;
                    response.CssClass = "danger fw-bold";
               }
               return response;
          }

          public async Task<ServiceModel<Category>> GetCategoryAsync(int id)
          {
               var response = new ServiceModel<Category>();
               if (id > 0)
               {
                    var category = await appDbContext.Category.SingleOrDefaultAsync(c => c.Id == id);
                    if (category != null)
                    {
                         response.Message = "Category  found!";
                         response.CssClass = "success fw-bold";
                         response.Success = true;
                         response.Data = category;
                    }
                    else
                    {
                         response.Message = "Category not found!";
                         response.CssClass = "danger fw-bold";
                         response.Success = false;
                    }
               }
               else
               {
                    response.Message = "Invalid category!";
                    response.CssClass = "danger fw-bold";
                    response.Success = false;
               }

               return response;
          }

          public async Task<ServiceModel<Category>> GetCategorysAsync()
          {
               var response = new ServiceModel<Category>();
               var result = await appDbContext.Category.ToListAsync();
               if (result != null)
               {
                    response.MultipleData = result;
                    response.Message = "Categories found!";
                    response.CssClass = "success fw-bold";
                    response.Success = true;
               }
               else
               {
                    response.Message = "Categories not found!";
                    response.CssClass = "info fw-bold";
                    response.Success = false;
               }
               return response;
          }

          public async Task<ServiceModel<Category>> UpdateCategoryAsync(Category newCategory)
          {
               var response = new ServiceModel<Category>();
               if (newCategory != null)
               {
                    var category = await GetCategoryAsync(newCategory.Id);
                    if (category.Data != null)
                    {
                         category.Data.Name = newCategory.Name;
                         category.Data.Url = newCategory.Name!.ToLower().Replace(" ", "-");
                         category.Data.Image = newCategory.Image;
                         await appDbContext.SaveChangesAsync();
                         response.Message = "Category updated!";
                         response.CssClass = "success fw-bold";
                         response.Data = category.Data;
                         response.Success = true;
                         var categories = await GetCategorysAsync();
                         response.MultipleData = categories.MultipleData;
                    }
                    else
                    {
                         response.Message = category.Message;
                         response.CssClass = category.CssClass;
                         response.Success = category.Success;
                    }
               }
               else
               {
                    response.Message = "Category object is empty!";
                    response.CssClass = "danger fw-bold";
                    response.Success = false;
               }
               return response;
          }
     }
}
