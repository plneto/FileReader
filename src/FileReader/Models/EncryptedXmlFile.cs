using FileReader.Constants;

namespace FileReader.Models
{
    internal class EncryptedXmlFile : IFile
    {
        public EncryptedXmlFile()
        {
            FilePath = FilePaths.EncryptedXmlFilePath;
        }

        public string FilePath { get; }
    }
}