using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.ValueObjects;
using DanielBlog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DanielBlog.Infrastructure.Persistence.DatabaseContext;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasKey(x => x.Id);

        modelBuilder.Entity<Blog>()
            .Property(b => b.Title)
            .HasConversion(
                v => v.Value,
                v => new Title(v));

        modelBuilder.Entity<Blog>()
            .Property(b => b.Content)
            .HasConversion(
                v => v.Value,
                v => new Content(v));

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