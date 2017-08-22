using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NoteManager.EntityFramework.Mappings;
using NoteManager.Model;

namespace NoteManager.EntityFramework.DataBase
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class ApiContext : DbContext
    {
        public ApiContext() : base("name=ConnectionStringApi")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApiContext>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CustomerMap());
        }
    }
}