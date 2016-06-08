using System.Data.Entity;

namespace Shared.ProductDb
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("Name=XxxConnectionString")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Product> Products { get; set; } 
    }
}
