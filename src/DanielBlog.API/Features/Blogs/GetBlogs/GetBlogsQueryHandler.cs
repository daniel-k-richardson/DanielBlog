using DanielBlog.API.Features.Blogs.GetBlog;
using DanielBlog.API.Mediators;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryHandler(AppDbContext context) : IRequestHandler<GetBlogsQuery, GetBlogsQueryResponse>
{
    public async Task<GetBlogsQueryResponse> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await context.Blogs
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var blogsResponse = new GetBlogsQueryResponse()
        {
            Blogs = blogs.Select(x => new GetBlogQueryResponse
            {
                Id = x.Id,
                Title = x.Title.Value,
                Content = x.Content.Value,
                CreatedAt = x.CreatedAt,
            }).ToList()
        };

        return blogsResponse;
    }
}