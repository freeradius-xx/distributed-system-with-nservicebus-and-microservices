using System.Data.Entity;

namespace Shared.ProductDb
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            base.Seed(context);
        }
    }
}
