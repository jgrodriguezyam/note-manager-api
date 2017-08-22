using NoteManager.Infrastructure.Files;
using NoteManager.Infrastructure.Strings;

namespace NoteManager.Mapper.Resolvers
{
    public static class MapperResolver
    {
        public static string MultimediaPath(string fileName, EFileContainer fileContainer)
        {
            if(fileName.IsNotNullOrEmpty())
                return string.Format("{0}{1}{2}/{3}", ServerDomainResolver.GetCurrentDomain(), FileSettings.ContentFolder, fileContainer, fileName);
            return string.Empty;
        }
    }
}