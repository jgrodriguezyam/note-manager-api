using NoteManager.Model;
using NoteManager.Model.Enums;

namespace NoteManager.DataAccess.Queries
{
    public interface ICustomerQuery : IQuery<Customer>
    {
        void WithId(int id);
        void WithName(string name);
        void WithLastName(string lastName);
        void WithGender(EGenderType genderType);
        void WithColony(string colony);
        void WithMunicipality(string municipality);
        void WithHomePhone(string homePhone);
        void WithCellPhone(string cellPhone);
        void WithOnlyActivated(bool onlyActivated);
    }
}