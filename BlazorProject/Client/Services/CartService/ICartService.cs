using BlazorProject.Shared;

namespace BlazorProject.Client.Services.CartService
{
     public interface ICartService
     {
          event Action OnChange;
          int Count { get; set; }
          Task AddToCart(MyCartModel myCartModel);

          Task<List<CartModel>> GetCart();
          Task RemoveCartItem(int productId);
     }
}
