using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain;

namespace Test.Infrastructure
{
    public class StorehouseConfiguration : IEntityTypeConfiguration<Storehouse>
    {
        public void Configure(EntityTypeBuilder<Storehouse> builder)
        {

            builder.ToTable("Storehouses");

            builder.HasKey(e => e.Id);
        }
    }
}