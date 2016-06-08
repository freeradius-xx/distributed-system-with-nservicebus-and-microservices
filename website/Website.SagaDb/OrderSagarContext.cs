using System.Data.Entity;
using Website.Entities;

namespace Website.SagaDb
{
    public class OrderSagarContext : DbContext
    {
        public OrderSagarContext()
            : base("Name=XxxConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<PlaceOrderSagaData> Orders { get; set; }
    }
}
