using CustomerOrders.Application.Exceptions;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetProductQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<Query, Product>
    {
        public class Query : IRequest<Product>
        {
            public Guid Id { get; set; }

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null)
                throw new CustomException($"product with ID {request.Id} not found.");
            return product;
        }
    }
}
