using FileReader.Constants;

namespace FileReader.Models
{
    public class XmlFile : IFile
    {
        public XmlFile()
        {
            FilePath = FilePaths.XmlFilePath;
        }

        public string FilePath { get; }
    }
}