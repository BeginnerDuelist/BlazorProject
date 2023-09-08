using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
     public class ServiceModel<T>
     {
          public List<T>? MultipleData { get; set; }
          public T?  Data { get; set; }
          public bool Success { get; set; } = true;
          public string Message { get; set; }=string.Empty;
          public string? CssClass { get; set; } = "success";

     }
}
