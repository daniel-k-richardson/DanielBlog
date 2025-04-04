using DanielBlog.Domain.blogs.ValueObjects;

namespace DanielBlog.UnitTests.blogs
{
    public class TitleTests
    {
        [Fact]
        public void Title_should_be_equal()
        {
            // Arrange
            var title1 = new Title("Test Title");
            var title2 = new Title("Test Title");

            // Act
            var areEqual = title1.Equals(title2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Title_should_not_be_equal()
        {
            // Arrange
            var title1 = new Title("Test Title");
            var title2 = new Title("Different Title");

            // Act
            var areEqual = title1.Equals(title2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void Title_should_throw_exception_when_empty()
        {
            // Arrange
            var emptyTitle = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Title(emptyTitle));
        }
    }
}