using NoteManager.Model.Base;
using NoteManager.Model.Enums;

namespace NoteManager.Model
{
    public class Customer : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public EGenderType Gender { get; set; }
        public string Address { get; set; }
        public string Colony { get; set; }
        public string Municipality { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }

        public bool IsActive { get; set; }
    }
}