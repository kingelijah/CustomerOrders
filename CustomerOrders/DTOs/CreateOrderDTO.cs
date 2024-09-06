using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class CreateOrderDTO
    {
        public List<ItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }

    }

}
