using System.Linq;
using FileReader.Files;
using FileReader.Models;

namespace FileReader.Builders
{
    public class FileBuilder : IFileBuilder
    {
        private FileBuilder(FileTypes fileType)
        {
            FileType = fileType;
        }

        public FileTypes FileType { get; private set; }

        public bool IsEncrypted { get; private set; }

        public bool IsProtected { get; private set; }

        public static IFileBuilder Create(FileTypes fileType)
        {
            return new FileBuilder(fileType);
        }

        public IFileBuilder WithEncryption()
        {
            IsEncrypted = true;

            return this;
        }

        public IFileBuilder WithAuthorization()
        {
            IsProtected = true;

            return this;
        }

        public IFile Build()
        {
            return AvailableFiles.Files()
                .SingleOrDefault(x =>
                    x.FileType == FileType &&
                    x.IsEncrypted == IsEncrypted &&
                    x.IsProtected == IsProtected);
        }
    }
}