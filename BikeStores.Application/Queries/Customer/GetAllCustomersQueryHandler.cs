using AutoMapper;
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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDTO>>
    {
        private readonly ICustomerService _customerService;


        public GetAllCustomersQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetAllCustomers(
                request.FilterOn,
                request.FilterQuery,
                request.PageNumber,
                request.PageSize
            );
            return customers;
        }
    }
}
