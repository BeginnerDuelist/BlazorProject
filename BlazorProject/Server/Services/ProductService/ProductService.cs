using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BlazorProject.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly BlazorProjectAPIDbContext appDbContext;

        public ProductService(BlazorProjectAPIDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<int> GetTotalProductsCount()
        {
            return await appDbContext.Product.CountAsync();
        }
        public async Task<ServiceModel<Product>> AddProductAsync(Product NewProduct)
        {
            var Response = new ServiceModel<Product>();
            if (NewProduct != null)
            {
                try
                {
                    appDbContext.Product.Add(NewProduct);
                    await appDbContext.SaveChangesAsync();
                    Response.Data = NewProduct;
                    Response.Success = true;
                    Response.Message = "Product added successfully!";
                    Response.CssClass = "success";
                    return Response;
                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.Data = null!;
                return Response;
            }
        }

        public async Task<ServiceModel<Product>> DeleteProductAsync(int id)
        {
            var response = new ServiceModel<Product>();
            var product = await GetProductAsync(id);
            if (product.Data != null)
            {
                appDbContext.Product.Remove(product.Data);
                await appDbContext.SaveChangesAsync();
                response.Message = "Product deleted!";
                response.CssClass = "success fw-bold";
                response.Data = product.Data;
                var products = await GetProductsAsync();
                response.MultipleData = products.MultipleData;
            }
            else
            {
                response.Message = product.Message;
                response.CssClass = product.CssClass;
            }
            return response;

        }

        public async Task<ServiceModel<Product>> GetProductAsync(int id)
        {
            var Response = new ServiceModel<Product>();
            if (id > 0)
            {
                try
                {
                    var product = await appDbContext.Product.SingleOrDefaultAsync(p => p.Id == id);
                    if (product != null)
                    {
                        Response.Data = product;
                        Response.Success = true;
                        Response.Message = "Product found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Sorry product you are looking for doesn't exist!";
                        Response.CssClass = "danger";
                        Response.Data = null!;
                        return Response;
                    }

                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.Data = null!;
                return Response;
            }
        }

        public async Task<ServiceModel<Product>> GetProductsByCategory(string url)
        {
            var Response = new ServiceModel<Product>();
            if (url != null)
            {
                try
                {
                    var product = await appDbContext.Product
                        .Where(p => p.Category!.Url == url.ToLower().Replace(" ", "-")).ToListAsync();
                    if (product != null)
                    {
                        Response.MultipleData = product;
                        Response.Success = true;
                        Response.Message = "Product found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Sorry product you are looking for doesn't exist!";
                        Response.CssClass = "danger";
                        Response.Data = null!;
                        return Response;
                    }

                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.Data = null!;
                return Response;
            }
        }

        public async Task<ServiceModel<Product>> GetProductsAsync()
        {
            var Response = new ServiceModel<Product>();
            try
            {
                var products = await appDbContext.Product.ToListAsync();
                if (products != null)
                {
                    Response.MultipleData = products;
                    Response.Success = true;
                    Response.Message = "Products found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "Sorry No products found!";
                    Response.CssClass = "info";
                    Response.Data = null!;
                    return Response;
                }

            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }

        public async Task<ServiceModel<Product>> UpdateProductAsync(Product NewProduct)
        {
            var response = new ServiceModel<Product>();
            if (NewProduct != null)
            {
                var product = await GetProductAsync(NewProduct.Id);
                if (product.Data != null)
                {
                    product.Data.Title = NewProduct.Title;
                    product.Data.Price = NewProduct.Price;
                    product.Data.NewPrice = NewProduct.NewPrice;
                    product.Data.Description = NewProduct.Description;
                    product.Data.Quantity = NewProduct.Quantity;
                    product.Data.ImageUrl = NewProduct.ImageUrl;
                    await appDbContext.SaveChangesAsync();
                    response.Message = "Product updated successfully !";
                    response.Success = true;
                    response.CssClass = "success fw-bold";
                    response.Data = product.Data;
                }
                else
                {
                    response.Message = "Sorry product not found";
                    response.Success = false;
                    response.CssClass = "danger fw-bold";
                }
            }
            else
            {
                response.Message = "Sorry product object is empty";
                response.Success = false;
                response.CssClass = "danger fw-bold";
            }
            return response;
        }
    }

}
