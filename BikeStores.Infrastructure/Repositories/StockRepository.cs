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
    public class StockRepository : IStockRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public StockRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await _dbContext.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStockByIdAsync(int storeId, int productId)
        {
            return await _dbContext.Stocks
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StoreId == storeId && s.ProductId == productId);
        }

        public async Task AddStockAsync(Stock stock)
        {
            await _dbContext.Stocks.AddAsync(stock);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Stock> UpdateStockAsync(Stock stock)
        {
            _dbContext.Stocks.Update(stock);
            await _dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> DeleteStockAsync(int storeId, int productId)
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(s => s.StoreId == storeId && s.ProductId == productId);

            if (stock != null)
            {
                _dbContext.Stocks.Remove(stock);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
