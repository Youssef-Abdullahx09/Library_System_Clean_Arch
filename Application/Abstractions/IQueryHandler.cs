using Domain.Shared;
using MediatR;

namespace Application.Abstractions;

internal interface IQueryHandler<TQuery>
    : IRequestHandler<TQuery, Result>
    where TQuery : IQuery
{ }
internal interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }
