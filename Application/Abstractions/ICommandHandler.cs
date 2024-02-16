using Domain.Shared;
using MediatR;

namespace Application.Abstractions;

internal interface ICommandHandler<TCommand>
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}
internal interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
