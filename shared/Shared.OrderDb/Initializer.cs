using System.Data.Entity;

namespace Shared.OrderDb
{
    public class Initializer : DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            base.Seed(context);
        }
    }
}
