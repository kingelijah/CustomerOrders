using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.CreateCustomerCommandHandlers;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class CreateCustomerCommandHandlers : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public class Command : IRequest<Unit>
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Address { get; set; }
            public string? PostalCode { get; set; }

        }
        public CreateCustomerCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var customer = new Customer { FirstName = command.FirstName, LastName = command.LastName, Address = command.Address, PostalCode = command.PostalCode, DateCreated = DateTime.UtcNow, IsDeleted = false };
            _unitOfWork.Customers.AddAsync(customer);
            _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
