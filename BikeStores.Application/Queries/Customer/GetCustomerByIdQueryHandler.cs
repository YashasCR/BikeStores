using BikeStores.Application.DTO;
using BikeStores.Application.Services.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Queries.Customer
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerById(request.CustomerId);
        }
    }
}
