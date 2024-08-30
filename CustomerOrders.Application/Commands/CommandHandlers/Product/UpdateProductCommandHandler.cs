using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.UpdateProductCommandHandler;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<Command, Unit>
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new CustomException($"product with ID {command.Id} not found.");

            product.Name = command.Name;
            _unitOfWork.Products.UpdateAsync(product);
            _unitOfWork.CompleteAsync();

            return Unit.Value;
        }

 
    }
}
