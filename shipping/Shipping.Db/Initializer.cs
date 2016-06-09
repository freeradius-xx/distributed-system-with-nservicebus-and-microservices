using System.Data.Entity;

namespace Shipping.Db
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ShippingContext>
    {
        protected override void Seed(ShippingContext context)
        {
            base.Seed(context);
        }
    }
}
