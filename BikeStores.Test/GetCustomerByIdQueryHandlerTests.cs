using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using BikeStores.Application.DTO;
using BikeStores.Application.Queries;
using BikeStores.Application.Services.Interface;
using BikeStores.Application.Queries.Customer;

namespace BikeStores.Test
{
    public class GetCustomerByIdQueryHandlerTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;

        public GetCustomerByIdQueryHandlerTests()
        {
            _customerServiceMock = new Mock<ICustomerService>();
        }

        [Fact]
        public async Task Handle_ReturnsCustomer_WhenCustomerExists()
        {
 
            var customerId = 1;
            var customerDTO = new CustomerDTO { CustomerId = customerId, FirstName = "John", LastName = "Doe" };

            _customerServiceMock.Setup(service => service.GetCustomerById(customerId))
                .ReturnsAsync(customerDTO);

            var handler = new GetCustomerByIdQueryHandler(_customerServiceMock.Object);

            var query = new GetCustomerByIdQuery { CustomerId = customerId };


            var result = await handler.Handle(query, CancellationToken.None);


            Assert.NotNull(result);
            Assert.Equal(customerId, result.CustomerId);
        }

        [Fact]
        public async Task Handle_ThrowsKeyNotFoundException_WhenCustomerDoesNotExist()
        {

            var customerId = 99;

            _customerServiceMock.Setup(service => service.GetCustomerById(customerId))
                .ThrowsAsync(new KeyNotFoundException());

            var handler = new GetCustomerByIdQueryHandler(_customerServiceMock.Object);

            var query = new GetCustomerByIdQuery { CustomerId = customerId };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(query, CancellationToken.None));
        }
    }
}
