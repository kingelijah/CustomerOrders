using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.DeleteCustomerCommandHandler;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<Command, Unit>
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(command.Id);
            if (customer == null)
                throw new CustomException($"Customer with ID {command.Id} not found.");
          
            customer.IsDeleted = true;   
            _unitOfWork.Customers.UpdateAsync(customer);
            _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
