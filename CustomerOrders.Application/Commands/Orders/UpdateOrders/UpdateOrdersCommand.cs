using CustomerOrders.Application.Abstractions;
using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Customers.UpdateCustomers
{
    public class UpdateOrdersCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public Price TotalPrice { get; set; }
        public Guid CustomerId { get; set; }

    }
}
