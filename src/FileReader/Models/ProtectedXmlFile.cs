using FileReader.Constants;

namespace FileReader.Models
{
    internal class ProtectedXmlFile : IFile
    {
        public ProtectedXmlFile()
        {
            FilePath = FilePaths.ProtectedXmlFilePath;
        }

        public string FilePath { get; }
    }
}