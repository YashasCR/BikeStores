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
    public class ProductRepository : IProductRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public ProductRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == productId);
        }

        public async Task<int> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
