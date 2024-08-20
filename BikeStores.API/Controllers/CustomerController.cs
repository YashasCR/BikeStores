using BikeStores.Application.Commands.Customer;
using BikeStores.Application.DTO;
using BikeStores.Application.Queries.Customer;
using BikeStores.Application.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace BikeStores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;
        public CustomersController(ICustomerService customerService, IMediator mediator)
        {
            _customerService = customerService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery,
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 100)
        {
            var query = new GetAllCustomersQuery
            {
                FilterOn = filterOn,
                FilterQuery = filterQuery,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var customers = await _mediator.Send(query);
            if (customers == null)
            {
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentNullException($"Invalid Id: {customerId}");
            }

            var query = new GetCustomerByIdQuery { CustomerId = customerId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCustomerCommand(customer);
                var customerData = await _mediator.Send(command);
                return StatusCode(201, customerData);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO customer)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));

            var command = new UpdateCustomerCommand(customer);
            var result = await _mediator.Send(command);
            return StatusCode(200, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException($"CustomerId cannot be less than zero!");
            }

            var command = new DeleteCustomerCommand(id);
            var response = await _mediator.Send(command);
            return StatusCode(200, response);
        }
    }
}
