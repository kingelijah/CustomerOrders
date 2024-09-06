using CustomerOrders.Domain.Domain.ValueObjects;
using CustomerOrders.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CustomerOrders.Application.Abstractions;

namespace CustomerOrders.Application.Commands.Orders.CreateOrders
{
    public class CreateOrderCommand : ICommand<Guid>
    {
        public ICollection<Item> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }


    }
}
