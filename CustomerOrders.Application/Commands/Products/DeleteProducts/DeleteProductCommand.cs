using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Products.DeleteProducts
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
