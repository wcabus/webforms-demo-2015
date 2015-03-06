using System.Data.Entity;

namespace Munchies.Data.EF
{
    internal class MunchiesDbInitializer : DropCreateDatabaseIfModelChanges<MunchiesDbContext>
    {
        protected override void Seed(MunchiesDbContext context)
        {
            //TODO provide initial data
        }
    }
}