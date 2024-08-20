using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffs();
        Staff GetStaffById(int staffId);
        Task<int> AddStaff(Staff staff);
        Task<Staff> UpdateStaff(Staff staff);
        Task<bool> DeleteStaff(int staffId);
    }
}
