using System;
using FileReader.EncryptionAlgorithms;
using FileReader.FileReaders;
using FileReader.Interfaces;
using FileReader.Security;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.FileReaders
{
    public class TextFileReaderTests
    {
        private readonly IFileReader _target;

        public TextFileReaderTests()
        {
            var encryptionAlgorithm = new ReverseTextEncryption();
            var roleBasedSecurity = new RoleBasedSecurity();

            _target = new TextFileReader(encryptionAlgorithm, roleBasedSecurity);
        }

        [Fact]
        public void ReadTextFile_GetFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadEncryptedTextFile_GetFileContentsDecrypted_Success()
        {
            // Arrange & Act
            var result = _target.ReadEncryptedFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedTextFile_AdminRole_ReturnsFileContents()
        {
            // Arrange
            const string role = "admin";

            // Act
            var result = _target.ReadProtectedFile(role);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedTextFile_UserRole_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            const string role = "user";

            // Act
            Action action = () => _target.ReadProtectedFile(role);

            // Assert
            action.Should().Throw<UnauthorizedAccessException>();
        }
    }
}