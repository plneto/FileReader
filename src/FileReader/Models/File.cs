namespace FileReader.Models
{
    internal class File : IFile
    {
        public File(string filePath, FileTypes fileType, bool isProtected, bool isEncrypted)
        {
            FilePath = filePath;
            FileType = fileType;
            IsProtected = isProtected;
            IsEncrypted = isEncrypted;
        }

        public string FilePath { get; }

        public FileTypes FileType { get; }

        public bool IsProtected { get; }

        public bool IsEncrypted { get; }
    }
}