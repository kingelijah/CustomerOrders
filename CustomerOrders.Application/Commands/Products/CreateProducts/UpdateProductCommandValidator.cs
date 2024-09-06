using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Commands.Products.UpdateProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Application.Commands.CommandHandlers
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        { 
            RuleFor(x =>x.Name).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
