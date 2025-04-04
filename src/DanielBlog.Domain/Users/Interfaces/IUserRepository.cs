namespace DanielBlog.Domain.Users.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> MasterUserAlreadyExistsAsync(CancellationToken cancellationToken = default);
}