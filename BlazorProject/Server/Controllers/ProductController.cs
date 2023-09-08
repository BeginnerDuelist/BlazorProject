using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Shared;
using BlazorProject.Server.DTO.Product_DTO;

namespace BlazorProject.Server.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class ProductController : ControllerBase
     { 
          private readonly IProductService _productService;
          private readonly BlazorProjectAPIDbContext _context;

          public ProductController(IProductService productService, BlazorProjectAPIDbContext context)
          {
               
               _productService = productService;
               _context = context;
          }

          // GET: api/Product
          [HttpGet]
          public async Task<ActionResult<ServiceModel<List<Product>>>> GetProduct()
          {
               var result = await _productService.GetProductsAsync();
               return Ok(result);
          }

          // GET: api/Product/5
          [HttpGet("Get-Product/{id:int}")]
          public async Task<ActionResult<Product>> GetProduct(int id)
          {
               var result = await _productService.GetProductAsync(id);
               return Ok(result);
          }

          [HttpGet("category/{url}")]
          public async Task<ActionResult<Product>> GetProductsbyCategory(string url)
          {
               var result = await _productService.GetProductsByCategory(url);
               return Ok(result);
          }

          [HttpPost("Add-Product")]
          public async Task<ActionResult<Product>> AddProduct(Product product)
          {
               var result = await _productService.AddProductAsync(product);
               return Ok(result);
          }

          [HttpDelete("{id}")]
          public async Task<ActionResult<Product>> DeleteProduct(int id)
          {
               var result = await _productService.DeleteProductAsync(id);
               return Ok(result);
          }

          [HttpPut]
          public async Task<ActionResult> UpdateProduct(Product product)
          {
               var result = await _productService.UpdateProductAsync(product);
               return Ok(result);
          }
         
     }
}
