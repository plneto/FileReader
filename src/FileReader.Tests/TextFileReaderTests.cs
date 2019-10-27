using FileReader.Interfaces;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests
{
    public class TextFileReaderTests
    {
        private readonly ITextFileReader _target;

        public TextFileReaderTests()
        {
            _target = new TextFileReader();
        }

        [Fact]
        public void ReadTextFile_GetTextFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadTextFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}