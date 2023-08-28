﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Shared;

namespace BlazorProject.Server.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class ProductController : ControllerBase
     {
          private readonly BlazorProjectAPIDbContext _context;

          public ProductController(BlazorProjectAPIDbContext context)
          {
               _context = context;
          }

          // GET: api/Product
          [HttpGet]
          public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
          {
               if (_context.Product == null)
               {
                    return NotFound();
               }
               return await _context.Product.ToListAsync();
          }

          // GET: api/Product/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Product>> GetProduct(int id)
          {
               if (_context.Product == null)
               {
                    return NotFound();
               }
               var product = await _context.Product.FindAsync(id);

               if (product == null)
               {
                    return NotFound();
               }

               return product;
          }

          // PUT: api/Product/5
          // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
          [HttpPut("{id}")]
          public async Task<IActionResult> PutProduct(int id, Product product)
          {
               if (id != product.Id)
               {
                    return BadRequest();
               }

               _context.Entry(product).State = EntityState.Modified;

               try
               {
                    await _context.SaveChangesAsync();
               }
               catch (DbUpdateConcurrencyException)
               {
                    if (!ProductExists(id))
                    {
                         return NotFound();
                    }
                    else
                    {
                         throw;
                    }
               }

               return NoContent();
          }

          // POST: api/Product
          // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
          [HttpPost]
          public async Task<ActionResult<Product>> PostProduct(Product product)
          {
               if (_context.Product == null)
               {
                    return Problem("Entity set 'BlazorProjectAPIDbContext.Product'  is null.");
               }
               _context.Product.Add(product);
               await _context.SaveChangesAsync();

               return CreatedAtAction("GetProduct", new { id = product.Id }, product);
          }

          // DELETE: api/Product/5
          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteProduct(int id)
          {
               if (_context.Product == null)
               {
                    return NotFound();
               }
               var product = await _context.Product.FindAsync(id);
               if (product == null)
               {
                    return NotFound();
               }

               _context.Product.Remove(product);
               await _context.SaveChangesAsync();

               return NoContent();
          }

          private bool ProductExists(int id)
          {
               return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
          }
     }
}
