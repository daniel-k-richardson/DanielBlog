using DanielBlog.Domain.blogs.Interfaces;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;
using DanielBlog.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanielBlog.Infrastructure.Persistence
{
    public static class PersistenceInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=danielblog.db");
            });

            services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}