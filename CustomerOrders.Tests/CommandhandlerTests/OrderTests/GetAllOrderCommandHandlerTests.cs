using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using Moq;

namespace CustomerOrders.Tests.CommandhandlerTests.ProductTests
{
    [TestFixture]
    public class GetAllOrderCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GetAllOrdersQueryHandler _handler;
       
        [SetUp]
        public void SetUp()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var userRepositoryMock = new Mock<IRepository<Order>>();
            _unitOfWorkMock.Setup(u => u.Orders).Returns(userRepositoryMock.Object);
            _handler = new GetAllOrdersQueryHandler(_unitOfWorkMock.Object);

        }

        [Test]
        public async Task Handle_ShouldReturnAllProducts()
        {
            // Arrange
            var customers = new List<Order>
            {
                new Order { Id = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8"), TotalPrice = 2 },
                new Order { Id = new Guid("1F3444C0-289B-42C5-9806-08DCC4E8D7F8"), TotalPrice = 3 }
            };
            _unitOfWorkMock.Setup(u => u.Orders.GetAllAsync()).ReturnsAsync(customers);

            var query = new GetAllOrdersQueryHandler.Query();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(customers.Count, result.Count());
        }
      
    }
}
