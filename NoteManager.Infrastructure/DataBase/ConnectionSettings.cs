using System.Configuration;

namespace NoteManager.Infrastructure.DataBase
{
    public class ConnectionSettings
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringApi"].ConnectionString;
        } 
    }
}