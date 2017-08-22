using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Validators;
using NoteManager.Infrastructure.Validators.Enums;
using NoteManager.Model;
using NoteManager.Model.Enums;
using NoteManager.Services.Validators.Interfaces;

namespace NoteManager.Services.Validators.Implements
{
    public class CustomerValidator : BaseValidator<Customer>, ICustomerValidator
    {
        public CustomerValidator()
        {
            RuleSet("Base", () =>
            {
                RuleFor(customer => customer.Name).NotNull().NotEmpty();
                RuleFor(customer => customer.LastName).NotNull().NotEmpty();
                RuleFor(customer => customer.Gender).NotNull().NotEmpty();
                RuleFor(customer => customer.Address).NotNull().NotEmpty();
                RuleFor(customer => customer.Colony).NotNull().NotEmpty();
                RuleFor(customer => customer.Municipality).NotNull().NotEmpty();
                RuleFor(customer => customer.HomePhone).NotNull().NotEmpty();
                RuleFor(customer => customer.CellPhone).NotNull().NotEmpty();
                Custom(ReferencesValidate);
            });
        }

        public ValidationFailure ReferencesValidate(Customer customer, ValidationContext<Customer> context)
        {
            var genderType = new EGenderType().ConvertToCollection().FirstOrDefault(enumerator => enumerator.Value == customer.Gender.GetValue());
            if (genderType.IsNull())
                ExceptionExtensions.ThrowCustomConflictException(EErrorCode.InvalidIdentifier, "El tipo de genero no existe");
            
            return null;
        }
    }
}