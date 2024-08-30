using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.CreateOrderCommandHandlers;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class CreateOrderCommandHandlers : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public class Command : IRequest<Unit>
        {
            public List<Item> Items { get; set; }
            public decimal TotalPrice { get; set; }

        }
        public CreateOrderCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var order = new Order { Items = command.Items, TotalPrice = command.TotalPrice, OrderDate = DateTime.UtcNow, Isdeleted = false };
            _unitOfWork.Orders.AddAsync(order);
            _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
