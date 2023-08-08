using BakeryApplication.Repository;
using Microsoft.EntityFrameworkCore;

namespace BakeryApplication.Models
{
	public class ShoppingCart : IShoppingCart
	{
		private readonly ApplicationDbContext _context;

		public string? ShoppingCartId { get; set; }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

		private ShoppingCart(ApplicationDbContext context)
		{
			_context = context;
		}

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

			ApplicationDbContext context = services.GetService<ApplicationDbContext>() ?? throw new Exception("Error initializing");

			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", cartId);

			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

		public void AddToCart(Product product)
		{
			var ShoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

			if (ShoppingCartItem == null)
			{
				ShoppingCartItem = new ShoppingCartItem
				{
					ShoppingCartId = ShoppingCartId,
					Product = product,
					Amount = 1
				};
				_context.ShoppingCartItems.Add(ShoppingCartItem);
			}
			else
			{
				ShoppingCartItem.Amount++;
			}

			_context.SaveChanges();
		}

		public int RemoveFromCart(Product product)
		{
			var ShoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

			var localAmount = 0;

			if (ShoppingCartItem != null)
			{
				if (ShoppingCartItem.Amount > 1)
				{
					ShoppingCartItem.Amount--;
					localAmount = ShoppingCartItem.Amount;
				}
				else
				{
					_context.ShoppingCartItems.Remove(ShoppingCartItem);
				}
			}

			_context.SaveChanges();

			return localAmount;
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ??= _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Product).ToList();
		}

		public void ClearCart()
		{
			var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

			_context.ShoppingCartItems.RemoveRange(cartItems);

			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotal()
		{
			var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Product.Price * c.Amount).Sum();

			return total;
		}
    }
}
