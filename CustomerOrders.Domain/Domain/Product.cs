using CustomerOrders.Domain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public Product() { }
        public Product(Guid id, bool isDeleted, DateTime dateCreated, DateTime dateUpdated, string name, Price price)
        {
            Id = id;
            IsDeleted = isDeleted;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            Name = name;
            Price = price;
        }
        public void Update(string name, Price price, DateTime dateUpdated)
        {
            Name = name;
            DateUpdated = dateUpdated;
            Price = price;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
   
}
