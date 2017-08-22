namespace NoteManager.DTO.Message.Companies
{
    public class CompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Colony { get; set; }
        public string City { get; set; }
        public string Rfc { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeCellPhone { get; set; }
        public string Date { get; set; }
    }
}