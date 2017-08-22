using System.Web;

namespace NoteManager.Infrastructure.Files
{
    public class FileResolver : IFileResolver
    {
        public string Resolve(string filePath)
        {
            return HttpContext.Current.Server.MapPath(string.Concat("~", filePath));
        }
    }
}