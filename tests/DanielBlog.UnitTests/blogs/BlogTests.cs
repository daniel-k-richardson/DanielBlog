using DanielBlog.Domain;

namespace DanielBlog.UnitTests;

public class BlogTests
{
    [Fact]
    public void Blog_should_be_equal()
    {
        var blogId = Guid.NewGuid();

        // Arrange
        var blog1 = new Blog(blogId, new Title("Test Blog"),  new Content("Test Content"));
        var blog2 = new Blog(blogId, new Title("Test Blog 2"),  new Content("Test Content 2"));

        // Act
        var areEqual = blog1.Equals(blog2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Blog_should_be_equal_using_operators()
    {
        var blogId = Guid.NewGuid();

        // Arrange
        var blog1 = new Blog(blogId, new Title("Test Blog"),  new Content("Test Content"));
        var blog2 = new Blog(blogId, new Title("Test Blog 2"),  new Content("Test Content 2"));

        // Act
        var areEqual = blog1 == blog2;

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Blog_should_not_be_equal()
    {
        // Arrange
        var blog1 = new Blog(Guid.NewGuid(), new Title("Test Blog"),  new Content("Test Content"));
        var blog2 = new Blog(Guid.NewGuid(), new Title("Test Blog 2"),  new Content("Test Content 2"));

        // Act
        var areEqual = blog1.Equals(blog2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Blog_should_not_be_equal_using_operators()
    {
        // Arrange
        var blog1 = new Blog(Guid.NewGuid(), new Title("Test Blog"),  new Content("Test Content"));
        var blog2 = new Blog(Guid.NewGuid(), new Title("Test Blog 2"),  new Content("Test Content 2"));

        // Act
        var areNotEqual = blog1 != blog2;

        // Assert
        Assert.True(areNotEqual);
    }

}