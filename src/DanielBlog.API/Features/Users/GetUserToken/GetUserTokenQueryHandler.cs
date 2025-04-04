using DanielBlog.Domain.Users.Interfaces;
using DanielBlog.Infrastructure.Services;

namespace DanielBlog.API.Features.Users.GetUserToken;

public class GetUserTokenQueryHandler(AuthService authService, IUserRepository repository)
{
    public async Task<GetUserTokenQueryResponse> Handle(GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByUsernameAsync(getUserTokenQuery.username, cancellationToken);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!await authService.ValidateUserAsync(user.Username, user.Password))
        {
            throw new Exception("Invalid username or password");
        }

        var token = authService.GenerateToken(user.Username);
        return new GetUserTokenQueryResponse
        {
            Token = token
        };
    }
}