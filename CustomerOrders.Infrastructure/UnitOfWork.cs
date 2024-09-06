using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Infrastructure.Data.Configurations;
using CustomerOrders.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<Product> _products;
        private IOrderRepository _Orders;
        private IRepository<Customer> _customers;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                return _products ??= new Repository<Product>(_context);
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                return _Orders ??= new OrderRepository(_context);
            }
        }
        public IRepository<Customer> Customers
        {
            get
            {
                return _customers ??= new Repository<Customer>(_context);
            }
        }

        public Task<int> CompleteAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
