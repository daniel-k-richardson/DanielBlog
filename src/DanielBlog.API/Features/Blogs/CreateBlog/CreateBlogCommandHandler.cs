using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Interfaces;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public sealed class CreateBlogCommandHandler(IBlogRepository blogRepository)
{
    public async Task Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = new Blog(command.Title, command.Content);
        await blogRepository.CreateBlogAsync(blog, cancellationToken);
    }
}