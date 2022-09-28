using System;
using ePizzaHub.Entities;

namespace ePizzaHub.Repositories.Interfaces
{
	public interface ICartRepository : IRepository<Cart>
	{
		Task<Cart> GetCart(Guid id);

		Task<int> DeleteItem(Guid cartId, int itemId);

		Task<int> UpdatedQuantity(Guid cartId, int itemId, int Quantity);

		Task<int> UpdateCart(Guid cartId, int userId);
	}
}

