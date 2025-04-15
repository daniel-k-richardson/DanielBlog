using DanielBlog.API.Mediators;
using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.Interfaces;

namespace DanielBlog.API.Features.Blogs.CreateBlog;

public sealed class CreateBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<CreateBlogCommand>
{
    public async Task Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = new Blog(Guid.NewGuid(), command.Title, command.Content);
        await blogRepository.CreateBlogAsync(blog, cancellationToken);
    }
}