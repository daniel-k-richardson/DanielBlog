using DanielBlog.API.Mediators;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public sealed class GetBlogQueryHandler(AppDbContext context) : IRequestHandler<GetBlogQuery, GetBlogQueryResponse>
{
    public async Task<GetBlogQueryResponse> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FindAsync(request.Id, cancellationToken);
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