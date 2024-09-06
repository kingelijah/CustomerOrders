using CustomerOrders.Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Queries.Orders
{
    public class GetOrdersByDateQuery : IRequest<IEnumerable<Order>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDateDate { get; set; }
    }
}
