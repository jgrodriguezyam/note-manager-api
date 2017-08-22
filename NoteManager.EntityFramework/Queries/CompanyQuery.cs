using System.Linq;
using NoteManager.DataAccess.Queries;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Infrastructure.Integers;
using NoteManager.Infrastructure.Strings;
using NoteManager.Model;

namespace NoteManager.EntityFramework.Queries
{
    public class CompanyQuery : QueryBase<Company>, ICompanyQuery
    {
        public CompanyQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {
        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(company => company.Id == id);
        }

        public void WithName(string name)
        {
            if (name.IsNotNullOrEmpty())
                Query = Query.Where(company => company.Name.Contains(name));
        }

        public void WithColony(string colony)
        {
            if (colony.IsNotNullOrEmpty())
                Query = Query.Where(company => company.Colony.Contains(colony));
        }

        public void WithCity(string city)
        {
            if (city.IsNotNullOrEmpty())
                Query = Query.Where(company => company.City.Contains(city));
        }
        
        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(company => company.IsActive);
        }
    }
}