using FileReader.Constants;

namespace FileReader.Models
{
    internal class ProtectedTextFile : IFile
    {
        public ProtectedTextFile()
        {
            FilePath = FilePaths.ProtectedTextFilePath;
        }

        public string FilePath { get; }
    }
}