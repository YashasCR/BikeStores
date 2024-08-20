using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync();
        Task<Stock> GetStockByIdAsync(int storeId, int productId);
        Task AddStockAsync(Stock stock);
        Task<Stock> UpdateStockAsync(Stock stock);
        Task<bool> DeleteStockAsync(int storeId, int productId);
    }
}
