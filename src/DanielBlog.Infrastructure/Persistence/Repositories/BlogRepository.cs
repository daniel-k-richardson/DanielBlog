using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Interfaces;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.Infrastructure.Persistence.Repositories;

public sealed class BlogRepository(AppDbContext context) : IBlogRepository
{
    public async Task<Blog?> GetBlogByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Blogs.FindAsync(id, cancellationToken);
    }

    public async Task<Blog> CreateBlogAsync(Blog blog, CancellationToken cancellationToken)
    {
        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return blog;
    }

    public async Task DeleteBlogAsync(Guid id, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FindAsync(id, cancellationToken);
        context.Blogs.Remove(blog);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateBlogAsync(Blog blog, CancellationToken cancellationToken)
    {
        context.Blogs.Update(blog);
        await context.SaveChangesAsync(cancellationToken);
    }
}