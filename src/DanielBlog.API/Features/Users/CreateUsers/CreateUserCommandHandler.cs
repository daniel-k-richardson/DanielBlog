using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.Interfaces;
using DanielBlog.Domain.Users.ValueObjects;

namespace DanielBlog.API.Features.Users.CreateUsers;

public sealed class CreateUserCommandHandler(IUserRepository repository)
{
    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (await repository.MasterUserAlreadyExistsAsync(cancellationToken))
        {
            throw new ArgumentException("Master user already exists");
        }
        
        var exiting = await repository.GetUserByUsernameAsync(command.Name, cancellationToken);
        if (exiting is not null)
        {
            throw new AggregateException("User already exists");
        }
        
        var user = new User(command.Name, new Password(command.Password));
        await repository.CreateUserAsync(user, cancellationToken);
    }
}