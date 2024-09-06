using CustomerOrders.Application.Abstractions;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Products.CreateProducts;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using System.Diagnostics;
using System.Xml.Linq;
using static CustomerOrders.Application.Commands.Products.CreateProducts.CreateProductCommandHandlers;

namespace CustomerOrders.Application.Commands.Products.CreateProducts
{
    public class CreateProductCommandHandlers : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CreateProductCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Result<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), false, DateTime.UtcNow, DateTime.UtcNow,command.Name,new Price(command.Price));
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
