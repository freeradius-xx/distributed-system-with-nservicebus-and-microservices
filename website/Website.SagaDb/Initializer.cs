using System.Data.Entity;

namespace Website.SagaDb
{
    public class Initializer : DropCreateDatabaseIfModelChanges<SagaContext>
    {
        protected override void Seed(SagaContext context)
        {
            base.Seed(context);
        }
    }
}
