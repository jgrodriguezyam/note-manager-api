using System.Collections.Generic;
using System.Linq;
using System.Net;
using NoteManager.DataAccess.Queries;
using NoteManager.DataAccess.Repositories;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Users;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Infrastructure.Utils;
using NoteManager.Model;
using NoteManager.Services.Interfaces;
using NoteManager.Services.Validators.Interfaces;
using FastMapper;
using ApplicationException = NoteManager.Infrastructure.Exceptions.ApplicationException;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Validators.Enums;

namespace NoteManager.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _userQuery;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UserService(IUserQuery userQuery, IUserRepository userRepository, IUserValidator userValidator)
        {
            _userQuery = userQuery;
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public FindUsersResponse Find(FindUsersRequest request)
        {
            try
            {
                _userQuery.Init();
                _userQuery.WithOnlyActivated(true);
                _userQuery.WithUserName(request.UserName);
                _userQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _userQuery.TotalRecords();
                _userQuery.Paginate(request.ItemsToShow, request.Page);
                var users = _userQuery.Execute();

                return new FindUsersResponse
                {
                    Users = TypeAdapter.Adapt<List<UserResponse>>(users),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(UserRequest request)
        {
            try
            {
                var user = TypeAdapter.Adapt<User>(request);
                _userValidator.ValidateAndThrowException(user, "Base,Create");
                user.EncryptPassword();
                _userRepository.Add(user);
                return new CreateResponse(user.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Update(UserRequest request)
        {
            try
            {
                var currentUser = _userRepository.FindBy(request.Id);
                currentUser.ThrowExceptionIfRecordIsNull();
                var userToCopy = TypeAdapter.Adapt<User>(request);
                TypeAdapter.Adapt(userToCopy, currentUser);
                _userValidator.ValidateAndThrowException(currentUser, "Base,Update");
                _userRepository.Update(currentUser);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public UserResponse Get(GetUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<User, UserResponse>(user);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                _userRepository.Remove(user);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public LoginUserResponse Login(LoginUserRequest request)
        {
            try
            {
                var encryptPassword = Cryptography.Encrypt(request.Password);
                var user = _userRepository.FindBy(currentUser => currentUser.UserName == request.UserName && currentUser.Password == encryptPassword).FirstOrDefault();
                if (user.IsNull())
                    ExceptionExtensions.ThrowCustomException(HttpStatusCode.Unauthorized, EErrorCode.InvalidCredential, "Credenciales invalidas");
                return new LoginUserResponse { UserId = user.Id };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Logout(LogoutUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse ChangePassword(ChangeUserPasswordRequest request)
        {
            try
            {
                var encryptOldPassword = Cryptography.Encrypt(request.OldPassword);
                var userToUpdate = _userRepository.FindBy(user => user.UserName == request.UserName && user.Password == encryptOldPassword).FirstOrDefault();
                if (userToUpdate.IsNull())
                    ExceptionExtensions.ThrowCustomException(HttpStatusCode.Unauthorized, EErrorCode.InvalidCredential, "Credenciales invalidas");
                userToUpdate.Password = request.NewPassword;
                userToUpdate.EncryptPassword();
                _userRepository.Update(userToUpdate);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse RestorePassword(RestorePasswordRequest request)
        {
            try
            {
                var userToUpdate = _userRepository.FindBy(currentUser => currentUser.UserName == request.UserName).FirstOrDefault();
                if (userToUpdate.IsNull())
                    ExceptionExtensions.ThrowCustomException(HttpStatusCode.Unauthorized, EErrorCode.InvalidCredential, "Credenciales invalidas");
                //userToUpdate.GeneratePassword();
                //var passBeforeEncrypt = userToUpdate.Password;
                //userToUpdate.EncryptPassword();
                //_userRepository.Update(userToUpdate);
                //var customer = _customerRepository.FindBy(c => c.AccountId == userToUpdate.Id.ToString()).FirstOrDefault();
                //var fullName = customer.Name + " "+ customer.LastName;
                //var message = MailSettings.CreateMessageRestorePassword(fullName, passBeforeEncrypt);
                //var footer = MailSettings.CreateFooterMessage();
                //Mail.Send(new[] { customer.Email }, "Lomsy - Nueva contraseña", message, "", false, "Aceptar", footer);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}