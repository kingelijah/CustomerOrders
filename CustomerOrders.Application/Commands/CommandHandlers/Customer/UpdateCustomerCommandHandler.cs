using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.UpdateCustomerCommandHandler;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<Command, Unit>
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Address { get; set; }
            public string? PostalCode { get; set; }
        }
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(command.Id);
            if (customer == null)
                throw new CustomException($"Customer with ID {command.Id} not found.");

            customer.FirstName = command.FirstName;
            _unitOfWork.Customers.UpdateAsync(customer);
            _unitOfWork.CompleteAsync();

            return Unit.Value;
        }

 
    }
}
