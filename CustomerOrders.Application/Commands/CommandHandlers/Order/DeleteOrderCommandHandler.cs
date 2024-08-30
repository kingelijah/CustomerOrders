using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.DeleteOrderCommandHandler;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<Command, Unit>
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(command.Id);
            if (order == null)
                throw new CustomException($"order with ID {command.Id} not found.");

            order.Isdeleted = true;   
            _unitOfWork.Orders.UpdateAsync(order);
            _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
