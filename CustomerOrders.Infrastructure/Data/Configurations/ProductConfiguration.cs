using CustomerOrders.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerOrders.Infrastructure.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(c => c.Price,
                                             navigationBuilder =>
                                             {
                                                 navigationBuilder.Property(x => x.Value)
                                                                  .HasColumnName("Price");

                                             });
        }
    }
}
