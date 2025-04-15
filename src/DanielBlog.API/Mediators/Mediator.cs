namespace DanielBlog.API.Mediators;

public class Mediator(IServiceProvider serviceProvider)
{
    // For handlers with TRequest
    public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest<TResponse>
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        return await handler.Handle(request, cancellationToken);
    }

    // For handlers without TRequest
    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();
        await handler.Handle(request, cancellationToken);
    }
}
