using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.ValueObjects;

namespace DanielBlog.UnitTests.blogs
{
    public class ContentTests
    {

        [Fact]
        public void Content_should_be_equal()
        {
            // Arrange
            var content1 = new Content("Test Content");
            var content2 = new Content("Test Content");

            // Act
            var areEqual = content1.Equals(content2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Content_should_not_be_equal()
        {
            // Arrange
            var content1 = new Content("Test Content");
            var content2 = new Content("Different Content");

            // Act
            var areEqual = content1.Equals(content2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void Content_should_throw_exception_when_empty()
        {
            // Arrange
            string emptyContent = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Content(emptyContent));
        }
    }
}