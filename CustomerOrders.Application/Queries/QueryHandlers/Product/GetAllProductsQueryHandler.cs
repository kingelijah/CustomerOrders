using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.QueryHandlers.GetAllProductsQueryHandler;

namespace CustomerOrders.Application.Queries.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<Query, IEnumerable<Product>>
    {
        public class Query : IRequest<IEnumerable<Product>>
        {

        }
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Products.GetAllAsync(); 
        }
    }
}
