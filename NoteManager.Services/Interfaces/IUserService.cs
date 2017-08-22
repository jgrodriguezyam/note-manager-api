﻿using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Users;

namespace NoteManager.Services.Interfaces
{
    public interface IUserService
    {
        FindUsersResponse Find(FindUsersRequest request);
        CreateResponse Create(UserRequest request);
        SuccessResponse Update(UserRequest request);
        UserResponse Get(GetUserRequest request);
        SuccessResponse Delete(DeleteUserRequest request);
        LoginUserResponse Login(LoginUserRequest request);
        SuccessResponse Logout(LogoutUserRequest request);
        SuccessResponse ChangePassword(ChangeUserPasswordRequest request);
        SuccessResponse RestorePassword(RestorePasswordRequest request);
    }
}