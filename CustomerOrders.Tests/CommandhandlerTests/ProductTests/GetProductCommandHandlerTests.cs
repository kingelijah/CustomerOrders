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
    public class GetProductCommanddHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetProductQueryHandler _handler;
      
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Product>>();
            _unitOfWorkMock.Setup(u => u.Products).Returns(userRepositoryMock.Object);
            _handler = new GetProductQueryHandler(_unitOfWorkMock.Object);
            
        }

        [Test]
        public async Task Handle_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            var expectedProduct = new Product { Id = productId, Name = "Test Product" };
            _unitOfWorkMock.Setup(u => u.Products.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);

            var query = new GetProductQueryHandler.Query { Id = productId };

            // Act
            var user = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedProduct, user);
        }

        [Test]
        public void Handle_ShouldThrowCustomException_WhenProductDoesNotExist()
        {
            // Arrange
            var userId = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8");
            _unitOfWorkMock.Setup(u => u.Products.GetByIdAsync(userId)).ReturnsAsync((Product)null);

            var query = new GetProductQueryHandler.Query { Id = userId };

            // Act & Assert
            Assert.ThrowsAsync<CustomException>(() => _handler.Handle(query, CancellationToken.None));
        }

    }
}
