using DanielBlog.API.Features.Blogs;
using DanielBlog.API.Features.Users;

namespace DanielBlog.API.Features;

public static class FeatureDependencies
{
    public static void AddFeatureDependencies(this IServiceCollection services)
    {
        services.AddUserHandlers();
        services.AddBlogHandlers();
    }
}
