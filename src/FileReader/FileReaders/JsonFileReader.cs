using System.IO;
using FileReader.Builders;
using FileReader.Interfaces;
using FileReader.Models;
using File = System.IO.File;

namespace FileReader.FileReaders
{
    public class JsonFileReader : IFileReader
    {
        private readonly IFileEncryption _fileEncryption;
        private readonly IFileSecurity _fileSecurity;

        public JsonFileReader(IFileEncryption fileEncryption, IFileSecurity fileSecurity)
        {
            _fileEncryption = fileEncryption;
            _fileSecurity = fileSecurity;
        }

        public string ReadFile()
        {
            var jsonFile = FileBuilder
                .Create(FileTypes.Json)
                .Build();

            if (jsonFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(jsonFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadProtectedFile(string role)
        {
            var jsonFile = FileBuilder
                .Create(FileTypes.Json)
                .WithAuthorization()
                .Build();

            if (jsonFile == null)
            {
                throw new FileNotFoundException();
            }

            if (!_fileSecurity.CanAccessFile(role))
            {
                return $"ACCESS DENIED: The role \"{role}\" is not authorized to access this file.";
            }

            using (var file = File.OpenText(jsonFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedFile()
        {
            var jsonFile = FileBuilder
                .Create(FileTypes.Json)
                .WithEncryption()
                .Build();

            if (jsonFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(jsonFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}