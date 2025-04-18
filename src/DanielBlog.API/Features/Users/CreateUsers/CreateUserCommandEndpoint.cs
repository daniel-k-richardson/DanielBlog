using DanielBlog.API.Configurations.Endpoints.Interfaces;

namespace DanielBlog.API.Features.Users.CreateUsers;

public sealed class CreateUserCommandEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/users",
                async (CreateUserCommandHandler handler, CreateUserCommand command, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        await handler.Handle(command, cancellationToken);
                        return Results.Ok();
                    }
                    catch (ArgumentException ex)
                    {
                        return Results.Problem(type: "Bad Request", title: ex.GetType().Name, detail: ex.Message, statusCode: 400);
                    }
                })
            .WithName("CreateUser")
            .WithTags("Users");
    }
}