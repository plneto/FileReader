using System;
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

            _target = new XmlFileReader(fileSecurity, encryption);
        }

        [Fact]
        public void ReadXmlFile_GetTextFileContents_Success()
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
            Action action = () => _target.ReadProtectedFile(role);

            // Assert
            action.Should().Throw<UnauthorizedAccessException>();
        }

        [Fact]
        public void ReadEncryptedXmlFile_GetXmlFileContentsDecrypted_Success()
        {
            // Arrange & Act
            var result = _target.ReadEncryptedFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}