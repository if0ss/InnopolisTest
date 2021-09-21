using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain;

namespace Test.Infrastructure.EntityConfigurations
{
    public class OkeiConfiguration : IEntityTypeConfiguration<Okei>
    {
        public void Configure(EntityTypeBuilder<Okei> builder)
        {
            builder.ToTable("Okei");

            builder.HasKey(e => e.Id);
        }
    }
}