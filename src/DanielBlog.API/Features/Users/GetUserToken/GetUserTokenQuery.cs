using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Users.GetUserToken;

public record GetUserTokenQuery(string Username, string Password)  : IRequest<GetUserTokenQueryResponse>;