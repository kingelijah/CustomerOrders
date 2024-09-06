using CustomerOrders.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.Customers.CreateCustomers
{
    public class CreateCustomerCommand : ICommand<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
    }
}
