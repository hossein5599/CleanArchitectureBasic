﻿using MediatR;

namespace CA.Blocks.Application.Common.Features;
public interface ICommandQueryHandler<in TRequest, TResult> : IRequestHandler<TRequest, Result<TResult>>
    where TRequest : IRequest<Result<TResult>>
{
}

public interface ICommandQueryHandler<in TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : IRequest<Result>
{
}
