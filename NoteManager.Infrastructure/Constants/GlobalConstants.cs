using System;
using NoteManager.Infrastructure.Dates;

namespace NoteManager.Infrastructure.Constants
{
    public static class GlobalConstants
    {
        public static readonly int AdminRoleId = 1;
        public static readonly string AdminRoleName = "Administrador";

        public static readonly int SystemUserId = 1;

        public static readonly string AdminUserName = "admin";
        public static readonly string AdminPassword = "admin";

        public static readonly string PublicKey = "PublicKey";
        public static readonly string PrivateKey = "PrivateKey";
        public static readonly string Timespan = "Timespan";
        public static readonly string LoginType = "LoginType";

        public static readonly string CryptographyKey = "NoteManagerKey";
        public static readonly string CompanyKey = "BINARIUM";

        public static readonly int ActivatedMigration = 1;
        public static readonly int StatusActivatedMigration = 1;

        public static readonly bool Activated = true;
        public static readonly bool Deactivated = false;

        public static readonly bool StatusActivated = true;
        public static readonly bool StatusDeactivated = false;

        public static readonly string CreatedBySystemUser =  SystemUserId + ", " + SystemUserId + ", '" + DateTime.Now.ToDateTimeStringDb() + "', '" + DateTime.Now.ToDateTimeStringDb() + "', " + StatusActivatedMigration + ", " + ActivatedMigration;
        public static readonly string AuditFields = "CreatedBy, ModifiedBy, CreatedOn, ModifiedOn, Status, IsActive";

        public static readonly int DecimalSize = 7;
        public static readonly int DecimalPrecision = 2;
    }
}
