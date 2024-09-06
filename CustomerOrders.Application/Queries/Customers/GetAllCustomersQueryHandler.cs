using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.Customers.GetAllCustomersQueryHandler;

namespace CustomerOrders.Application.Queries.Customers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Customers.GetAllAsync(); 
        }
    }
}
