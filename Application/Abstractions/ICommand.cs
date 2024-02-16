using Domain.Shared;
using MediatR;

namespace Application.Abstractions;

internal class ICommand : IRequest<Result>
{
}
internal class ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
