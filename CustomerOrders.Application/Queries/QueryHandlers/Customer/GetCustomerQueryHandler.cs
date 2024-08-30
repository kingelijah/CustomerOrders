using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetCustomerQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<Query, Customer>
    {
        public class Query : IRequest<Customer>
        {
            public Guid Id { get; set; }

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> Handle(Query request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.Id);
            if (customer == null)
                throw new CustomException($"customer with ID {request.Id} not found.");
            return customer;
        }
    }
}
