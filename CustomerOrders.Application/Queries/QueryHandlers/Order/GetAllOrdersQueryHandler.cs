using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetAllOrdersQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<Query, IEnumerable<Order>>
    {
        public class Query : IRequest<IEnumerable<Order>>
        {

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Orders.GetAllAsync(); 
        }
    }
}
