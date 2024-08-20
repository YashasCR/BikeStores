using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItems();
        OrderItem GetOrderItemById(int orderId, int itemId);
        Task<int> AddOrderItem(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItem(int orderId, int itemId);

    }
}
