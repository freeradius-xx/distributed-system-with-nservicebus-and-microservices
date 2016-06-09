using System.Data.Entity;

namespace Sales.Db
{
    public class Initializer : DropCreateDatabaseIfModelChanges<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            base.Seed(context);
        }
    }
}
