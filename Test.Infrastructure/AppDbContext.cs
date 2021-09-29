using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Test.Application;
using Test.Domain;

namespace Test.Infrastructure
{
    public sealed class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<Storehouse> Storehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStorehouse> ProductStorehouses { get; set; }
        public DbSet<Okei> Okei { get; set; }


    }
}