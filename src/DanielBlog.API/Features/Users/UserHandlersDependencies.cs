using DanielBlog.API.Features.Blogs.UpdateBlog;
using DanielBlog.API.Features.Users.CreateUsers;
using DanielBlog.API.Features.Users.GetUserToken;

namespace DanielBlog.API.Features.Users;

public static class UserHandlersDependencies
{
    public static void AddUserHandlers(this IServiceCollection services)
    {
        services.AddScoped<UpdateBlogCommandHandler>();
        services.AddScoped<CreateUserCommandHandler>();
        services.AddScoped<GetUserTokenQueryHandler>();
    }
}
