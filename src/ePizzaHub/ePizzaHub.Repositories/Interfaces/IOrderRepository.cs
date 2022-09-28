using System;
using ePizzaHub.Entities;

namespace ePizzaHub.Repositories.Interfaces
{
	public interface IOrderRepository : IRepository<Order>
	{
		Task<IEnumerable<Order>> GetUserOrders(int userId);
    }
}

