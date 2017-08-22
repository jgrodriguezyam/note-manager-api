using NoteManager.Model;

namespace NoteManager.DataAccess.Queries
{
    public interface ICompanyQuery : IQuery<Company>
    {
        void WithId(int id);
        void WithName(string name);
        void WithColony(string colony);
        void WithCity(string city);
        void WithOnlyActivated(bool onlyActivated);
    }
}