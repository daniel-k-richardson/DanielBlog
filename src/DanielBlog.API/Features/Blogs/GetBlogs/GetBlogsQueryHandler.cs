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

        return blogs.Select(x => new GetBlogsQueryResponse(
            x.Id,
            x.Title.Value,
            x.Content.Value,
            x.CreatedAt))
            .ToList();
    }
}