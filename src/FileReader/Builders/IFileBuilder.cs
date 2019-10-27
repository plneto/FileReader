using FileReader.Models;

namespace FileReader.Builders
{
    public interface IFileBuilder
    {
        IFileBuilder WithEncryption();

        IFileBuilder WithAuthorization();

        IFile Build();
    }
}