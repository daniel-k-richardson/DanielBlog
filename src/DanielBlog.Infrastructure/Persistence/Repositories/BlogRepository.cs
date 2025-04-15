using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Exceptions.BlogExceptions;
using DanielBlog.Domain.blogs.Interfaces;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.Infrastructure.Persistence.Repositories;

public sealed class BlogRepository(AppDbContext context) : IBlogRepository
{
    public async Task<Blog> GetBlogByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var blog = await context.Blogs.FindAsync(id, cancellationToken);
        
        if (blog is null)
        {
            throw new BlogNotFoundException($"Blog with id {id} not found.");
        }
        
        return blog;
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
        
        if (blog is null)
        {
            throw new BlogNotFoundException($"Blog with id {id} not found.");
        }
        
        context.Blogs.Remove(blog);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateBlogAsync(Blog blog, CancellationToken cancellationToken)
    {
        context.Blogs.Update(blog);
        await context.SaveChangesAsync(cancellationToken);
    }
}