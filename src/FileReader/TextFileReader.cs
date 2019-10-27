using System.IO;
using FileReader.Constants;
using FileReader.Interfaces;

namespace FileReader
{
    public class TextFileReader : ITextFileReader
    {
        public string ReadTextFile()
        {
            using (var file = File.OpenText(FilePaths.TextFilePath))
            {
                return file.ReadToEnd();
            }
        }
    }
}