using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
     public class CartModel
     {
          public int ProductId { get; set; }
          public string? Name { get; set; }
          public string? Image { get; set; }
          public decimal Price { get; set; }
          public int Quantity { get; set; }
          public decimal SubTotal { get; set; }
     }
}
