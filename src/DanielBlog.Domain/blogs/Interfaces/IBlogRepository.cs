namespace DanielBlog.Domain.blogs.Interfaces;

public interface IBlogRepository
{
    Task <Blog> CreateBlogAsync(Blog blog);
    Task DeleteBlogAsync(Guid id);
    Task UpdateBlogAsync(Blog blog);
}