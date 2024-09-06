using CustomerOrders.Application.Commands.Orders.DeleteOrders;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.Orders.DeleteOrders.DeleteOrderCommandHandler;

namespace CustomerOrders.Application.Commands.Orders.DeleteOrders
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
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
     
        public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(command.Id);
            if (order == null)
                throw new CustomException($"order with ID {command.Id} not found.");

            order.Delete();   
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
