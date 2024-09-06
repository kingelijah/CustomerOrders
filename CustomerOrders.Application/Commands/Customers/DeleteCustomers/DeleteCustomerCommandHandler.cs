using CustomerOrders.Application.Commands.Customers.DeleteCustomers;
using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.Customers.DeleteCustomers.DeleteCustomerCommandHandler;

namespace CustomerOrders.Application.Commands.Customers.DeleteCustomers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(command.Id);
            if (customer == null)
                throw new CustomException($"Customer with ID {command.Id} not found.");
          
            customer.Delete();   
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
