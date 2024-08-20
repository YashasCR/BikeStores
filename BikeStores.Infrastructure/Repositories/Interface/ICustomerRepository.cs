using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure.Repositories.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers( string? filterOn= null, string? filterQuery=null);
        Customer GetCustomerById(int customerId);
        Task<int> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int customerId);

    }
}
