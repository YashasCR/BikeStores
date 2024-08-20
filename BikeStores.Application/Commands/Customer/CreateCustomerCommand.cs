using BikeStores.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Commands.Customer
{
    public class CreateCustomerCommand : IRequest<string>
    {
        public CreateCustomerDTO CustomerDTO { get; set; }

        public CreateCustomerCommand(CreateCustomerDTO customerDTO)
        {
            CustomerDTO = customerDTO;
        }
    }
}
