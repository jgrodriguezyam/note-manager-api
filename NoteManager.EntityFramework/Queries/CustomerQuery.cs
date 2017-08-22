using System.Linq;
using NoteManager.DataAccess.Queries;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Infrastructure.Integers;
using NoteManager.Infrastructure.Strings;
using NoteManager.Model;
using NoteManager.Model.Enums;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.EntityFramework.Queries
{
    public class CustomerQuery : QueryBase<Customer>, ICustomerQuery
    {
        public CustomerQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {
        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(customer => customer.Id == id);
        }

        public void WithName(string name)
        {
            if (name.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.Name.Contains(name));
        }

        public void WithLastName(string lastName)
        {
            if (lastName.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.LastName.Contains(lastName));
        }

        public void WithGender(EGenderType genderType)
        {
            if (genderType.GetValue().IsNotZero())
                Query = Query.Where(customer => customer.Gender == genderType);
        }

        public void WithColony(string colony)
        {
            if (colony.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.Colony.Contains(colony));
        }

        public void WithMunicipality(string municipality)
        {
            if (municipality.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.Municipality.Contains(municipality));
        }

        public void WithHomePhone(string homePhone)
        {
            if (homePhone.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.HomePhone.Contains(homePhone));
        }

        public void WithCellPhone(string cellPhone)
        {
            if (cellPhone.IsNotNullOrEmpty())
                Query = Query.Where(customer => customer.LastName.Contains(cellPhone));
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(customer => customer.IsActive);
        }
    }
}