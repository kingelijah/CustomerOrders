using CustomerOrders.Domain.Domain;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated
        {
            get; set;
        }

    }
}
