using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.Customers;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using Moq;

namespace CustomerOrders.Tests.CommandhandlerTests.ProductTests
{
    [TestFixture]
    public class GetAllCustomerCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetAllCustomersQueryHandler _handler;
       
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Customer>>();
            _unitOfWorkMock.Setup(u => u.Customers).Returns(userRepositoryMock.Object);
            _handler = new GetAllCustomersQueryHandler(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldReturnAllProducts()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "elijah","Manuel","68 close","785696", DateTime.UtcNow,DateTime.UtcNow, false),
                 new Customer(Guid.NewGuid(), "elijah","Manuel","68 close","785696", DateTime.UtcNow,DateTime.UtcNow, false) 
            };
            _unitOfWorkMock.Setup(u => u.Customers.GetAllAsync()).ReturnsAsync(customers);

            var query = new GetAllCustomersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(customers.Count, result.Count());
        }

    }
}
