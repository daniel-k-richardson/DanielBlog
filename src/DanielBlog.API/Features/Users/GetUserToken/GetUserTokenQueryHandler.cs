using DanielBlog.API.Mediators;
using DanielBlog.Domain.Users.Interfaces;
using DanielBlog.Domain.Users.UsersExceptions;
using DanielBlog.Infrastructure.Services;

namespace DanielBlog.API.Features.Users.GetUserToken;

public class GetUserTokenQueryHandler(AuthService authService, IUserRepository repository) : IRequestHandler<GetUserTokenQuery, GetUserTokenQueryResponse>
{
    public async Task<GetUserTokenQueryResponse> Handle(GetUserTokenQuery getUserTokenQuery, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByUsernameAsync(getUserTokenQuery.Username, cancellationToken);
        if (user is null)
        {
            throw new UserNotFoundException($"User with username {getUserTokenQuery.Username} not found.");
        }

        if (!await authService.ValidateUserAsync(user.Username.Value, user.Password.Value))
        {
            throw new Exception("Invalid username or password");
        }

        var token = authService.GenerateToken(user.Username.Value);
        return new GetUserTokenQueryResponse
        {
            Token = token
        };
    }
}
