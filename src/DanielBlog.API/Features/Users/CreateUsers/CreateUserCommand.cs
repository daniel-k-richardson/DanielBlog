using DanielBlog.API.Mediators;

namespace DanielBlog.API.Features.Users.CreateUsers;

public record CreateUserCommand(string Name, string Password) : IRequest;