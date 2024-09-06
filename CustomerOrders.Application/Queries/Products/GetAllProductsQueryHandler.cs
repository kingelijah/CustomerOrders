using CustomerOrders.Application.Queries.Products;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.Products.GetAllProductsQueryHandler;

namespace CustomerOrders.Application.Queries.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Products.GetAllAsync(); 
        }
    }
}
