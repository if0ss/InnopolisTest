using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain;

namespace Test.Infrastructure.EntityConfigurations
{
    public class ProductStorehouseConfiguration : IEntityTypeConfiguration<ProductStorehouse>
    {
        public void Configure(EntityTypeBuilder<ProductStorehouse> builder)
        {
            builder.ToTable("ProductStorehouses");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.Storehouses)
                .HasForeignKey(k => k.StorehouseId);

            builder.HasOne(e => e.Storehouse)
                .WithMany(s => s.Products)
                .HasForeignKey(k => k.ProductId);
        }
    }
}