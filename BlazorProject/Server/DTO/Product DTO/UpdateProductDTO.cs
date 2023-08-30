﻿namespace BlazorProject.Server.DTO.Product_DTO
{
     public class UpdateProductDTO
     {
          public string Title { get; set; } = string.Empty;
          public string Description { get; set; } = string.Empty;
          public string ImageUrl { get; set; } = string.Empty;
          public decimal Price { get; set; }
          public int CategoryId { get; set; }
     }
}