using BikeStores.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Queries.Customer
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDTO>>
    {
        public string? FilterOn { get; set; }
        public string? FilterQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
