using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryHandler(AppDbContext context)
{
    public async Task<GetBlogQueryResponse> Handle(Guid id, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FindAsync(id, cancellationToken);
        if (blog is null)
        {
            throw new Exception("Blog not found");
        }

        var blogResponse = new GetBlogQueryResponse
        {
            Id = blog.Id,
            Title = blog.Title.Value,
            Content = blog.Content.Value,
            CreatedAt = blog.CreatedAt
        };

        return blogResponse;
    }
}