using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Application.Queries.Orders;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
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
    public class GetOrderCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetOrderQueryHandler _handler;
      
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IOrderRepository>();
            _unitOfWorkMock.Setup(u => u.Orders).Returns(userRepositoryMock.Object);
            _handler = new GetOrderQueryHandler(_unitOfWorkMock.Object);
            
        }

        [Test]
        public async Task Handle_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var items = new List<Item>();
            var customerId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            var expectedProduct = new Order(Guid.NewGuid(), Guid.NewGuid(), items, new Price(4), DateTime.UtcNow, DateTime.UtcNow, false);
            _unitOfWorkMock.Setup(u => u.Orders.GetByIdAsync(customerId)).ReturnsAsync(expectedProduct);

            var query = new GetOrderQuery { Id = customerId };

            // Act
            var user = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedProduct, user);
        }

        [Test]
        public void Handle_ShouldThrowCustomException_WhenProductDoesNotExist()
        {
            // Arrange
            var customerIdId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            _unitOfWorkMock.Setup(u => u.Orders.GetByIdAsync(customerIdId)).ReturnsAsync((Order)null);

            var query = new GetOrderQuery { Id = customerIdId };

            // Act & Assert
            Assert.ThrowsAsync<CustomException>(() => _handler.Handle(query, CancellationToken.None));
        }

    }
}
