namespace NoteManager.Infrastructure.Validators.Enums
{
    public enum EErrorCode
    {
        NotFound = 1,
        InvalidCredential = 2,
        UnauthorizedChangePassword = 3,
        Conflict = 4,
        InvalidKey = 5,
        InvalidTimespan = 6,
        InvalidSerial = 7,
        InvalidDate = 8,
        AlreadyHasAddress = 9,
        IsZero = 10,
        IsNotZero = 11,
        InvalidIdentifier = 12,
        AlreadyHasAccountStatementFile = 13,
        AlreadyHasProofFile = 14,
        MailAlreadyExists = 15,
        SurveyIsAlreadyAssigned = 16,
        UserNameAlreadyExists = 17,
        InvalidFile = 18,
        FileTooLarge = 19,
        InvalidStatusChange = 20,
        AlreadyReferenced = 21,
        HaveUnpaidsCredits = 22,
        HavePendingSolicitudes = 23
    }
}