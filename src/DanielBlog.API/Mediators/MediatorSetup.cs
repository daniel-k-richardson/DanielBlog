using System.Reflection;

namespace DanielBlog.API.Mediators;

public static class MediatorSetup
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddScoped<Mediator>();
        
        // Register handlers with TRequest and TResponse
        var handlerTypesWithResponse = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
            .ToList();

        foreach (var handlerType in handlerTypesWithResponse)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
            services.AddScoped(interfaceType, handlerType);
        }

        // Register handlers with TRequest only
        var handlerTypesWithoutResponse = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<>)))
            .ToList();

        foreach (var handlerType in handlerTypesWithoutResponse)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<>));
            services.AddScoped(interfaceType, handlerType);
        }
        
        return services;
    }
}
