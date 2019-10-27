using System;
using System.IO;
using FileReader.Builders;
using FileReader.Interfaces;
using FileReader.Models;
using File = System.IO.File;

namespace FileReader.FileReaders
{
    public class XmlFileReader : IFileReader
    {
        private readonly IFileSecurity _fileSecurity;
        private readonly IFileEncryption _fileEncryption;

        public XmlFileReader(IFileSecurity fileSecurity, IFileEncryption fileEncryption)
        {
            _fileSecurity = fileSecurity;
            _fileEncryption = fileEncryption;
        }

        public string ReadFile()
        {
            var xmlFile = FileBuilder
                .Create(FileTypes.Xml)
                .Build();

            if (xmlFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(xmlFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadProtectedFile(string role)
        {
            var xmlFile = FileBuilder
                .Create(FileTypes.Xml)
                .WithAuthorization()
                .Build();

            if (xmlFile == null)
            {
                throw new FileNotFoundException();
            }

            if (!_fileSecurity.CanAccessFile(role))
            {
                throw new UnauthorizedAccessException(
                    $"The role {role} is unauthorized to access this file.");
            }

            using (var file = File.OpenText(xmlFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedFile()
        {
            var xmlFile = FileBuilder
                .Create(FileTypes.Xml)
                .WithEncryption()
                .Build();

            if (xmlFile == null)
            {
                throw new FileNotFoundException();
            }

            using (var file = File.OpenText(xmlFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}