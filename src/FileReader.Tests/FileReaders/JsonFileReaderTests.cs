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

            _target = new JsonFileReader(encryption, fileSecurity);
        }

        [Fact]
        public void ReadJsonFile_GetFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadEncryptedJsonFile_GetFileContentsDecrypted_Success()
        {
            // Arrange & Act
            var result = _target.ReadEncryptedFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedJsonFile_AdminRole_ReturnsFileContents()
        {
            // Arrange
            const string role = "admin";

            // Act
            var result = _target.ReadProtectedFile(role);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedJsonFile_UserRole_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            const string role = "user";

            // Act
            var result = _target.ReadProtectedFile(role);

            // Assert
            result.Should().Contain("ACCESS DENIED");
        }
    }
}