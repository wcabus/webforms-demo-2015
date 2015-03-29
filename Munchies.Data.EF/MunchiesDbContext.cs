using System.Data.Entity;
using System.Linq;

namespace Munchies.Data.EF
{
    public class MunchiesDbContext : DbContext
    {
        public MunchiesDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MunchiesDbInitializer());
        }

        public DbSet<DeliveryZone> DeliveryZones { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}