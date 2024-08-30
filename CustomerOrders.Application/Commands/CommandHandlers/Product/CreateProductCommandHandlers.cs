using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using MediatR;
using static CustomerOrders.Application.Commands.CommandHandlers.CreateProductCommandHandlers;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class CreateProductCommandHandlers : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public class Command : IRequest<Unit>
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

        }
        public CreateProductCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var product = new Product { Name = command.Name, Price = command.Price, DateCreated = DateTime.UtcNow, Isdeleted = false };
            _unitOfWork.Products.AddAsync(product);
            _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
