using FileReader.Security;
using FluentAssertions;
using Xunit;

namespace FileReader.Tests.Security
{
    public class RoleBasedSecurityTests
    {
        [Fact]
        public void CanAccessFile_AdminRole_ReturnsTrue()
        {
            // Arrange
            const string adminRole = "admin";

            var target = new RoleBasedSecurity();

            // Act
            var result = target.CanAccessFile(adminRole);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CanAccessFile_UserRole_ReturnsFalse()
        {
            // Arrange
            const string userRole = "user";

            var target = new RoleBasedSecurity();

            // Act
            var result = target.CanAccessFile(userRole);

            // Assert
            result.Should().BeFalse();
        }
    }
}