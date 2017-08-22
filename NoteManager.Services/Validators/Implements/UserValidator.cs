using FluentValidation;
using FluentValidation.Results;
using NoteManager.DataAccess.Repositories;
using NoteManager.Infrastructure.Collections;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Validators;
using NoteManager.Infrastructure.Validators.Enums;
using NoteManager.Model;
using NoteManager.Services.Validators.Interfaces;

namespace NoteManager.Services.Validators.Implements
{
    public class UserValidator : BaseValidator<User>, IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleSet("Base", () =>
            {
                RuleFor(user => user.UserName).NotNull().NotEmpty();
                RuleFor(user => user.Password).NotNull().NotEmpty();
            });

            RuleSet("Create", () =>
            {
                Custom(CreateValidate);
            });

            RuleSet("Update", () =>
            {
                Custom(UpdateValidate);
            });
        }

        public ValidationFailure CreateValidate(User user, ValidationContext<User> context)
        {
            var usersByUserName = _userRepository.FindBy(currentUser => currentUser.UserName == user.UserName && currentUser.IsActive);
            if (usersByUserName.IsNotEmpty())
                ExceptionExtensions.ThrowCustomConflictException(EErrorCode.UserNameAlreadyExists, "Ya existe el nombre de usuario");
            
            return null;
        }

        public ValidationFailure UpdateValidate(User user, ValidationContext<User> context)
        {
            var usersByUserName = _userRepository.FindBy(currentUser => currentUser.UserName == user.UserName && currentUser.Id != user.Id && currentUser.IsActive);
            if (usersByUserName.IsNotEmpty())
                ExceptionExtensions.ThrowCustomConflictException(EErrorCode.UserNameAlreadyExists, "Ya existe el nombre de usuario");

            return null;
        }
    }
}