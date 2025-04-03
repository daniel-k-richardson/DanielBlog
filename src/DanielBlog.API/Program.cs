using DanielBlog.API.Configurations.Interfaces;
using DanielBlog.Infrastructure.Persistence;
using DanielBlog.Infrastructure.Persistence.DatabaseContext;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.Services.EnsureDbCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Register all endpoints
var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
foreach (var endpoint in endpoints)
{
    endpoint.DefineEndpoints(app);
}

app.Run();