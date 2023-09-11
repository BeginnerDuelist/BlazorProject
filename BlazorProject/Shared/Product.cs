using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
     public class Product
     {
          public int Id { get; set; }
          [StringLength(70, MinimumLength = 25)]
          public string Title { get; set; }=string.Empty;
          public string Description { get; set; } = string.Empty;
          public string ImageUrl { get; set; } = string.Empty;
          public decimal Price { get; set; }
          public decimal NewPrice {  get; set; }
          public int Quantity { get; set; }
          public Category? Category { get; set; }
          public int CategoryId { get; set; }
          public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

     }
}
