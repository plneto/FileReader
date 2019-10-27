using AutoFixture;
using FileReader.Builders;
using FileReader.Models;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.Builders
{
    public class FileBuilderTests
    {
        private readonly Fixture _fixture;

        public FileBuilderTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void FileBuilder_NoAdditionalParameters_Success()
        {
            // Assert
            var fileType = _fixture.Create<FileTypes>();

            // Act
            var file = FileBuilder
                .Create(fileType)
                .Build();

            // Assert
            file.FileType.Should().Be(fileType);
            file.IsProtected.Should().BeFalse();
            file.IsEncrypted.Should().BeFalse();
        }

        [Fact]
        public void FileBuilder_WithEncryption_Success()
        {
            // Assert
            var fileType = _fixture.Create<FileTypes>();

            // Act
            var file = FileBuilder
                .Create(fileType)
                .WithEncryption()
                .Build();

            // Assert
            file.FileType.Should().Be(fileType);
            file.IsEncrypted.Should().BeTrue();
            file.IsProtected.Should().BeFalse();
        }

        [Fact]
        public void FileBuilder_WithAuthorization_Success()
        {
            // Assert
            var fileType = _fixture.Create<FileTypes>();

            // Act
            var file = FileBuilder
                .Create(fileType)
                .WithAuthorization()
                .Build();

            // Assert
            file.FileType.Should().Be(fileType);
            file.IsProtected.Should().BeTrue();
            file.IsEncrypted.Should().BeFalse();
        }
    }
}