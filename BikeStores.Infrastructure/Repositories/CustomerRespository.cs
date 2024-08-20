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
    public class CustomerRespository : ICustomerRepository
    {
        private readonly BikeStoreDBContext _dbContext;

        public CustomerRespository(BikeStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers(string? filterOn = null, string? filterQuery = null)
        {
            var customers = _dbContext.Customers.AsQueryable();

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    customers = customers.Where(x => x.FirstName.Contains(filterQuery));
                }
                else if(filterOn.Equals("Email", StringComparison.OrdinalIgnoreCase))
                {
                    customers = customers.Where(x => x.Email.Contains(filterQuery));
                }

            }


            return await customers.ToListAsync();


        }

        public Customer GetCustomerById(int customerId)
        {
            return _dbContext.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerId == customerId);
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer.CustomerId;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
