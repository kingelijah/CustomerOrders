using CustomerOrders.Application.Abstractions;
using CustomerOrders.Domain.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Products.UpdateProducts
{
    public class UpdateProductCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }

    }
}
