using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Exceptions.BlogExceptions.ContentExceptions;
using DanielBlog.Domain.blogs.Exceptions.BlogExceptions.TitleExceptions;

namespace DanielBlog.UnitTests.blogs;

public class BlogTests
{
    [Fact]
    public void Blog_should_not_be_equal()
    {
        // Arrange
        var blog1 = new Blog("Test Blog","Test Content");
        var blog2 = new Blog("Test Blog", "Test Content");

        // Act
        var areEqual = blog1.Equals(blog2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Blog_should_not_be_equal_using_operators()
    {
        // Arrange
        var blog1 = new Blog("Test Blog","Test Content");
        var blog2 = new Blog("Test Blog","Test Content");

        // Act
        var areNotEqual = blog1 != blog2;

        // Assert
        Assert.True(areNotEqual);
    }
    
    [Fact]
    public void Blog_empty_title_should_throw_exception()
    {
        // Arrange
        var emptyTitle = string.Empty;
        var content = "Test Content";

        // Act & Assert
        Assert.Throws<TitleNullOrEmptyException>(() => new Blog(emptyTitle, content));
    }
    
    [Fact]
    public void Blog_title_length_should_throw_exception()
    {
        // Arrange
        var longTitle = new string('a', 101);
        var content = "Test Content";

        // Act & Assert
        Assert.Throws<TitleLengthException>(() => new Blog(longTitle, content));
    }
    
    [Fact]
    public void Blog_content_empty_should_throw_exception()
    {
        // Arrange
        var title = "Test Blog";
        var emptyContent = string.Empty;
        
        // Act & Assert
        Assert.Throws<ContentNullOrEmptyException>(() => new Blog(title, emptyContent));
    }
}
