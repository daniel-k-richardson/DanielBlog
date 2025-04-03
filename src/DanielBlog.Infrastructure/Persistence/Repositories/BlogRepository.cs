using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Interfaces;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.Infrastructure.Persistence.Repositories;

public class BlogRepository(AppDbContext context) : IBlogRepository
{
    public async Task<Blog> CreateBlogAsync(Blog blog)
    {
        await context.Blogs.AddAsync(blog);
        await context.SaveChangesAsync();

        return blog;
    }

    public async Task DeleteBlogAsync(Guid id)
    {
        var blog = await context.Blogs.FindAsync(id);
        if (blog is null)
        {
            throw new Exception("Blog not found");
        }
        context.Blogs.Remove(blog);
        await context.SaveChangesAsync();
    }

    public async Task UpdateBlogAsync(Blog blog)
    {
        context.Blogs.Update(blog);
        await context.SaveChangesAsync();
    }
}