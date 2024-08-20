using BikeStores.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomers(string? filterOn = null, string? filterQuery = null, int pageNumber = 1, int pageSize = 10);
        Task<CustomerDTO> GetCustomerById(int customerId);
        Task<string> AddCustomer(CreateCustomerDTO customer);
        Task<string> UpdateCustomer(UpdateCustomerDTO customer);
        Task<string> DeleteCustomer(int customerId);
    }
}
