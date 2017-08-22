namespace NoteManager.Infrastructure.Files
{
    public interface IFileResolver
    {
        string Resolve(string filePath);
    }
}