using AutoMapper;
using BikeStores.Application.Services.Interface;
using BikeStores.Infrastructure.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Commands.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerService.UpdateCustomer(request.Customer);
            return result;
        }
    }
}
