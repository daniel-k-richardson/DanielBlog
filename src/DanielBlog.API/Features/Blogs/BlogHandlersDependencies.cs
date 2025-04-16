using DanielBlog.API.Features.Blogs.CreateBlog;
using DanielBlog.API.Features.Blogs.GetBlog;
using DanielBlog.API.Features.Blogs.GetBlogs;
using DanielBlog.API.Features.Blogs.UpdateBlog;

namespace DanielBlog.API.Features.Blogs;

public static class BlogHandlersDependencies
{
    public static void AddBlogHandlers(this IServiceCollection services)
    {
        services.AddScoped<CreateBlogCommandHandler>();
        services.AddScoped<GetBlogQueryHandler>();
        services.AddScoped<GetBlogsQueryHandler>();
        services.AddScoped<UpdateBlogCommandHandler>();
    }
}
