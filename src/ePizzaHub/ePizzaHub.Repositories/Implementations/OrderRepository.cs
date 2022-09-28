using System;
using ePizzaHub.Entities;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ePizzaHub.Repositories.Implementations
{
	public class OrderRepository : Repository<Order>, IOrderRepository 
	{

		public OrderRepository(DbContext dbContext) : base (dbContext)
		{
		}

        public async Task<IEnumerable<Order>> GetUserOrders(int userId)
        {
            return await AppDbContext.Orders
                    .Include(o => o.OrderItems)
                    .Where(u => u.UserId == userId)
                    .ToListAsync();
        }
    }
}

