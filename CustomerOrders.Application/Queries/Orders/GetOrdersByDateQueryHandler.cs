using CustomerOrders.Application.Queries.Orders;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetOrdersByDateQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetOrdersByDateQueryHandler : IRequestHandler<GetOrdersByDateQuery, IEnumerable<Order>>
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersByDateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Orders.GetByDateRangeAsync(request.StartDate, request.EndDateDate); 
        }
    }
}
