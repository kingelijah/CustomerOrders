using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Products.UpdateProducts;
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
    public class UpdateProductCommanddHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private UpdateProductCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Product>>();
            _unitOfWorkMock.Setup(u => u.Products).Returns(userRepositoryMock.Object);
            _handler = new UpdateProductCommandHandler(_unitOfWorkMock.Object);
          
        }

        [Test]
        public async Task Handle_ShouldUpdateProduct_WhenProductExists()
        {
            // Arrange
            var productId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            var command = new UpdateProductCommand { Id = productId, Name = "Updated Name" };
            var product = new Product(Guid.NewGuid(), false, DateTime.UtcNow, DateTime.UtcNow, "shirt", new Price(4));
            _unitOfWorkMock.Setup(u => u.Products.GetByIdAsync(productId)).ReturnsAsync(product);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Updated Name", product.Name);
            _unitOfWorkMock.Verify(u => u.Products.UpdateAsync(product), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

    }
}
