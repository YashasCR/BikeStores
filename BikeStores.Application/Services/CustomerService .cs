using AutoMapper;
using BikeStores.Application.DTO;
using BikeStores.Application.Services.Interface;
using BikeStores.Infrastructure.Repositories.Interface;
using BikeStores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers(string? filterOn = null, string? filterQuery = null, int pageNumber = 1, int pageSize = 10)
        {
            var customers = await _customerRepository.GetAllCustomers(filterOn, filterQuery);

            if (customers.Any())
            {
                var pagedCustomers = customers
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return _mapper.Map<List<CustomerDTO>>(pagedCustomers);
            }

            return null;
        }

        public async Task<CustomerDTO> GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id: {customerId} does not exist");
            }
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<string> AddCustomer(CreateCustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            await _customerRepository.AddCustomer(customerEntity);
            return $"Customer {customerEntity.CustomerId} added successfully";
        }

        public async Task<string> UpdateCustomer(UpdateCustomerDTO customer)
        {
            var existingCustomer = _customerRepository.GetCustomerById(customer.CustomerId);
            if (existingCustomer != null)
            {
                var updatedCustomer = _mapper.Map<Customer>(customer);
                await _customerRepository.UpdateCustomer(updatedCustomer);
                return "Customer updated successfully";
            }
            else
            {
                throw new KeyNotFoundException($"Customer with Id: {customer.CustomerId} does not exist");
            }
        }

        public async Task<string> DeleteCustomer(int customerId)
        {
            var customerExists = await _customerRepository.DeleteCustomer(customerId);
            if (customerExists)
            {
                return $"Customer Id: {customerId} successfully deleted";
            }
            else
            {
                throw new KeyNotFoundException($"Customer with Id: {customerId} does not exist");
            }
        }
    }
}
