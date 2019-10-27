using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader.FileReaders
{
    public class XmlFileReader : IXmlFileReader
    {
        private readonly IFile _file;

        public XmlFileReader()
        {
            _file = new XmlFile();
        }

        public string ReadXmlFile()
        {
            using (var file = File.OpenText(_file.FilePath))
            {
                return file.ReadToEnd();
            }
        }
    }
}