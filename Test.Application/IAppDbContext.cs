using Microsoft.EntityFrameworkCore;
using Test.Domain;

namespace Test.Application
{
    public interface IAppDbContext
    {
        DbSet<Storehouse> Storehouses { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductStorehouse> ProductStorehouses { get; set; }

        DbSet<Okei> Okei { get; set; }
    }
}