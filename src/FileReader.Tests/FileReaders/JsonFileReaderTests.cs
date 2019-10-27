using FileReader.EncryptionAlgorithms;
using FileReader.FileReaders;
using FileReader.Interfaces;
using FileReader.Security;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.FileReaders
{
    public class JsonFileReaderTests
    {
        private readonly IFileReader _target;

        public JsonFileReaderTests()
        {
            var fileSecurity = new RoleBasedSecurity();
            var encryption = new ReverseTextEncryption();

            _target = new JsonFileReader(fileSecurity, encryption);
        }

        [Fact]
        public void ReadJsonFile_GetFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}