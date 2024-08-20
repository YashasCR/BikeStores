using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();

        public Brand GetBrandById(int brandId);

        Task<int> AddBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand);

        Task<bool> DeleteBrand(int brandId);


    }
}
