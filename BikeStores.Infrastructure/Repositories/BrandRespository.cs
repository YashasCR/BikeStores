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
    public class BrandRespository : IBrandRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public BrandRespository(BikeStoreDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _dbContext.Brands.ToListAsync();
        }

        public Brand GetBrandById(int brandId)
        {
            return _dbContext.Brands.AsNoTracking().FirstOrDefault(x => x.BrandId == brandId);
        }

        public async Task<int> AddBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return brand.BrandId;
        }

        public async Task<Brand> UpdateBrand(Brand brand)
        {
            _dbContext.Brands.Update(brand);
            await _dbContext.SaveChangesAsync();
            return brand;
        }

        public async Task<bool> DeleteBrand(int brandId)
        {
            var brand = await _dbContext.Brands.FirstOrDefaultAsync(x => x.BrandId == brandId);
            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
