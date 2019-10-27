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
        private readonly ITextFileReader _target;

        public TextFileReaderTests()
        {
            var encryptionAlgorithm = new ReverseTextEncryption();
            var roleBasedSecurity = new RoleBasedSecurity();

            _target = new TextFileReader(encryptionAlgorithm, roleBasedSecurity);
        }

        [Fact]
        public void ReadTextFile_GetTextFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadTextFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadEncryptedTextFile_GetTextFileContentsDecrypted_Success()
        {
            // Arrange & Act
            var result = _target.ReadEncryptedTextFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedTextFile_AdminRole_ReturnsFileContents()
        {
            // Arrange
            const string role = "admin";

            // Act
            var result = _target.ReadProtectedTextFile(role);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedTextFile_UserRole_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            const string role = "user";

            // Act
            Action action = () => _target.ReadProtectedTextFile(role);

            // Assert
            action.Should().Throw<UnauthorizedAccessException>();
        }
    }
}