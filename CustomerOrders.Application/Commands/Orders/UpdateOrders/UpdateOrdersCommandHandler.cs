using CustomerOrders.Application.Abstractions;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using System.Net;
using static CustomerOrders.Application.Commands.Customers.UpdateCustomers.UpdateCustomerCommandHandler;

namespace CustomerOrders.Application.Commands.Customers.UpdateCustomers
{
    public class UpdateOrdersCommandHandler : ICommandHandler<UpdateOrdersCommand, Guid>
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrdersCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Result<Guid>> Handle(UpdateOrdersCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(command.Id);
            if (order == null)
                throw new CustomException($"Customer with ID {command.Id} not found.");
            order.Update(command.TotalPrice, command.Items, command.CustomerId, DateTime.UtcNow);
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();

            return order.Id;
        }

 
    }
}
