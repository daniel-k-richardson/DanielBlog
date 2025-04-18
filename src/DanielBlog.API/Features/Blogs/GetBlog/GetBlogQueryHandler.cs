using DanielBlog.Domain.blogs.Exceptions.BlogExceptions;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryHandler(AppDbContext context)
{
    public async Task<GetBlogQueryResponse> Handle(Guid id, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FindAsync(id, cancellationToken);
        if (blog is null)
        {
            throw new BlogNotFound("blog not found");
        }

        return new GetBlogQueryResponse(blog.Id, blog.Title.Value, blog.Content.Value, blog.CreatedAt);
    }
}