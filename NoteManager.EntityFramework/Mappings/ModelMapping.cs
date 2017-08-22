using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using NoteManager.Model;

namespace NoteManager.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User").HasKey(user => user.Id);
            Property(user => user.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            ToTable("Company").HasKey(company => company.Id);
            Property(company => company.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer").HasKey(customer => customer.Id);
            Property(customer => customer.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}