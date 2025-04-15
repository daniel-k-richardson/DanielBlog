using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Users.CreateUsers;

public sealed class CreateUserCommandEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/users",
                async (Mediator mediator, CreateUserCommand command, CancellationToken cancellationToken) =>
                {
                    await mediator.Send(command, cancellationToken);
                    return Results.Ok();
                })
            .WithName("CreateUser")
            .WithTags("Users");
    }
}