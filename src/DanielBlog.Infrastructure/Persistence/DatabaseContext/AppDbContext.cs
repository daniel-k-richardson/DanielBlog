using DanielBlog.Domain.blogs;
using DanielBlog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DanielBlog.Infrastructure.Persistence.DatabaseContext;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

public static class AppDbContextExtensions
{
    public static void EnsureDbCreated(this IServiceProvider app)
    {
        using var scope = app.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.CloseConnection();
    }
}