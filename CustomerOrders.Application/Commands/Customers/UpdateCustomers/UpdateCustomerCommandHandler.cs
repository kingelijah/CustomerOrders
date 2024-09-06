using CustomerOrders.Application.Abstractions;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using System.Net;
using static CustomerOrders.Application.Commands.Customers.UpdateCustomers.UpdateCustomerCommandHandler;

namespace CustomerOrders.Application.Commands.Customers.UpdateCustomers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Guid>
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Result<Guid>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(command.Id);
            if (customer == null)
                throw new CustomException($"Customer with ID {command.Id} not found.");
            customer.Update(command.FirstName,command.LastName,command.Address,command.PostalCode, DateTime.UtcNow);
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.CompleteAsync();

            return customer.Id;
        }

 
    }
}
