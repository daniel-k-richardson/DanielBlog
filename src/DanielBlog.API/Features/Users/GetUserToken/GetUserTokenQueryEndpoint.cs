using DanielBlog.API.Configurations.Endpoints.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DanielBlog.API.Features.Users.GetUserToken;

public sealed class GetUserTokenQueryEndpoint : IEndpoint
{
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/Users/token",
                async (GetUserTokenQueryHandler handler, GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        var userToken = await handler.Handle(getUserTokenQuery, cancellationToken);
                        return Results.Ok(userToken);
                    }
                    catch (ArgumentException ex)
                    {
                        return Results.Problem(type: "Bad Request", title: ex.GetType().Name, detail: ex.Message, statusCode: 400);
                    }
                })
            .WithName("GetUserToken")
            .WithTags("Users");
    }
}