using CustomerOrders.Application.Abstractions;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using static CustomerOrders.Application.Commands.Products.UpdateProducts.UpdateProductCommandHandler;

namespace CustomerOrders.Application.Commands.Products.UpdateProducts
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Result<Guid>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
                throw new CustomException($"product with ID {command.Id} not found.");

            product.Update(command.Name, command.Price, DateTime.UtcNow);
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }

 
    }
}
