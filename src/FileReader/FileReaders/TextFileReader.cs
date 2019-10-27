using System.IO;
using FileReader.Builders;
using FileReader.Interfaces;
using FileReader.Models;
using File = System.IO.File;

namespace FileReader.FileReaders
{
    public class TextFileReader : IFileReader
    {
        private readonly IFileEncryption _fileEncryption;
        private readonly IFileSecurity _fileSecurity;

        public TextFileReader(IFileEncryption fileEncryption, IFileSecurity fileSecurity)
        {
            _fileEncryption = fileEncryption;
            _fileSecurity = fileSecurity;
        }

        public string ReadFile()
        {
            var textFile = FileBuilder
                .Create(FileTypes.Text)
                .Build();

            if (textFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(textFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadProtectedFile(string role)
        {
            var textFile = FileBuilder
                .Create(FileTypes.Text)
                .WithAuthorization()
                .Build();

            if (textFile == null)
            {
                throw new FileNotFoundException();
            }

            if (!_fileSecurity.CanAccessFile(role))
            {
                return $"ACCESS DENIED: The role \"{role}\" is not authorized to access this file.";
            }

            using (var file = File.OpenText(textFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedFile()
        {
            var textFile = FileBuilder
                .Create(FileTypes.Text)
                .WithEncryption()
                .Build();

            if (textFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(textFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}