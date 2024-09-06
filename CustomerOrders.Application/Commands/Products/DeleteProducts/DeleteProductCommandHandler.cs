using CustomerOrders.Application.Commands.Products.DeleteProducts;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.DeleteProductCommandHandler;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new CustomException($"product with ID {command.Id} not found.");

            product.Delete();   
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
