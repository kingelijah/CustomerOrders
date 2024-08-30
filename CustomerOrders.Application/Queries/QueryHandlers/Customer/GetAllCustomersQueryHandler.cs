using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetAllCustomersQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<Query, IEnumerable<Customer>>
    {
        public class Query : IRequest<IEnumerable<Customer>>
        {

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Customers.GetAllAsync(); 
        }
    }
}
