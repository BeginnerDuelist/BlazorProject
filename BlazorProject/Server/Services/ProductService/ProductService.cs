using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Server.Services.ProductService
{
     public class ProductService : IProductService
     {
          private readonly BlazorProjectAPIDbContext _context;

          public ProductService(BlazorProjectAPIDbContext context)
        {
               _context = context;
          }

          public async Task<ServiceResponse<Product>> GetProductAsync(int id)
          {
               var response = new ServiceResponse<Product>();
               var product = await _context.Product.FindAsync(id);
               if (product == null)
               {
                    response.Success = false;
                    response.Message = "Sorry Product not found!!!";
               }
               else
               {
                    response.Data = product;
                    response.Message = "We found your product";
               }
               return response;
          }

          public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
          {
               var response = new ServiceResponse<List<Product>>()
               {
                    Data = await _context.Product.ToListAsync()
                    
               };
               return response;
          }
     }
}
