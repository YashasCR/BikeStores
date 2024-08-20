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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public CategoryRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public async Task<int> AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
