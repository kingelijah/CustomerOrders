using CustomerOrders.Application.Abstractions;
using CustomerOrders.Domain.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Products.CreateProducts
{
    public class CreateProductCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
