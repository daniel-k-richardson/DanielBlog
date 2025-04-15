using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Users.CreateUsers;

public sealed class CreateUserCommandEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/users",
                async (CreateUserCommandHandler handler, CreateUserCommand command, CancellationToken cancellationToken) =>
                {
                    await handler.Handle(command, cancellationToken);
                    return Results.Ok();
                })
            .WithName("CreateUser")
            .WithTags("Users");
    }
}