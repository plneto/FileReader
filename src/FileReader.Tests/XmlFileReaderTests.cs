using FileReader.Interfaces;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests
{
    public class XmlFileReaderTests
    {
        private readonly IXmlFileReader _target;

        public XmlFileReaderTests()
        {
            _target = new XmlFileReader();
        }

        [Fact]
        public void ReadTextFile_GetTextFileContents_Success()
        {
            // Arrange & Act
            var result = _target.ReadXmlFile();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}