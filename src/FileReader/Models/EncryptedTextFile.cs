using FileReader.Constants;

namespace FileReader.Models
{
    internal class EncryptedTextFile : IFile
    {
        public EncryptedTextFile()
        {
            FilePath = FilePaths.EncryptedTextFilePath;
        }

        public string FilePath { get; }
    }
}