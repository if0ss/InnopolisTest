using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Domain;

namespace Test.Application
{
    public interface IAppDbContext
    {
        int SaveChanges(bool acceptAllChangesOnSuccess);
        
         Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

         DbSet<Storehouse> Storehouses { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductStorehouse> ProductStorehouses { get; set; }

        DbSet<Okei> Okei { get; set; }
    }
}