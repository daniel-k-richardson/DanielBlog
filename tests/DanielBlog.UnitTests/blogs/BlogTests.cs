using DanielBlog.Domain.blogs;

namespace DanielBlog.UnitTests.blogs;

public class BlogTests
{
    [Fact]
    public void Blog_should_be_equal()
    {
        var blogId = Guid.NewGuid();

        // Arrange
        var blog1 = new Blog(blogId,"Test Blog","Test Content");
        var blog2 = new Blog(blogId,"Test Blog 2","Test Content 2");

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
        var blog1 = new Blog(blogId, "Test Blog","Test Content");
        var blog2 = new Blog(blogId,"Test Blog 2", "Test Content 2");

        // Act
        var areEqual = blog1 == blog2;

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Blog_should_not_be_equal()
    {
        // Arrange
        var blog1 = new Blog(Guid.NewGuid(),"Test Blog","Test Content");
        var blog2 = new Blog(Guid.NewGuid(),"Test Blog 2", "Test Content 2");

        // Act
        var areEqual = blog1.Equals(blog2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Blog_should_not_be_equal_using_operators()
    {
        // Arrange
        var blog1 = new Blog(Guid.NewGuid(),"Test Blog","Test Content");
        var blog2 = new Blog(Guid.NewGuid(),"Test Blog 2","Test Content 2");

        // Act
        var areNotEqual = blog1 != blog2;

        // Assert
        Assert.True(areNotEqual);
    }
}