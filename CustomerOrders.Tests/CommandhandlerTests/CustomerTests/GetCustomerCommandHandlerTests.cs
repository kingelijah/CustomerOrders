using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Tests.CommandhandlerTests.ProductTests
{
    [TestFixture]
    public class GetCustomerCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetCustomerQueryHandler _handler;
      
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Customer>>();
            _unitOfWorkMock.Setup(u => u.Customers).Returns(userRepositoryMock.Object);
            _handler = new GetCustomerQueryHandler(_unitOfWorkMock.Object);
            
        }

        [Test]
        public async Task Handle_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var customerId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            var expectedProduct = new Customer { Id = customerId, FirstName = "Test Product" };
            _unitOfWorkMock.Setup(u => u.Customers.GetByIdAsync(customerId)).ReturnsAsync(expectedProduct);

            var query = new GetCustomerQueryHandler.Query { Id = customerId };

            // Act
            var user = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedProduct, user);
        }

        [Test]
        public void Handle_ShouldThrowCustomException_WhenProductDoesNotExist()
        {
            // Arrange
            var customerId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            _unitOfWorkMock.Setup(u => u.Customers.GetByIdAsync(customerId)).ReturnsAsync((Customer)null);

            var query = new GetCustomerQueryHandler.Query { Id = customerId };

            // Act & Assert
            Assert.ThrowsAsync<CustomException>(() => _handler.Handle(query, CancellationToken.None));
        }

    }
}
