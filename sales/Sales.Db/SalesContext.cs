using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sales.Entities;

namespace Sales.Db
{
    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("Name=SalesConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<SalesOrderData> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
