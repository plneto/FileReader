using FileReader.EncryptionAlgorithms;
using FileReader.FileReaders;
using FileReader.Interfaces;
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

            _target = new TextFileReader(encryptionAlgorithm);
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
    }
}