using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.Products;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using Moq;

namespace CustomerOrders.Tests.CommandhandlerTests.ProductTests
{
    [TestFixture]
    public class GetAllProductCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetAllProductsQueryHandler _handler;
       
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Product>>();
            _unitOfWorkMock.Setup(u => u.Products).Returns(userRepositoryMock.Object);
            _handler = new GetAllProductsQueryHandler(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(Guid.NewGuid(), false, DateTime.UtcNow, DateTime.UtcNow,"shirt", new Price(4)),
                new Product(Guid.NewGuid(), false, DateTime.UtcNow, DateTime.UtcNow,"shirt", new Price(4))
            };
            _unitOfWorkMock.Setup(u => u.Products.GetAllAsync()).ReturnsAsync(products);

            var query = new GetAllProductsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(products.Count, result.Count());
        }
      
    }
}
