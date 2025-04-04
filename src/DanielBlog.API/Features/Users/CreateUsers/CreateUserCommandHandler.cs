using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.Interfaces;

namespace DanielBlog.API.Features.Users.CreateUsers;

public sealed class CreateUserCommandHandler(IUserRepository repository)
{
    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (await repository.MasterUserAlreadyExistsAsync(cancellationToken))
        {
            throw new Exception("Master user already exists");
        }
        
        var exiting = await repository.GetUserByUsernameAsync(command.name, cancellationToken);
        if (exiting is not null)
        {
            throw new Exception("User already exists");
        }
        var user = new User(Guid.NewGuid(), command.name, command.password);
        await repository.CreateUserAsync(user, cancellationToken);
    }
}