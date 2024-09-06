using CustomerOrders.Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
