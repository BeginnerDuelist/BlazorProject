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
               var response = new ServiceResponse<Product>()
               {
                    Data = await _context.Product.FindAsync(id)
               };
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
