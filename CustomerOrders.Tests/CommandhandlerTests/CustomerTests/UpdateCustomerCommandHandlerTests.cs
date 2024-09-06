using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
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
    public class UpdateCustomerCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private UpdateCustomerCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Customer>>();
            _unitOfWorkMock.Setup(u => u.Customers).Returns(userRepositoryMock.Object);
            _handler = new UpdateCustomerCommandHandler(_unitOfWorkMock.Object);
          
        }

        [Test]
        public async Task Handle_ShouldUpdateProduct_WhenProductExists()
        {
            // Arrange
            var customerId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            var command = new UpdateCustomerCommand { Id = customerId, FirstName = "Updated Name" };
            var customer = new Customer(Guid.NewGuid(), "elijah", "Manuel", "68 close", "785696", DateTime.UtcNow, DateTime.UtcNow, false);
            _unitOfWorkMock.Setup(u => u.Customers.GetByIdAsync(customerId)).ReturnsAsync(customer);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Updated Name", customer.FirstName);
            _unitOfWorkMock.Verify(u => u.Customers.UpdateAsync(customer), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

    }
}
