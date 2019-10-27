using FileReader.EncryptionAlgorithms;
using FileReader.FileReaders;
using FileReader.Interfaces;
using FileReader.Security;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.FileReaders
{
    public class XmlFileReaderTests
    {
        private readonly IFileReader _target;

        public XmlFileReaderTests()
        {
            var fileSecurity = new RoleBasedSecurity();
            var encryption = new ReverseTextEncryption();

            _target = new XmlFileReader(encryption, fileSecurity);
        }

        [Fact]
        public void ReadXmlFile_GetFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedXmlFile_AdminRole_ReturnsFileContents()
        {
            // Arrange
            const string role = "admin";

            // Act
            var result = _target.ReadProtectedFile(role);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedXmlFile_UserRole_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            const string role = "user";

            // Act
            var result = _target.ReadProtectedFile(role);

            // Assert
            result.Should().Contain("ACCESS DENIED");
        }

        [Fact]
        public void ReadEncryptedXmlFile_GetFileContentsDecrypted_Success()
        {
            // Arrange & Act
            var result = _target.ReadEncryptedFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}