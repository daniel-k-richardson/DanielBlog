using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Blogs.GetBlog;

public record GetBlogQuery(Guid Id) : IRequest<GetBlogQueryResponse>;