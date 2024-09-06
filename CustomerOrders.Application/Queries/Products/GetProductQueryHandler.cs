using CustomerOrders.Application.Exceptions;
using CustomerOrders.Application.Queries.Products;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Queries.Products.GetProductQueryHandler;

namespace CustomerOrders.Application.Queries.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null)
                throw new CustomException($"product with ID {request.Id} not found.");
            return product;
        }
    }
}
