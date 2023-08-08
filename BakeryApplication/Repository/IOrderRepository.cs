using BakeryApplication.Models;

namespace BakeryApplication.Repository
{
	public interface IOrderRepository
	{
		void CreateOrder(Order order); 
	}
}
