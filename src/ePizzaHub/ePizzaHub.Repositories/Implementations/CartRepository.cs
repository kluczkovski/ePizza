using System;
using ePizzaHub.Entities;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ePizzaHub.Repositories.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        /*
        private AppDbContext appDbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        } */

        public CartRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetCart(Guid id)
        {
            return await AppDbContext.Carts
                .Include("Items")
                .Where(c => c.Id == id && c.IsActive == true)
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteItem(Guid cartId, int itemId)
        {
            var item = await AppDbContext.CartItems
                .Where(i => i.CartId == cartId && i.ItemId == itemId)
                .FirstOrDefaultAsync();
            if (item != null)
            {
                AppDbContext.CartItems.Remove(item);
            }

            return await AppDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdatedQuantity(Guid cartId, int itemId, int Quantity)
        {
            var item = await AppDbContext.CartItems
                .Where(i => i.CartId == cartId && i.ItemId == itemId)
                .FirstOrDefaultAsync();
            if (item != null)
            {
                item.Quantity += Quantity;
                AppDbContext.CartItems.Update(item);
            }

            return await AppDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCart(Guid cartId, int userId)
        {
            var cart = await AppDbContext.Carts
                    .Where(c => c.Id == cartId)
                    .FirstOrDefaultAsync();

            if (cart != null)
            {
                cart.UserId = userId;
                AppDbContext.Carts.Update(cart);
            }

            return await AppDbContext.SaveChangesAsync();
        }
    }
}

