namespace DanielBlog.API.Mediators;

// Base marker interface for requests
public interface IRequest { }

// Request with a response
public interface IRequest<TResponse> : IRequest { }

// Unified IRequestHandler interface
public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

// Request without a response
public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    Task Handle(TRequest request, CancellationToken cancellationToken);
}