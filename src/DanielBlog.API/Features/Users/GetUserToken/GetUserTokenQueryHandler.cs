using DanielBlog.Domain.Users.Interfaces;
using DanielBlog.Infrastructure.Services;

namespace DanielBlog.API.Features.Users.GetUserToken;

public sealed class GetUserTokenQueryHandler(AuthService authService, IUserRepository repository)
{
    public async Task<GetUserTokenQueryResponse> Handle(GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken)
    {
        if (!await authService.ValidateUserAsync(getUserTokenQuery.Username, getUserTokenQuery.Password))
        {
            throw new Exception("Invalid username or password");
        }

        var token = authService.GenerateToken(getUserTokenQuery.Username);
        return new GetUserTokenQueryResponse(token);
    }
}