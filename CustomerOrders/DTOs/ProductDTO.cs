using CustomerOrders.Domain.Domain.ValueObjects;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }

    }

}
