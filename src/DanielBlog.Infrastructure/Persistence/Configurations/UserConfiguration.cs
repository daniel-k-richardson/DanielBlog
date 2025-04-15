using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanielBlog.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(u => u.Username)
            .HasConversion(
                v => v.Value,
                v => new Username(v));
        
        builder
            .Property(u => u.Password)
            .HasConversion(
                v => v.Value,
                v => new Password(v));

    }
}
