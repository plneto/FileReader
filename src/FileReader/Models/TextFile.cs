using FileReader.Constants;

namespace FileReader.Models
{
    internal class TextFile : IFile
    {
        public TextFile()
        {
            FilePath = FilePaths.TextFilePath;
        }

        public string FilePath { get; }
    }
}