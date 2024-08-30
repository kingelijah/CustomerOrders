using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class UpdateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
   
}
