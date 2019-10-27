using System;
using System.IO;
using FileReader.Builders;
using FileReader.Interfaces;
using FileReader.Models;
using File = System.IO.File;

namespace FileReader.FileReaders
{
    public class JsonFileReader : IFileReader
    {
        private readonly IFileSecurity _fileSecurity;
        private readonly IFileEncryption _fileEncryption;

        public JsonFileReader(IFileSecurity fileSecurity, IFileEncryption fileEncryption)
        {
            _fileSecurity = fileSecurity;
            _fileEncryption = fileEncryption;
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
            throw new NotImplementedException();
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