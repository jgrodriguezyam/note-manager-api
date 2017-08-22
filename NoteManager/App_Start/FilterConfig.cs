using System.Web.Http;
using NoteManager.Filters;

namespace NoteManager
{
    public class FilterConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Filters.Add(new ExceptionFilter());
        }
    }
}
