using System;
using FileReader.EncryptionAlgorithms;
using FileReader.FileReaders;
using FileReader.Interfaces;
using FileReader.Models;
using FileReader.Security;

namespace FileReader.Factory
{
    public static class FileReaderFactory
    {
        public static IFileReader FromFileType(FileTypes fileType)
        {
            var encryption = new ReverseTextEncryption();
            var security = new RoleBasedSecurity();

            switch (fileType)
            {
                case FileTypes.Text:
                    return new TextFileReader(encryption, security);

                case FileTypes.Xml:
                    return new XmlFileReader(encryption, security);

                case FileTypes.Json:
                    return new JsonFileReader(encryption, security);

                default:
                    throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
            }
        }
    }
}