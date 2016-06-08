using System.Data.Entity;

namespace Website.SagaDb
{
    public class Initializer : DropCreateDatabaseIfModelChanges<OrderSagarContext>
    {
        protected override void Seed(OrderSagarContext context)
        {
            base.Seed(context);
        }
    }
}
