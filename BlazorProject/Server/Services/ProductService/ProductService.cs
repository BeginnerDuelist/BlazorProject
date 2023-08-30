
using BlazorProject.Server.DTO.Product_DTO;
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

          public async Task<ServiceResponse<Product>> AddProductAsync(CreateProductDTO product)
          {
               var newProduct = new Product()
               {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    CategoryId = product.CategoryId
               };
               _context.Product.Add(newProduct);
               await _context.SaveChangesAsync();
               var response = new ServiceResponse<Product>()
               {
                    Data = newProduct,
                    Message = "Added product"
               };
               return response;
          }

          public async Task<ServiceResponse<Product>> DeleteProductAsync(int id)
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
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                    response.Data = null!;
                    response.Message = "We deleted the product";
               }

               return response;

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

          public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryURL)
          {
               var response = new ServiceResponse<List<Product>>
               {
                    Data = await _context.Product
                              .Where(p => p.Category.Url.ToLower()== categoryURL.ToLower())
                              .ToListAsync()
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

          public bool ProductExists(int id)
          {
               return _context.Product.Any(e => e.Id == id);
          }

          public async Task<ServiceResponse<Product>> UpdateProductAsync(int id, UpdateProductDTO product)
          {
               var prod = await _context.Product.FindAsync(id);
               var response = new ServiceResponse<Product>();
               if (prod == null)
               {
                    response.Success = false;
                    response.Message = "Product not found";
                    response.Data = null!;
                    return response;
               }
               prod.Title = product.Title;
               prod.Description = product.Description;
               prod.ImageUrl = product.ImageUrl;
               prod.Price = product.Price;
               prod.CategoryId = product.CategoryId;

               try
               {
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Product updated succesful";
                    response.Data = prod;
                    return response;
               }
               catch (DbUpdateConcurrencyException)
               {
                    if (!ProductExists(id))
                    {
                         response.Success = false;
                         response.Message = "Product doesn't exist!!!";
                         response.Data = null!;
                         return response;
                    }
               }
               return response;
          }
     }
          
}
