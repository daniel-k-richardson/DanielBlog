using DanielBlog.API.Mediators;
using DanielBlog.Domain.blogs.Interfaces;

namespace DanielBlog.API.Features.Blogs.UpdateBlog;

public sealed class UpdateBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<UpdateBlogCommand>
{
    public async Task Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await blogRepository.GetBlogByIdAsync(command.Id, cancellationToken);

        if (blog is null)
        {
            throw new ArgumentException($"Blog with ID {command.Id} not found.");
        }

        blog.Update(command.Title, command.Content);

        await blogRepository.UpdateBlogAsync(blog, cancellationToken);

    }
}