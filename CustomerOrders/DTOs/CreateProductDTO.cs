using CustomerOrders.Domain.Domain.ValueObjects;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
 
}
