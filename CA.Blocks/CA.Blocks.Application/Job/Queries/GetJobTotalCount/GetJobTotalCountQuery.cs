using CA.Blocks.Application.Common.Features;

namespace CA.Blocks.Application.Job.Queries.GetJobTotalCount;

public record GetJobTotalCountQuery(
) : ICommandQuery<int>;