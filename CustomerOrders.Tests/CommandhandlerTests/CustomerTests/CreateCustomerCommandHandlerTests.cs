using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
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
    public class CreateCustomerCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CreateCustomerCommandHandlers _handler;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Customer>>();
            _unitOfWorkMock.Setup(u => u.Customers).Returns(userRepositoryMock.Object);
            _handler = new CreateCustomerCommandHandlers(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldAddProduct()
        {
            // Arrange

            var command = new CreateCustomerCommand { FirstName = "ghgj" };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.Customers.AddAsync(It.Is<Customer>(prod => prod.FirstName == command.FirstName)), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

    }
}
