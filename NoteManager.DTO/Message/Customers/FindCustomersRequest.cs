using NoteManager.DTO.BaseRequest;

namespace NoteManager.DTO.Message.Customers
{
    public class FindCustomersRequest : FindBaseRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int GenderType { get; set; }
        public string Colony { get; set; }
        public string Municipality { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
    }
}