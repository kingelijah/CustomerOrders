using CustomerOrders.Domain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Order : Entity
    {
        public virtual ICollection<Item>? Items { get; private set; }
        public Guid CustomerId { get; private set; }
        public Price TotalPrice { get; private set; }
         public Order() { }
        public Order(Guid id, Guid customerId, ICollection<Item> items, Price totalPrice, DateTime dateCreated, DateTime dateUpdated, bool isDeleted)
        {
            Id = id;
            TotalPrice = totalPrice;
            Items = items;
            CustomerId = customerId;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            IsDeleted = isDeleted;
        }
        public void Update(Price price, ICollection<Item>? items, Guid customerId, DateTime dateUpdated)
        {
            TotalPrice = price;
            DateUpdated = dateUpdated;
            Items = items;
            CustomerId = customerId;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
