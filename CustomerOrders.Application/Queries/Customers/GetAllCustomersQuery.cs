using CustomerOrders.Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Queries.Customers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
