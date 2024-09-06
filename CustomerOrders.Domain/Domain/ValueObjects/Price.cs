using CustomerOrders.Domain.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Domain.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Value { get; }

        public Price(decimal value)
        {
            if (value <= 0) 
            {
                throw new ArgumentException("Invalid price.");
            }
            Value = value;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
