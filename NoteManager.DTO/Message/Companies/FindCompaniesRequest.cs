using NoteManager.DTO.BaseRequest;

namespace NoteManager.DTO.Message.Companies
{
    public class FindCompaniesRequest : FindBaseRequest
    {
        public string Name { get; set; }
        public string Colony { get; set; }
        public string City { get; set; }
    }
}