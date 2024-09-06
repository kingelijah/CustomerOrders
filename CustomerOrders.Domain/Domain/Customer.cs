using CustomerOrders.Domain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain
{
    public class Customer : Entity
    {     
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
       
        public Customer( Guid id, string firstName, string lastName, string address, string postalCode, DateTime dateCreated, DateTime dateUpdated, bool isDeleted) 
        {
            Id = id;
            FirstName = firstName;  
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
            DateCreated = dateCreated;
            IsDeleted = isDeleted;
            DateUpdated = dateUpdated;
        }
        public void Update(string firstName, string lastName, string address, string postalCode, DateTime dateUpdated)
        {
            FirstName = firstName;
            DateUpdated = dateUpdated;
            LastName = lastName;
            PostalCode = postalCode;
            Address = address;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
