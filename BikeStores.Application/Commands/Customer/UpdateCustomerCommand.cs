using BikeStores.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Commands.Customer
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public UpdateCustomerDTO Customer { get; set; }

        public UpdateCustomerCommand(UpdateCustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
