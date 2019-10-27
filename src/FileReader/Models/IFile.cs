namespace FileReader.Models
{
    public interface IFile
    {
        string FilePath { get; }

        FileTypes FileType { get; }

        bool IsProtected { get; }

        bool IsEncrypted { get; }
    }
}