using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DateUpdated { get; set;

        }
    }
}
