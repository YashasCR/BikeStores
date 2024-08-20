using BikeStores.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Queries.Customer
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public int CustomerId { get; set; }
    }
}
