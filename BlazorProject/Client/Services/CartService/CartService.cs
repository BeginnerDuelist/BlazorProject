using Blazored.LocalStorage;
using BlazorProject.Client.Services.AuthService;
using BlazorProject.Client.Services.ProductService;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System;

namespace BlazorProject.Client.Services.CartService
{
     public class CartService : ICartService
     {
          private readonly ILocalStorageService localStorageService;
          private readonly IJSRuntime jSRuntime;
          private readonly IProductService productService;
          private readonly IAuthService authService;
          private readonly NavigationManager navigationManager;

        public CartService(ILocalStorageService localStorageService, IJSRuntime jSRuntime,
        IProductService productService, IAuthService authService, NavigationManager navigationManager)
        {
               this.localStorageService = localStorageService;
               this.jSRuntime = jSRuntime;
               this.productService = productService;
               this.authService = authService;
               this.navigationManager = navigationManager;
        }

          public int Count { get; set; }

          public event Action? OnChange;

          public async Task AddToCart(MyCartModel myCartModel)
          {    
               if(await authService.IsUserAuthenticated())
               {
                    var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
                    if (MyCart == null)
                    {
                        MyCart = new List<MyCartModel>();
                    }

                    if (myCartModel != null)
                    {
                        var item = MyCart.FirstOrDefault(p => p.ProductId == myCartModel.ProductId);
                        if (item != null)
                        {
                            MyCart.Remove(item);
                            MyCart.Add(myCartModel);
                            await localStorageService.SetItemAsync("MyCart", MyCart);
                            await jSRuntime.InvokeVoidAsync("alert", "Product updated done!");
                        }
                        else
                        {
                            MyCart.Add(myCartModel);
                            await localStorageService.SetItemAsync("MyCart", MyCart);
                            await jSRuntime.InvokeVoidAsync("alert", "Product added to cart!");
                        }
                    }
                    else
                    {
                        await jSRuntime.InvokeVoidAsync("alert", "Product cart cannot be empty");
                    }

                    Count = (await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart")).Count();
                    OnChange?.Invoke();
               }
               else
               {
                    await jSRuntime.InvokeVoidAsync("alert","You need to login first");
               }
              

          }

          public async Task<List<CartModel>> GetCart()
          {
                var CartModel = new List<CartModel>();
                if (await authService.IsUserAuthenticated())
                {
                    
                    var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
                    if (MyCart != null)
                    {
                        foreach (var item in MyCart)
                        {
                            var product = await productService.GetProduct(item.ProductId);
                            if (product != null)
                            {
                                var model = new CartModel()
                                {
                                    ProductId = item.ProductId,
                                    Quantity = item.UserQuantity,
                                    Name = product.Data!.Title,
                                    Image = product.Data.ImageUrl,
                                    Price = product.Data.NewPrice != 0 && product.Data.NewPrice < product.Data.Price ?
                                    product.Data.NewPrice : product.Data.Price,
                                    SubTotal = (product.Data.NewPrice != 0 && product.Data.NewPrice < product.Data.Price ?
                                    product.Data.NewPrice : product.Data.Price) * item.UserQuantity
                                };
                                CartModel.Add(model);
                            }

                        }
                    }
                    
                }
                else
                {
                    await jSRuntime.InvokeVoidAsync("alert", "You need to be logged to see your cart");
                    navigationManager.NavigateTo("/");
                }
                return CartModel;

          }

          public async Task RemoveCartItem(int productId)
          {
               var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
               if (MyCart != null)
               {
                    var product = MyCart.FirstOrDefault(p => p.ProductId == productId);
                    if (product != null)
                    {
                         MyCart.Remove(product);
                         await localStorageService.SetItemAsync("MyCart", MyCart);
                    }
               }
          }
          public async Task RemoveAllCartItems()
          {
            var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
            // Remove all items from the cart in local storage
            await localStorageService.RemoveItemAsync("MyCart");

            // Update the count and trigger the OnChange event
            Count = 0;
            OnChange?.Invoke();
          }
    }
}

