using NoteManager.Model;

namespace NoteManager.DataAccess.Queries
{
    public interface IUserQuery : IQuery<User>
    {
        void WithId(int id);
        void WithUserName(string userName);
        void WithOnlyActivated(bool onlyActivated);
    }
}