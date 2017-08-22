namespace NoteManager.DTO.Message.Customers
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Colony { get; set; }
        public string Municipality { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
    }
}