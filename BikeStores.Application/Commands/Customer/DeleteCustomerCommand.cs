using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Application.Commands.Customer
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
