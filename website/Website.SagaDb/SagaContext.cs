using System.Data.Entity;
using Website.Entities;

namespace Website.SagaDb
{
    public class SagaContext : DbContext
    {
        public SagaContext()
            : base("Name=SagaConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<PlaceOrderSagaData> Orders { get; set; }
    }
}
