using System;
using FileReader.FileReaders;
using FileReader.Interfaces;
using FileReader.Security;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.FileReaders
{
    public class XmlFileReaderTests
    {
        private readonly IXmlFileReader _target;

        public XmlFileReaderTests()
        {
            var fileSecurity = new RoleBasedSecurity();

            _target = new XmlFileReader(fileSecurity);
        }

        [Fact]
        public void ReadXmlFile_GetTextFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadXmlFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedXmlFile_AdminRole_ReturnsFileContents()
        {
            // Arrange
            const string role = "admin";

            // Act
            var result = _target.ReadProtectedXmlFile(role);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ReadProtectedXmlFile_UserRole_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            const string role = "user";

            // Act
            Action action = () => _target.ReadProtectedXmlFile(role);

            // Assert
            action.Should().Throw<UnauthorizedAccessException>();
        }
    }
}