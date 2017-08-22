using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace NoteManager.EntityFramework.DataBase
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<ApiContext>());
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}