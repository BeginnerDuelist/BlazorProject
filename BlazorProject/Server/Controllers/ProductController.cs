using System;
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
          private static List<Product> Products = new List<Product>()
          {

               new Product
               {
                    Id = 1,
                    Title = "Laptop Gaming ASUS TUF F17 FX706HF / i5-11400H / 17.3 inch / 16GB / 1TB SSD / RTX 2050 / Graphite Black",
                    Description = "Laptop Gaming ASUS TUF F17 FX706HF cu procesor Intel® Core™ i5-11400H pana la 4.50 GHz, 17.3 Full HD, IPS, 144Hz, 16GB, 1TB SSD, NVIDIA® GeForce RTX™ 2050 4GB GDDR6 TGP 55W, No OS, Graphite Black",
                    ImageUrl = "https://www.smart.md/image/cache/data/results-photos/emagtv/Laptop-Gaming-ASUS-TUF-F17-FX706HF-cu-procesor-Intel-Core-i5-11400H-pana-la-4-50-GHz-17-3-Full-HD-IP-536x536.jpg",
                    Price = 12990.78m
               },
               new Product
               {
                    Id = 2,
                    Title = "Laptop Gaming Acer Nitro 5 AN515-57 / i5-11400H / 16GB / 512GB SSD / GTX 1650",
                    Description = "Cauti un laptop de gaming care sa tina pasul cu reflexele tale fulgeratoare si cu dorinta ta de imersiune profunda? Nu cauta mai departe decat Acer Nitro 5 AN515-57, o masina eleganta si puternica, care are tot ce ai nevoie pentru a domina in jocurile tale preferate.",
                    ImageUrl = "https://www.smart.md/image/cache/data/results-photos/emag2511/laptop-gaming-acer-nitro-5-an515-57-cu-procesor-intel-core-i5-11400h-pana-la-450-ghz-156quot-full-hd-536x536.jpg",
                    Price = 23980.98m
               },
               new Product
               {
                    Id = 3,
                    Title = "Laptop Lenovo IdeaPad Gaming 3 15ACH6 / Ryzen 5 5600H / 16GB / 512GB SSD / RTX 3050",
                    Description = "Cand vine vorba de jocuri, a avea hardware-ul potrivit poate face sau distruge experienta ta. Cu laptopul Lenovo IdeaPad Gaming 3 15ACH6, poti experimenta performante imbatabile in timp ce joci dupa pofta inimii tale. Aceasta masina puternica dispune de un procesor Ryzen 5 5600H, 16 GB de RAM DDR4, un SSD de 512 GB si o placa grafica NVIDIA GeForce RTX 3050; acest dispozitiv este arma suprema pentru a ucide orice joc care iti iese in cale.",
                    ImageUrl = "https://www.smart.md/image/cache/data/results-photos/emag1/res_a5f8abbd405e0e7ed46c6dcb761751bb-536x536.jpg",
                    Price = 10200.99m
               }
          };
          [HttpGet]
          public async Task<IActionResult> GetProduct()
          {
               return Ok(Products);
     }
     }
}
////          private readonly BlazorProjectAPIDbContext _context;

////        public ProductController(BlazorProjectAPIDbContext context)
////        {
////            _context = context;
////        }

////        // GET: api/Product
////        [HttpGet]
////        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
////        {
////          if (_context.Product == null)
////          {
////              return NotFound();
////          }
////            return await _context.Product.ToListAsync();
////        }

////        // GET: api/Product/5
////        [HttpGet("{id}")]
////        public async Task<ActionResult<Product>> GetProduct(int id)
////        {
////          if (_context.Product == null)
////          {
////              return NotFound();
////          }
////            var product = await _context.Product.FindAsync(id);

////            if (product == null)
////            {
////                return NotFound();
////            }

////            return product;
////        }

////        // PUT: api/Product/5
////        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
////        [HttpPut("{id}")]
////        public async Task<IActionResult> PutProduct(int id, Product product)
////        {
////            if (id != product.Id)
////            {
////                return BadRequest();
////            }

////            _context.Entry(product).State = EntityState.Modified;

////            try
////            {
////                await _context.SaveChangesAsync();
////            }
////            catch (DbUpdateConcurrencyException)
////            {
////                if (!ProductExists(id))
////                {
////                    return NotFound();
////                }
////                else
////                {
////                    throw;
////                }
////            }

////            return NoContent();
////        }

////        // POST: api/Product
////        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
////        [HttpPost]
////        public async Task<ActionResult<Product>> PostProduct(Product product)
////        {
////          if (_context.Product == null)
////          {
////              return Problem("Entity set 'BlazorProjectAPIDbContext.Product'  is null.");
////          }
////            _context.Product.Add(product);
////            await _context.SaveChangesAsync();

////            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
////        }

////        // DELETE: api/Product/5
////        [HttpDelete("{id}")]
////        public async Task<IActionResult> DeleteProduct(int id)
////        {
////            if (_context.Product == null)
////            {
////                return NotFound();
////            }
////            var product = await _context.Product.FindAsync(id);
////            if (product == null)
////            {
////                return NotFound();
////            }

////            _context.Product.Remove(product);
////            await _context.SaveChangesAsync();

////            return NoContent();
////        }

////        private bool ProductExists(int id)
////        {
////            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
////        }
//    }
//}
