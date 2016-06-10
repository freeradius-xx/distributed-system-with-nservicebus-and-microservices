using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Shared.ProductDb
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("Name=OnlineStoreConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
