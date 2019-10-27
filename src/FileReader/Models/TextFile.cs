using FileReader.Constants;

namespace FileReader.Models
{
    public class TextFile : IFile
    {
        public TextFile()
        {
            FilePath = FilePaths.TextFilePath;
        }

        public string FilePath { get; }
    }
}