using System;
using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader.FileReaders
{
    public class XmlFileReader : IXmlFileReader
    {
        private readonly IFileSecurity _fileSecurity;
        private readonly IFile _xmlFile;
        private readonly IFile _protectedXmlFile;

        public XmlFileReader(IFileSecurity fileSecurity)
        {
            _fileSecurity = fileSecurity;
            _xmlFile = new XmlFile();
            _protectedXmlFile = new ProtectedXmlFile();
        }

        public string ReadXmlFile()
        {
            using (var file = File.OpenText(_xmlFile.FilePath))
            {
                return file.ReadToEnd();
            }
        }

        public string ReadProtectedXmlFile(string role)
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
    }
}