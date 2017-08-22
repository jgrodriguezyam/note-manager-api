using System.Web.Http;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Users;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("users")]
        public FindUsersResponse Get(FindUsersRequest request)
        {
            return _userService.Find(request);
        }

        [HttpPost, Route("users")]
        public CreateResponse Post(UserRequest request)
        {
            return _userService.Create(request);
        }

        [HttpPut, Route("users")]
        public SuccessResponse Put(UserRequest request)
        {
            return _userService.Update(request);
        }

        [HttpGet, Route("users/{Id}")]
        public UserResponse Get(GetUserRequest request)
        {
            return _userService.Get(request);
        }

        [HttpDelete, Route("users/{Id}")]
        public SuccessResponse Delete(DeleteUserRequest request)
        {
            return _userService.Delete(request);
        }

        [HttpPost, Route("users/login")]
        public LoginUserResponse Login(LoginUserRequest request)
        {
            return _userService.Login(request);
        }

        [HttpPost, Route("users/logout/{Id}")]
        public SuccessResponse Logout(LogoutUserRequest request)
        {
            return _userService.Logout(request);
        }

        [HttpPost, Route("users/change-password")]
        public SuccessResponse ChangePassword(ChangeUserPasswordRequest request)
        {
            return _userService.ChangePassword(request);
        }

        [HttpPost, Route("users/restore-password")]
        public SuccessResponse RestorePassword(RestorePasswordRequest request)
        {
            return _userService.RestorePassword(request);
        }
    }
}