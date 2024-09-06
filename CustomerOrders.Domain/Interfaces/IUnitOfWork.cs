using CustomerOrders.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IOrderRepository Orders { get; }
        IRepository<Customer> Customers { get; }

        Task<int> CompleteAsync();

    }
}
