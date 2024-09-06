using CustomerOrders.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Customers.UpdateCustomers
{
    public class UpdateCustomerCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
    }
}
