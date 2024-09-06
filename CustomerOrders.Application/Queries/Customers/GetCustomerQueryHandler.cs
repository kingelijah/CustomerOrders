using CustomerOrders.Application.Exceptions;
using CustomerOrders.Application.Queries.Customers;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetCustomerQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (customer == null)
                throw new CustomException($"customer with ID {request.Id} not found.");
            return customer;
        }
    }
}
