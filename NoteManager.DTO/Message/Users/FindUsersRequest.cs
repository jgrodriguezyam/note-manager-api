using NoteManager.DTO.BaseRequest;

namespace NoteManager.DTO.Message.Users
{
    public class FindUsersRequest : FindBaseRequest
    {
        public string UserName { get; set; }
    }
}