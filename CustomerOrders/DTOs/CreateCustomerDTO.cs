using CustomerOrders.Domain.Domain;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class CreateCustomerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }
    }
   
}
