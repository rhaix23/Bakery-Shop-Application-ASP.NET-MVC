using BakeryApplication.Models;

namespace BakeryApplication.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private ApplicationDbContext _context;
		private readonly IShoppingCart _shoppingCart;

		public OrderRepository(ApplicationDbContext context, IShoppingCart shoppingCart)
		{
			_context = context;
			_shoppingCart = shoppingCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderPlaced = DateTime.Now;

			List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
			order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

			order.OrderDetails = new List<OrderDetail>();

			foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
			{
				OrderDetail orderDetail = new OrderDetail
				{
					Amount = shoppingCartItem.Amount,
					Price = shoppingCartItem.Product.Price,
					ProductId = shoppingCartItem.Product.Id
				};
				order.OrderDetails.Add(orderDetail);
			}

			_context.Orders.Add(order);

			_context.SaveChanges();
		}
	}
}
