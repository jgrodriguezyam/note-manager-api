using System.Collections.Generic;
using System.IO;

namespace NoteManager.Infrastructure.Files
{
    public interface IStorageProvider
    {
        string Save(IFile file, EFileContainer fileContainer);
        Stream Retrieve(string filePath, EFileContainer fileContainer);
        void Delete(string filePath, EFileContainer fileContainer);
        string DomainResolver(string filePath, EFileContainer fileContainer);
        IEnumerable<string> ReadAllLinesCsv(string filePath);
        string PathResolver(string filePath, EFileContainer fileContainer);
    }
}