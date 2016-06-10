using System.Data.Entity;

namespace Shared.OrderDb
{
    public class OrderContext : DbContext
    {
        public OrderContext()
            : base("Name=OnlineStoreConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Order> Orders { get; set; } 
    }
}
