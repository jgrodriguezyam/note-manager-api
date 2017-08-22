using System.Data.Entity.Migrations;

namespace NoteManager.EntityFramework.DataBase
{
    public class AutomaticMigrationConfiguration : DbMigrationsConfiguration<ApiContext>
    {
        public AutomaticMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}