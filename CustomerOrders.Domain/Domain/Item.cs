using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set;

        }
    }
}
