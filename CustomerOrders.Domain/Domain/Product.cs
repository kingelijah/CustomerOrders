using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set;

        }
    }
}
