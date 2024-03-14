using Domain.Shared;
using MediatR;

namespace Application.Abstractions;

public class ICommand : IRequest<Result>
{
}
public class ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
