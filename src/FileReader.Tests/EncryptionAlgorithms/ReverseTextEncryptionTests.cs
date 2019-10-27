using FileReader.EncryptionAlgorithms;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.EncryptionAlgorithms
{
    public class ReverseTextEncryptionTests
    {
        [Fact]
        public void DecryptFileContents_ValidEncryptedText_ReturnsDecryptedText()
        {
            // Arrange
            const string encryptedText = "detpyrcne si siht ,olleH";
            const string expectedDecryptedText = "Hello, this is encrypted";

            var target = new ReverseTextEncryption();

            // Act
            var decryptedString = target.DecryptFileContents(encryptedText);

            // Assert
            decryptedString.Should().BeEquivalentTo(expectedDecryptedText);
        }
    }
}