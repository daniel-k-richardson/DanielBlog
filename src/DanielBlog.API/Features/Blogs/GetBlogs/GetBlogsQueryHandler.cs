using DanielBlog.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DanielBlog.API.Features.Blogs.GetBlogs;

public sealed class GetBlogsQueryHandler(AppDbContext context)
{
    public async Task<List<GetBlogsQueryResponse>> Handle(CancellationToken cancellationToken)
    {
        var blogs = await context.Blogs
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return blogs.Select(x => new GetBlogsQueryResponse
        {
            Id = x.Id,
            Title = x.Title.Value,
            Content = x.Content.Value,
            CreatedAt = x.CreatedAt,
        }).ToList();
    }
}