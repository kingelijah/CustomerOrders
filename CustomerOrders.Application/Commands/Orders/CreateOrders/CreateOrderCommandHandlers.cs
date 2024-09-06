using CustomerOrders.Application.Abstractions;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using System.Collections.Generic;
using static CustomerOrders.Application.Commands.Orders.CreateOrders.CreateOrderCommandHandlers;

namespace CustomerOrders.Application.Commands.Orders.CreateOrders
{
    public class CreateOrderCommandHandlers : ICommandHandler<CreateOrderCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CreateOrderCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order(Guid.NewGuid(), command.CustomerId, command.Items, new Price(command.TotalPrice), DateTime.UtcNow, DateTime.UtcNow, false);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();
            return order.Id;
        }
    }
}
