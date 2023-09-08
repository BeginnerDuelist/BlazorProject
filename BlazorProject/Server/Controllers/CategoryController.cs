using BlazorProject.Server.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CategoryController : ControllerBase
     {
          private readonly ICategoryService _categoryService;

          public CategoryController(ICategoryService categoryService)
          {
               _categoryService = categoryService;
          }

          // GET: api/Product
          [HttpGet]
          public async Task<ActionResult<ServiceModel<List<Category>>>> GetCategorys()
          {
               var result = await _categoryService.GetCategorysAsync();
               return Ok(result);
          }

          // GET: api/Product/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Category>> GetCategory(int id)
          {
               var result = await _categoryService.GetCategoryAsync(id);
               return Ok(result);
          }

          [HttpPost]
          public async Task<ActionResult<Category>> AddCategory(Category category)
          {
               var result = await _categoryService.AddCategoryAsync(category);
               return Ok(result);
          }

          [HttpDelete("{id}")]
          public async Task<ActionResult<Category>> DeleteCategory(int id)
          {
               var result = await _categoryService.DeleteCategoryAsync(id);
               return Ok(result);
          }

          [HttpPut]
          public async Task<ActionResult> UpdateCategory(Category category)
          {
               var result = await _categoryService.UpdateCategoryAsync(category);
               return Ok(result);
          }
     }
}
