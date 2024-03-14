using Domain.Shared;
using MediatR;

namespace Application.Abstractions;


public interface IQuery : IRequest<Result>
{ }
public interface IQuery<TRequest> : IRequest<Result<TRequest>>
{ }

