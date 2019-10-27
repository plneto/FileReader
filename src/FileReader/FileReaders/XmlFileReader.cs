using System;
using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader.FileReaders
{
    public class XmlFileReader : IFileReader
    {
        private readonly IFileSecurity _fileSecurity;
        private readonly IFileEncryption _fileEncryption;
        private readonly IFile _xmlFile;
        private readonly IFile _protectedXmlFile;
        private readonly IFile _encryptedXmlFile;

        public XmlFileReader(IFileSecurity fileSecurity, IFileEncryption fileEncryption)
        {
            _fileSecurity = fileSecurity;
            _fileEncryption = fileEncryption;
            _xmlFile = new XmlFile();
            _protectedXmlFile = new ProtectedXmlFile();
            _encryptedXmlFile = new EncryptedXmlFile();
        }

        public string ReadFile()
        {
            using (var file = File.OpenText(_xmlFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadProtectedFile(string role)
        {
            if (!_fileSecurity.CanAccessFile(role))
            {
                throw new UnauthorizedAccessException(
                    $"The role {role} is unauthorized to access this file.");
            }

            using (var file = File.OpenText(_protectedXmlFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedFile()
        {
            using (var file = File.OpenText(_encryptedXmlFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}