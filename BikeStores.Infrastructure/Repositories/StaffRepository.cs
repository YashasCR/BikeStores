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
    public class StaffRepository : IStaffRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public StaffRepository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffs()
        {
            return await _dbContext.Staffs.ToListAsync();
        }

        public Staff GetStaffById(int staffId)
        {
            return _dbContext.Staffs.AsNoTracking().FirstOrDefault(x => x.StaffId == staffId);
        }

        public async Task<int> AddStaff(Staff staff)
        {
            _dbContext.Staffs.Add(staff);
            await _dbContext.SaveChangesAsync();
            return staff.StaffId;
        }

        public async Task<Staff> UpdateStaff(Staff staff)
        {
            _dbContext.Staffs.Update(staff);
            await _dbContext.SaveChangesAsync();
            return staff;
        }

        public async Task<bool> DeleteStaff(int staffId)
        {
            var staff = await _dbContext.Staffs.FirstOrDefaultAsync(x => x.StaffId == staffId);
            if (staff != null)
            {
                _dbContext.Staffs.Remove(staff);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
