using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Infrastructure.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasMaxLength(100);
            builder.Property(c => c.LastName).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.PostalCode).HasMaxLength(100);

        }
    }
}
