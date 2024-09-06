using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.Orders.GetOrderQueryHandler;

namespace CustomerOrders.Application.Queries.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
            if (order == null)
                throw new CustomException($"order with ID {request.Id} not found.");
            return order;
        }
    }
}
