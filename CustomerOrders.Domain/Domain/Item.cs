using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Item : Entity
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Guid OrderId { get; private set; }
        public Item(Guid id, Guid productId, Guid orderId, int quantity, DateTime dateCreated, DateTime dateUpdated, bool isDeleted)
        {
            Id = id;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            IsDeleted = isDeleted;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
