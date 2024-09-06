using CustomerOrders.Application.Abstractions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Domain.Shared;
using MediatR;
using static CustomerOrders.Application.Commands.Customers.CreateCustomers.CreateCustomerCommandHandlers;

namespace CustomerOrders.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerCommandHandlers : ICommandHandler<CreateCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CreateCustomerCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Result<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer(Guid.NewGuid(), command.FirstName,command.LastName,command.Address,command.PostalCode, DateTime.UtcNow,DateTime.UtcNow, false);
            _unitOfWork.Customers.AddAsync(customer);
            _unitOfWork.CompleteAsync();
            return customer.Id;
        }
    }
}
