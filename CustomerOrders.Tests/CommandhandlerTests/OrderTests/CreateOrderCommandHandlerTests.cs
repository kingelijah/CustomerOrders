using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Orders.CreateOrders;
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
    public class CreateOrderCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CreateOrderCommandHandlers _handler;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IOrderRepository>();
            _unitOfWorkMock.Setup(u => u.Orders).Returns(userRepositoryMock.Object);
            _handler = new CreateOrderCommandHandlers(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldAddProduct()
        {
            // Arrange

            var command = new CreateOrderCommand { CustomerId = new Guid("AA9BEBB5-3ED8-4447-83CC-08DCCD0E5847"), TotalPrice = 4};

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.Orders.AddAsync(It.Is<Order>(prod => prod.CustomerId == command.CustomerId)), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

    }
}
