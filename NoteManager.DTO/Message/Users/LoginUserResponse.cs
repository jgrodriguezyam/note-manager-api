using NoteManager.DTO.BaseResponse;

namespace NoteManager.DTO.Message.Users
{
    public class LoginUserResponse : LoginResponse
    {
        public int UserId { get; set; }
    }
}