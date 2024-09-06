using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        { 
            RuleFor(x =>x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
        }
    }
}
