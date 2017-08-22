using System.Configuration;

namespace NoteManager.Infrastructure.Validators.Serials
{
    public static class SerialSettings
    {
        public readonly static string Serial = ConfigurationManager.AppSettings["Serial"];
    }
}