using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.Interfaces;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DanielBlog.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task<bool> MasterUserAlreadyExistsAsync(CancellationToken cancellationToken = default)
    {
        return (await context.Users.ToListAsync(cancellationToken)).Any();
    }
}