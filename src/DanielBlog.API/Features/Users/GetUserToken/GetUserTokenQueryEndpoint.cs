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
                        return Results.Problem(ex.Message, statusCode: 400, title: "Invalid credentials", type:"Bad Request");
                    }
                })
            .WithName("GetUserToken")
            .WithTags("Users");
    }
}