using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Order GetOrderById(int orderId);

        Task<int> AddOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<bool> DeleteOrder(int orderId);

    }
}
