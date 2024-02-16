using Domain.Shared;
using MediatR;

namespace Application.Abstractions;


internal interface IQuery : IRequest<Result>
{ }
internal interface IQuery<TRequest> : IRequest<Result<TRequest>>
{ }

