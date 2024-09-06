using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Orders.DeleteOrders
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
