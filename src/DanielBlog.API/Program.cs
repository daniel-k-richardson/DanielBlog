using System.Text;
using DanielBlog.API.Configurations.Endpoints;
using DanielBlog.API.Configurations.Endpoints.Interfaces;
using DanielBlog.API.Features.Blogs.CreateBlog;
using DanielBlog.API.Features.Blogs.GetBlog;
using DanielBlog.API.Features.Blogs.GetBlogs;
using DanielBlog.API.Features.Blogs.UpdateBlog;
using DanielBlog.API.Features.Users.CreateUsers;
using DanielBlog.API.Features.Users.GetUserToken;
using DanielBlog.Infrastructure.Persistence;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DanielBlog API", Version = "v1" });

    // Add security definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // Add security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

builder.Services.AddEndpoints();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<CreateBlogCommandHandler>();
builder.Services.AddScoped<GetBlogQueryHandler>();
builder.Services.AddScoped<GetBlogsQueryHandler>();
builder.Services.AddScoped<UpdateBlogCommandHandler>();
builder.Services.AddScoped<CreateUserCommandHandler>();
builder.Services.AddScoped<GetUserTokenQueryHandler>();

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SecretKey"))),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.Services.EnsureDbCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Register all endpoints
var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
foreach (var endpoint in endpoints)
{
    endpoint.DefineEndpoints(app);
}

app.Run();