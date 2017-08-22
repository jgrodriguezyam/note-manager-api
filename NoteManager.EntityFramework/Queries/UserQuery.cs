using System.Linq;
using NoteManager.DataAccess.Queries;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Infrastructure.Integers;
using NoteManager.Infrastructure.Strings;
using NoteManager.Model;

namespace NoteManager.EntityFramework.Queries
{
    public class UserQuery : QueryBase<User>, IUserQuery
    {
        public UserQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {

        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(user => user.Id == id);
        }

        public void WithUserName(string userName)
        {
            if (userName.IsNotNullOrEmpty())
                Query = Query.Where(user => user.UserName.Contains(userName));
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(user => user.IsActive);
        }
    }
}