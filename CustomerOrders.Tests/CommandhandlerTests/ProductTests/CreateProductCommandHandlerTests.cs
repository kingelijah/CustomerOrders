using CustomerOrders.Application.Commands.CommandHandlers;
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
    public class CreateProductCommanddHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CreateProductCommandHandlers _handler;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Product>>();
            _unitOfWorkMock.Setup(u => u.Products).Returns(userRepositoryMock.Object);
            _handler = new CreateProductCommandHandlers(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldAddProduct()
        {
            // Arrange

            var command = new CreateProductCommandHandlers.Command { Name = "Test Product" };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.Products.AddAsync(It.Is<Product>(prod => prod.Name == command.Name)), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

    }
}
