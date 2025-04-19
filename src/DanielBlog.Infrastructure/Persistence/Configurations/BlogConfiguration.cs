using DanielBlog.Domain.blogs;
using DanielBlog.Domain.blogs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanielBlog.Infrastructure.Persistence.Configurations;

public sealed class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(b => b.Title)
            .HasConversion(
                v => v.Value,
                v => new Title(v));

        builder
            .Property(b => b.Content)
            .HasConversion(
                v => v.Value,
                v => new Content(v));
    }
}
