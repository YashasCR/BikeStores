using BikeStores.Domain.Entities;
using BikeStores.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public OrderItemRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public OrderItem GetOrderItemById(int orderId, int itemId)
        {
            return _dbContext.OrderItems.AsNoTracking().FirstOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
        }

        public async Task<int> AddOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem.OrderId;
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> DeleteOrderItem(int orderId, int itemId)
        {
            var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderId == orderId && x.ItemId == itemId);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
