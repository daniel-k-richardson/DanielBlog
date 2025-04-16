using DanielBlog.API.Configurations.Endpoints.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DanielBlog.API.Configurations.Endpoints;

public static class EndpointExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var assembly = typeof(Program).Assembly;

        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));

        services.TryAddEnumerable(serviceDescriptors);
    }
    
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        foreach (var endpoint in endpoints)
        {
            endpoint.DefineEndpoints(app);
        }
    }
}