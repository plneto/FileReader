using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader.FileReaders
{
    public class TextFileReader : ITextFileReader
    {
        private readonly IFileEncryption _fileEncryption;
        private readonly IFile _textFile;
        private readonly IFile _encryptedTextFile;

        public TextFileReader(IFileEncryption fileEncryption)
        {
            _fileEncryption = fileEncryption;
            _textFile = new TextFile();
            _encryptedTextFile = new EncryptedTextFile();
        }

        public string ReadTextFile()
        {
            using (var file = File.OpenText(_textFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedTextFile()
        {
            using (var file = File.OpenText(_encryptedTextFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}