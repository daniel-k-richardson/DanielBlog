using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanielBlog.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(u => u.Username)
            .HasConversion(
                v => v.Value,
                v => new Username(v));
        
        builder.OwnsOne(u => u.Password, password =>
        {
            password.Property(p => p.HashedValue)
                .HasColumnName("PasswordHash")
                .IsRequired();

            password.Property(p => p.Salt)
                .HasColumnName("PasswordSalt")
                .IsRequired();
        });

    }
}
