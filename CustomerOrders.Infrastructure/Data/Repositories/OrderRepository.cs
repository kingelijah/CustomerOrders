using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Infrastructure.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var ere = await _dbSet
                .Where(p => p.DateCreated.Date >= startDate.Date && p.DateCreated.Date <= endDate.Date).Include(i =>i.Items)
                .ToListAsync();
            return ere;
        }
    }
}
