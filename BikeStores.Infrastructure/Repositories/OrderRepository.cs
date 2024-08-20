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
    public class OrderRepository : IOrderRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public OrderRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.AsNoTracking().FirstOrDefault(x => x.OrderId == orderId);
        }

        public async Task<int> AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
