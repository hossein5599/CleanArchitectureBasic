using MediatR;

namespace CA.Blocks.Application.Common.Features;

public interface ICommandQuery<TResult> : IRequest<Result<TResult>>, IBaseRequest
{
}

public interface ICommandQuery : IRequest<Result>, IBaseRequest
{
}