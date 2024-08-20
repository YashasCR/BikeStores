using BikeStores.Infrastructure.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Commands.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerExists = await _customerRepository.DeleteCustomer(request.CustomerId);
            if (customerExists)
            {
                return $"Customer Id: {request.CustomerId} successfully deleted";
            }
            else
            {
                throw new KeyNotFoundException($"Customer with Id: {request.CustomerId} does not exist");
            }
        }
    }
}
