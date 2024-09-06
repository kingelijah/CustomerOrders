using CustomerOrders.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Infrastructure.Data.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o  => o.Id);
            builder.OwnsOne(c => c.TotalPrice,
                                             navigationBuilder =>
                                             {
                                                 navigationBuilder.Property(x => x.Value)
                                                                  .HasColumnName("TotalPrice");

                                             }); 
            builder.HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId).IsRequired();
            builder.HasMany(o => o.Items).WithOne().HasForeignKey(it =>it.OrderId).IsRequired();
        }
    }
}
