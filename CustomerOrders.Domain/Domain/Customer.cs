using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set;

        }
    }
}
