using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Shipping.Entities;

namespace Shipping.Db
{
    public class ShippingContext : DbContext
    {
        public ShippingContext()
            : base("Name=ShippingConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<ShippingOrderData> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
