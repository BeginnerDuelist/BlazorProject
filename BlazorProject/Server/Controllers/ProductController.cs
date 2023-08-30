﻿using System;
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
          public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
          {
               var result = await _productService.GetProductsAsync();
               return Ok(result);
          }

          // GET: api/Product/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Product>> GetProduct(int id)
          {
               var result = await _productService.GetProductAsync(id);
               return Ok(result);
          }

          [HttpGet("category/{categoryURL}")]
          public async Task<ActionResult<Product>> GetProductsbyCategory(string categoryURL)
          {
               var result = await _productService.GetProductByCategory(categoryURL);
               return Ok(result);
          }

          [HttpPost]
          public async Task<ActionResult<Product>> AddProduct(CreateProductDTO product)
          {
               var result = await _productService.AddProductAsync(product);
               return Ok(result);
          }

          [HttpDelete("{id}")]
          public async Task<ActionResult<Product>> DeleteProduct(int id)
          {
               var result=await _productService.DeleteProductAsync(id);
               return Ok(result);
          }

          [HttpPut("{id}")]
          public async Task<ActionResult> UpdateProduct(int id,UpdateProductDTO product)
          {
               var result = await _productService.UpdateProductAsync(id, product);
               return Ok(result);
          }
         
     }
}
