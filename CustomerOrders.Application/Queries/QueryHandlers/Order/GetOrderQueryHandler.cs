using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetOrderQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<Query, Order>
    {
        public class Query : IRequest<Order>
        {
            public Guid Id { get; set; }

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Handle(Query request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
            if (order == null)
                throw new CustomException($"order with ID {request.Id} not found.");
            return order;
        }
    }
}
