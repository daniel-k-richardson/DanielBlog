namespace DanielBlog.Domain.blogs.Interfaces;

public interface IBlogRepository
{
    Task<Blog> GetBlogByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task <Blog> CreateBlogAsync(Blog blog, CancellationToken cancellationToken = default);
    Task DeleteBlogAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateBlogAsync(Blog blog, CancellationToken cancellationToken = default);
}