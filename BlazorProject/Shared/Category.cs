using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
     public class Category
     {
          public int Id { get; set; }
          public string Name { get; set; }= string.Empty;
          public string Url { get; set; } = string.Empty;
          public string? Image { get;set; } = string.Empty;
          public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
     }
}
