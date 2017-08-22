using FluentValidation;
using NoteManager.Infrastructure.Validators;
using NoteManager.Model;
using NoteManager.Services.Validators.Interfaces;

namespace NoteManager.Services.Validators.Implements
{
    public class CompanyValidator : BaseValidator<Company>, ICompanyValidator
    {
        public CompanyValidator()
        {
            RuleSet("Base", () =>
            {
                RuleFor(company => company.Name).NotNull().NotEmpty();
                RuleFor(company => company.Address).NotNull().NotEmpty();
                RuleFor(company => company.Colony).NotNull().NotEmpty();
                RuleFor(company => company.City).NotNull().NotEmpty();
                RuleFor(company => company.Rfc).NotNull().NotEmpty();
                RuleFor(company => company.OfficePhone).NotNull().NotEmpty();
                RuleFor(company => company.OfficeCellPhone).NotNull().NotEmpty();
                RuleFor(company => company.Date).NotNull().NotEmpty();
            });
        }
    }
}