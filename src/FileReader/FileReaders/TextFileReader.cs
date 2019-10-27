using System;
using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader.FileReaders
{
    public class TextFileReader : IFileReader
    {
        private readonly IFileEncryption _fileEncryption;
        private readonly IFileSecurity _fileSecurity;
        private readonly IFile _textFile;
        private readonly IFile _encryptedTextFile;
        private readonly IFile _protectedTextFile;

        public TextFileReader(IFileEncryption fileEncryption, IFileSecurity fileSecurity)
        {
            _fileEncryption = fileEncryption;
            _fileSecurity = fileSecurity;
            _textFile = new TextFile();
            _encryptedTextFile = new EncryptedTextFile();
            _protectedTextFile = new ProtectedTextFile();
        }

        public string ReadFile()
        {
            using (var file = File.OpenText(_textFile.FilePath))
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

            using (var file = File.OpenText(_protectedTextFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadEncryptedFile()
        {
            using (var file = File.OpenText(_encryptedTextFile.FilePath))
            {
                var encryptedContents = file.ReadToEnd();

                return _fileEncryption.DecryptFileContents(encryptedContents);
            }
        }
    }
}