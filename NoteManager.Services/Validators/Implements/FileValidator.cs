using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Infrastructure.Files;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Validators;
using NoteManager.Infrastructure.Validators.Enums;
using NoteManager.Services.Validators.Interfaces;

namespace NoteManager.Services.Validators.Implements
{
    public class FileValidator : BaseValidator<File>, IFileValidator
    {
        public FileValidator()
        {
            RuleSet("Base", () => Custom(FileSignatureValidate));
        }

        public ValidationFailure FileSignatureValidate(File file, ValidationContext<File> context)
        {
            var validFiles = FileSettings.ValidFiles;
            var fileToValid = validFiles.FirstOrDefault(validFile => validFile.Name.Equals(file.Extension));
            if (fileToValid.IsNull())
                ExceptionExtensions.ThrowCustomConflictException(EErrorCode.InvalidFile, "No es un archivo valido");

            if (file.Stream.Length > FileSettings.MaximumFileSize)
                ExceptionExtensions.ThrowCustomConflictException(EErrorCode.FileTooLarge, "El archivo es demasiado grande");
          
            return null;
        }
    }
}