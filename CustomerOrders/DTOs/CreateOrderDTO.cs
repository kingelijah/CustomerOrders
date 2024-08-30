using CustomerOrders.Domain.Domain;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class CreateOrderDTO
    {
        public List<ItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
   
}
